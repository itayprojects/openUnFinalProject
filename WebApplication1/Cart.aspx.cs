using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cart1 : System.Web.UI.Page
    {
        Orders newOrder;
        IBLL BllOrder;

        Product updateProduct;
        IBLL_Product BllProduct;

        PurchaseDetails newPurchase;
        IBLL_PurchaseDetails BllPurchase;

        IBLL_User BllUser;

        DataTable dt;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                AddItemToCart(Request.QueryString["id"]);
                fillDate();
            }
            if (Session["fotterMaster"] != null && Session["UserID"] != null)
            {
                Session["fotterMaster"] = null;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#billModal').modal();", true);
                
            }
           

        }

        public Cart1()
        {
            BllProduct = FactoryBLL_User.GetBllProduct();

            newOrder = new Orders();
            BllOrder = FactoryBLL_User.GetBllOrder();

            newPurchase = new PurchaseDetails();
            BllPurchase = FactoryBLL_User.GetBllPurchase();

            BllUser = FactoryBLL_User.GetBllUser();
        }

        protected void AddItemToCart(string ItemId)
        {
            DataTable pd;
            DataRow dr;
            int productQuantity;
            double totalPrice, productPrice;



            //if itemInLisr is empty then create new table
            if (Session["itemInLisr"] == null)
            {
                dt = new DataTable();

                dt.Columns.Add("Pid");
                dt.Columns.Add("Pimag");
                dt.Columns.Add("Pname");
                dt.Columns.Add("Pprice");
                dt.Columns.Add("Pquantity");
                dt.Columns.Add("Ptotal");

                dr = dt.NewRow();

                BuyItems.Enabled = false;
            }
            else
            {
                dt = (DataTable)Session["itemInLisr"];

                dr = dt.NewRow();

                BuyItems.Enabled = true;
                Clear.Visible = true;
            }

            Session["ProductAdded"] = "false";



            /*
             * add new product to list if the product:
             * 1)not in the table
             * 2)the product has quantity required
             * 3)product was selected from home page
             */
            //add new product to list 
            if (ItemId != null && !dataInTable(ItemId) && quantityInData(ItemId, Convert.ToInt32(Request.QueryString["quantity"].ToString())))
            {
                //search product by ID from data
                pd = BllProduct.SearchById(ItemId);
                
                dr["Pid"] = pd.Rows[0]["Id"];
                dr["Pimag"] = pd.Rows[0]["Product_Img_Link"].ToString();
                dr["Pname"] = pd.Rows[0]["Name"].ToString();
                dr["Pprice"] = pd.Rows[0]["Price"].ToString();
                dr["Pquantity"] = Request.QueryString["quantity"];

                productQuantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                productPrice = Convert.ToDouble(Convert.ToDecimal(pd.Rows[0]["Price"].ToString()));
                totalPrice = productQuantity * productPrice;
                dr["Ptotal"] = totalPrice;
                
                
                //add to table
                dt.Rows.Add(dr);
                //update itemInLisr
                Session["itemInLisr"] = dt;
                Response.Redirect("Cart.aspx");
                
            }
            else
            {
                dt = (DataTable)Session["itemInLisr"];
            }
            //update cart
            cart_data.DataSource = dt;
            cart_data.DataBind();
            //update total price
            if (cart_data.Rows.Count > 0)
            {
                cart_data.FooterRow.Cells[5].Text = "Total";
                cart_data.FooterRow.Cells[6].Text = TotalSum().ToString();

            }
            
        }

        protected double TotalSum()
        {
            
            double Total = 0;
            
            DataTable ndt = (DataTable)Session["itemInLisr"];
            int i = 0, rows_in_data = ndt.Rows.Count;

            while (i< rows_in_data)
            {
                Total = Total + Convert.ToDouble(ndt.Rows[i]["Ptotal"].ToString());
                i++;
            }
            Session["Total"] = Total;
            return Total;
        }

        protected bool dataInTable(string ItemId)
        {
            int rowData, rows_in_data;
            double productPrice, totalPrice;

            DataTable ndt = (DataTable)Session["itemInLisr"];
            
            if (Session["itemInLisr"]==null)
            {
                return false;
            }



            rows_in_data = ndt.Rows.Count;
            for (int i = 0; i < rows_in_data; i++)
            {
                //check if product in the cart
                if (ndt.Rows[i]["Pid"].ToString().Equals(ItemId))
                {
                    rowData = Convert.ToInt32(ndt.Rows[i]["Pquantity"].ToString())+ Convert.ToInt32(Request.QueryString["quantity"]);
                    //check quantity In Data and not over 20
                    if (!quantityInData(ItemId, rowData) || rowData>20)
                    {
                        return true;
                    }

                    ndt.Rows[i]["Pquantity"] = rowData.ToString();
                    productPrice = Convert.ToDouble(ndt.Rows[i]["Pprice"].ToString());
                    totalPrice = rowData * productPrice;
                    ndt.Rows[i]["Ptotal"] = totalPrice;
                    Session["itemInLisr"] = ndt;
                    cart_data.DataSource = ndt;
                    cart_data.DataBind();
                    if (cart_data.Rows.Count > 0)
                    {
                        cart_data.FooterRow.Cells[5].Text = "Total";
                        cart_data.FooterRow.Cells[6].Text = TotalSum().ToString();
                    }
                    return true;
                }
            }
            return false;
        }

        protected bool quantityInData(string ItemId,int quantity)
        {
            DataTable pd;
            string massege;
            int quantityInStock;

            //Search product in data By Id
            pd = BllProduct.SearchById(ItemId);
            if (ItemId == null)
            {
                return false;
            }
            quantityInStock = Convert.ToInt32(pd.Rows[0]["Quantity"].ToString());
            //check if quantity In Stock is larger then quantity required
            if (quantityInStock < quantity)
            {
                massege = "Sorry but the product is currently out of stock";
                if (quantityInStock>0)
                {
                    massege += " ,In stock there are "+quantityInStock+" of the product";
                }
                ChoseDateLable.Text = massege;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ProductInventory').modal();", true);
                return false;
                
            }

            return true;
        }

        protected void cart_data_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string delete = (string)cart_data.DataKeys[e.RowIndex].Value;
            int index = Convert.ToInt32(e.RowIndex);

            DataTable ndt = (DataTable)Session["itemInLisr"];
            ndt.Rows[index].Delete();

            if (ndt.Rows.Count==0)
            {
                Session["itemInLisr"] = null;
                Clear.Visible = false;
            }
            else
            {
                Session["itemInLisr"] = ndt;
            }
            //update cart
            cart_data.DataSource = ndt;
            cart_data.DataBind();
            if (cart_data.Rows.Count > 0)
            {
                cart_data.FooterRow.Cells[5].Text = "Total";
                cart_data.FooterRow.Cells[6].Text = TotalSum().ToString();

            }

            Response.Redirect("Cart.aspx");


        }

        protected void ReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BuyItems_Click(object sender, EventArgs e)
        {
            
            if (Session["UserID"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#billModal').modal();", true);
            }
            else
            {
                Session["fotterMaster"] = "false";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#userRegister').modal();", true);

            }
            
        }

        protected void fillDate()
        {
            yearSelect.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            yearSelect.SelectedIndex = 0;

            monthSelect.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            monthSelect.SelectedIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                yearSelect.Items.Add(DateTime.Now.AddYears(i).ToString("yyyy"));
            }

            for (int i = 0; i < 12; i++)
            {
                monthSelect.Items.Add((i+1).ToString());
            }
        }

        

        protected void confirmOrder_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert itto th ine object
            if (IsValid)
            {
                orderToDataBase();
                PurchaseToDataBase();
                ClearData();
                Response.Redirect("PurchaseSummary.aspx");
            }
            

        }

        protected void orderToDataBase()
        {
            Session["orderId"] = null;
            //get new order Id
            Session["orderId"] = Guid.NewGuid().ToString();

            DataTable dataBaseOrders = (DataTable)Session["itemInLisr"];

            for (int i = 0; i < dataBaseOrders.Rows.Count; i++)
            {
                //get From data by Id To Object
                updateProduct = BllProduct.FromIdToObject(dataBaseOrders.Rows[i]["Pid"].ToString()) as Product;
                //update Quantity in data
                updateProduct.Quantity -= Convert.ToInt32(dataBaseOrders.Rows[i]["Pquantity"].ToString());
                //update product in data
                bool success = BllProduct.Update(updateProduct);
                if (!success)
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                    //clear();

                }
                newOrder.OrderID = Session["orderId"].ToString();
                newOrder.ProductId = Convert.ToInt32(dataBaseOrders.Rows[i]["Pid"].ToString());
                newOrder.ProductName = dataBaseOrders.Rows[i]["Pname"].ToString();
                newOrder.Price = Convert.ToDecimal(dataBaseOrders.Rows[i]["Pprice"].ToString());
                newOrder.Quantity = Convert.ToInt32(dataBaseOrders.Rows[i]["Pquantity"].ToString());
                newOrder.Purchase_Time = DateTime.Now;

                //Entering the data into the database
                success = BllOrder.Add(newOrder);
                if (!success)
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                    //clear();

                }

            }
        }

        protected void PurchaseToDataBase()
        {
           

            newPurchase.ID_User = Convert.ToInt32(Session["UserID"]);
            newPurchase.OrderID = Session["orderId"].ToString();
            newPurchase.Grand_Total = Convert.ToDecimal(Session["Total"]);
            newPurchase.Purchase_Time =DateTime.Now;
            newPurchase.CardNumber = Convert.ToInt32(CardNumber.Text);
            newPurchase.CardExpirationDate = yearSelect.Text + "/" + monthSelect.Text;
            newPurchase.CVV= Convert.ToInt32(cvv.Text);
            newPurchase.PurchaseComplete = false;

            //Entering the data into the database
            bool success = BllPurchase.Add(newPurchase);
            if (!success)
            {
                Response.Write("<script>alert('Add didnt work');</script>");
                //clear();

            }
            else
            {
                //get user info
                dt = BllUser.SearchById(Session["UserID"].ToString());
                //sent mail to user
                BllPurchase.SendEmail(dt.Rows[0]["Email"].ToString(), Session["orderId"].ToString());
            }

             
        }

        protected void btnSign_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignUp.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginUser.aspx");
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        protected void ClearData()
        {
            Session["itemInLisr"] = null;
            DataTable dt = (DataTable)Session["itemInLisr"];

            cart_data.DataSource = dt;
            cart_data.DataBind();
            BuyItems.Enabled = false;
            Clear.Visible = false;
        }
    }
}
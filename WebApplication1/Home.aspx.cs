using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        IBLL_Product BllProduct;
        IBLL AllCategory;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StoreName"]!=null)
                {
                    storName.Text = "Welcome to "+ Session["StoreName"].ToString();
                }
                myRepeter.DataBind();
                CategorySelection();
            }
        }
        public WebForm1()
        {
            BllProduct = FactoryBLL_User.GetBllProduct();
            AllCategory = FactoryBLL_User.GetBllCategory();
        }
        protected void SearchData_TextChanged(object sender, EventArgs e)
        {
            string KeyWord = SearchData.Text;
            
            if (KeyWord != null)
            {
                //search product by keyword from data
                DataTable dt = BllProduct.Search(KeyWord);
                //update controller
                myRepeter.DataSourceID = null;
                myRepeter.DataSource = dt;
                myRepeter.DataBind();
            }
            else
            {
                myRepeter.DataSourceID = SqlDataProduct.ConnectionString;
            }
        }

        
        protected void myRepeter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["ProductAdded"] = "true";
            int checkQwantity;
            if (e.CommandName== "act1")
            {
                //get selected product
                var addItem = e.Item.FindControl("outputone") as TextBox;
                checkQwantity = Convert.ToInt32(addItem.Text);

                //check if selected product is over 20 or less then 0
                if (checkQwantity > 20 || checkQwantity<=0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#orderModal').modal();", true);
                    addItem.Text = "0";
                }
                else
                {
                    Response.Write("<script>alert('" + addItem.Text + "');</script>");
                    //check if user is worker or shopper
                    if (Session["BuisnessWorker"]!=null && Session["BuisnessWorker"].ToString().Equals("1"))
                    {
                        Response.Redirect("Home.aspx");
                    }
                    //go to cart page with the product ID an quantity
                    Response.Redirect("Cart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + addItem.Text.ToString());
                    addItem.Text = "0";
                }
                
            }
        }

        protected void CategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string KeyWord = CategorySelect.SelectedItem.ToString();

            if (KeyWord != null)
            {
                //search product by category name
                DataTable dt = BllProduct.Search(KeyWord);
                //update controller
                myRepeter.DataSourceID = null;
                myRepeter.DataSource = dt;
                myRepeter.DataBind();
            }
            else
            {
                myRepeter.DataSourceID = SqlDataProduct.ConnectionString;
            }
        }

        

        protected void CategorySelection()
        {
            //select all Category from database
            DataTable CategoryTt = AllCategory.Select();
            //update controller
            CategorySelect.DataSource = CategoryTt;
            CategorySelect.DataValueField = "Title";
            CategorySelect.DataBind();

            CategorySelect.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            CategorySelect.SelectedIndex = 0;
        }


    }
}
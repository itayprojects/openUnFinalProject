using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminManagmentProduct : System.Web.UI.Page
    {
        Product newProduct;
        IBLL_Product BllProduct;
        IBLL AllCategory = FactoryBLL_User.GetBllCategory();
        
        
        static string filePathGlobal;

        public AdminManagmentProduct()
        {
            newProduct = new Product();
            BllProduct = FactoryBLL_User.GetBllProduct();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                reloadPage();
                CategorySelection();
                if (String.IsNullOrEmpty(ProductID.Text))
                {
                    btn_add.Enabled = true;
                    btn_update.Enabled = false;
                }
                else
                {
                    btn_add.Enabled = false;
                    btn_update.Enabled = true;
                }
            }
        }

        protected void reloadPage()
        {
            DataTable ProductToOrder = new DataTable();
            RadioProductSelect.Items.Clear();
            ProductToOrder =BllProduct.ProductInventoryZero();

            if (ProductToOrder.Rows.Count>0)
            {
                ProductInventory.Visible = true;
            }
            else
            {
                ProductInventory.Visible = false;
            }
            for (int i = 0; i < ProductToOrder.Rows.Count; i++)
            {
                RadioProductSelect.Items.Add(new ListItem(ProductToOrder.Rows[i]["Pname"].ToString(), ProductToOrder.Rows[i]["Pid"].ToString()));
            }
            
            
            DataOut.DataBind();
        }
        
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string filePath, fileName;

            //Save an image to a destination file or leave a default image
            filePath = "~/Icon/product.png"; 
            if (ImgFile.HasFile)
            {
                fileName = Path.GetFileName(ImgFile.PostedFile.FileName);
                ImgFile.SaveAs(Server.MapPath("ProductInventoryImg/" + fileName));
                filePath = "~/ProductInventoryImg/" + fileName;
            }

            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newProduct.Name = NameProduct.Text.Trim();
                newProduct.Category = CategorySelect.SelectedItem.Text;
                newProduct.Description = Description.Text.Trim();
                newProduct.Price = decimal.Parse(Price.Text.Trim());
                newProduct.Quantity = int.Parse(Quantity.Text.Trim());
                newProduct.AddDate = DateTime.Now;
                newProduct.Product_Img_Link = filePath;

                //Entering the data into the database
                bool success = BllProduct.Add(newProduct);
                if (success)
                {
                    Response.Write("<script>alert('Add is successful');</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                }
                
                reloadPage();
                clear();
            }
            
        }

        private void clear()
        {
            ImgFile.Dispose();
            ProductID.Text = "";
            NameProduct.Text = "";
            CategorySelect.SelectedIndex = 0;
            Description.Text = "";
            Price.Text = "";
            Quantity.Text = "";
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string filePath, fileName;

            //Save an image to a destination file or leave a default image
            filePath = "~/Icon/product.png";
            fileName = Path.GetFileName(ImgFile.PostedFile.FileName);
            if (!ImgFile.HasFile)
            {

                filePath = filePathGlobal;
            }
            else
            {
                ImgFile.SaveAs(Server.MapPath("ProductInventoryImg/" + fileName));
                filePath = "~/ProductInventoryImg/" + fileName;
            }

            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newProduct.ID = Int32.Parse(ProductID.Text.ToString().Trim());
                newProduct.Name = NameProduct.Text.Trim();
                newProduct.Category = CategorySelect.SelectedItem.Text;
                newProduct.Description = Description.Text.Trim();
                newProduct.Price = decimal.Parse(Price.Text.Trim());
                newProduct.Quantity = int.Parse(Quantity.Text.Trim());
                newProduct.AddDate = DateTime.Now;
                newProduct.Product_Img_Link = filePath;

                //Update the data in the database
                bool success = BllProduct.Update(newProduct);
                if (success)
                {
                    Response.Write("<script>alert('Add is successful');</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                }
                reloadPage();
                clear();
            }

        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            
            ProductID.Text = DataOut.Rows[gr].Cells[0].Text;
            ViewSelect(DataOut.Rows[gr].Cells[0].Text);
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            newProduct.ID = Convert.ToInt32(DataOut.Rows[gr].Cells[0].Text.ToString());

            //Delete from database
            bool success = BllProduct.Delete(newProduct);
            if (success)
            {
                Response.Write("<script>alert('delete successful');</script>");
                clear();
            }
            else
            {
                Response.Write("<script>alert('delete didnt work');</script>");
            }
            reloadPage();
        }


        protected void CategorySelection()
        {
            //select all Category
            DataTable CategoryTt = AllCategory.Select();
            CategorySelect.DataSource = CategoryTt;
            //show only title of Category
            CategorySelect.DataValueField = "Title";
            CategorySelect.DataBind();

            CategorySelect.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            CategorySelect.SelectedIndex = 0;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            clear();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
        }

        protected void ProductInventory_Click(object sender, EventArgs e)
        {
            if (RadioProductSelect.Visible)
            {
                RadioProductSelect.Visible = false;
            }
            else
            {
                RadioProductSelect.Visible = true;
            }
        }

        protected void RadioProductSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSelect(RadioProductSelect.SelectedValue);
        }

        /*
         insert all data to the correct place in the form 
         */
        protected void ViewSelect(string id)
        {
            DataTable dt;

            ProductID.Text = id;
            dt = BllProduct.SearchById(ProductID.Text);
            NameProduct.Text = dt.Rows[0]["Name"].ToString();
            CategorySelect.SelectedItem.Value = dt.Rows[0]["Category"].ToString();
            CategorySelect.SelectedItem.Text = dt.Rows[0]["Category"].ToString();
            Description.Text = dt.Rows[0]["Description"].ToString();
            Price.Text = dt.Rows[0]["Price"].ToString();
            Quantity.Text = dt.Rows[0]["Quantity"].ToString();
            filePathGlobal = dt.Rows[0]["Product_Img_Link"].ToString();

            btn_add.Enabled = false;
            btn_update.Enabled = true;
        }
    }
}
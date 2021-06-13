using BE;
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
    public partial class AdminManagmentCategory : System.Web.UI.Page
    {
        Category newCategory;
        IBLL BllCategory;
        
        public AdminManagmentCategory()
        {
            newCategory = new Category();
            BllCategory = FactoryBLL_User.GetBllCategory();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                reloadPage();
                if (String.IsNullOrEmpty(CategoryID.Text))
                {
                    add_cat.Enabled = true;
                    update_cat.Enabled = false;
                }
                else
                {
                    add_cat.Enabled = false;
                    update_cat.Enabled = true;
                }
            }
        }

        protected void add_cat_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newCategory.Title = Title1.Text;
                newCategory.Description = Description.Text;
                newCategory.AddDate = DateTime.Now;

                //Entering the data into the database
                bool success = BllCategory.Add(newCategory);
                if (success)
                {
                    Response.Write("<script>alert('Add is successful');</script>");
                    clear();
                }

                reloadPage();
            }
            
        }

        protected void update_cat_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newCategory.ID = Convert.ToInt32(CategoryID.Text);
                newCategory.Title = Title1.Text;
                newCategory.Description = Description.Text;
                newCategory.AddDate = DateTime.Now;

                //Update the data in the database
                bool success = BllCategory.Update(newCategory);
                if (success)
                {
                    Response.Write("<script>alert('update is successful');</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('update didnt work');</script>");
                }
                reloadPage();
            }   
        }
        protected void clear()
        {
            CategoryID.Text = "";
            Title1.Text = "";
            Description.Text = "";

        }

        protected void DataOut_Load(object sender, EventArgs e)
        {
            reloadPage();
        }

        protected void reloadPage()
        {
            //select all data from database
            DataTable dt = BllCategory.Select();
            DataOut.DataSource = dt;
            DataOut.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CategoryID.Text = DataOut.Rows[gr].Cells[2].Text;
            Title1.Text = DataOut.Rows[gr].Cells[3].Text;
            Description.Text = DataOut.Rows[gr].Cells[4].Text;
            add_cat.Enabled = false;
            update_cat.Enabled = true;
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            newCategory.ID = Convert.ToInt32(DataOut.Rows[gr].Cells[2].Text.ToString());

            //Delete from database
            bool success = BllCategory.Delete(newCategory);
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

        protected void Clear_Click(object sender, EventArgs e)
        {
            clear();
            add_cat.Enabled = true;
            update_cat.Enabled = false;
        }
    }
}
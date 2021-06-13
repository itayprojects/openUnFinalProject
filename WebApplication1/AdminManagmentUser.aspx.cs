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
    public partial class AdminManagmentUser : System.Web.UI.Page
    {
        User newUser;
        IBLL_User BllUser;

        public AdminManagmentUser()
        {
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                reloadPage();
                if (String.IsNullOrEmpty(UserID.Text))
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                DataTable dt = BllUser.Search(Email.Text.ToString());
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#emailConfirm').modal();", true);
                }
                else
                {
                    newUser.FirstName = FirstName.Text;
                    newUser.LasttName = LastName.Text;
                    newUser.Email = Email.Text;
                    newUser.Password = Password.Text;
                    newUser.Phone = Phone.Text;
                    newUser.Address = Address.Text;
                    newUser.BuisnessWorker = false;
                    newUser.AddDate = DateTime.Now;

                    //Entering the data into the database
                    bool success = BllUser.Add(newUser);
                    if (success)
                    {
                        Response.Write("<script>alert('Add is successful');</script>");
                        clear();
                    }
                    else
                    {
                        Response.Write("<script>alert('Add didnt work');</script>");
                    }
                }
                
                reloadPage();
            }
            
        }

        private void clear()
        {
            UserID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Email.Text = "";
            Password.Text = "";
            Address.Text = "";
            

        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            newUser.ID = Convert.ToInt32(DataOut.Rows[gr].Cells[2].Text.ToString());

            //Delete from database
            bool success = BllUser.Delete(newUser);
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            
            UserID.Text = DataOut.Rows[gr].Cells[2].Text;
            FirstName.Text = DataOut.Rows[gr].Cells[3].Text;
            LastName.Text = DataOut.Rows[gr].Cells[4].Text;
            Email.Text = DataOut.Rows[gr].Cells[5].Text;
            Password.Text = DataOut.Rows[gr].Cells[6].Text;
            Phone.Text = DataOut.Rows[gr].Cells[7].Text;
            Address.Text = DataOut.Rows[gr].Cells[8].Text;
            

            btn_add.Enabled = false;
            btn_update.Enabled = true;
        }

        protected void DataOut_Load(object sender, EventArgs e)
        {
            reloadPage();
        }
        protected void reloadPage()
        {
            //select all data from database
            DataTable dt = BllUser.Select();
            DataOut.DataSource = dt;
            DataOut.DataBind();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                DataTable dt = BllUser.Search(Email.Text.ToString());
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#emailConfirm').modal();", true);
                }
                else
                {
                    newUser.ID = Convert.ToInt32(UserID.Text);
                    newUser.FirstName = FirstName.Text;
                    newUser.LasttName = LastName.Text;
                    newUser.Email = Email.Text;
                    newUser.Password = Password.Text;
                    newUser.Phone = Phone.Text;
                    newUser.Address = Address.Text;
                    newUser.BuisnessWorker = false;
                    newUser.AddDate = DateTime.Now;

                    //Update the data in the database
                    bool success = BllUser.Update(newUser);
                    if (success)
                    {
                        Response.Write("<script>alert('update successful');</script>");
                        clear();
                    }
                    else
                    {
                        Response.Write("<script>alert('update didnt work');</script>");
                    }
                }
                

                reloadPage();
            }
             
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            clear();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
        }
    }
}
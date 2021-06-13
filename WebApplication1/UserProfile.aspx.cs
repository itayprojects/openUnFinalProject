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
    public partial class WebForm2 : System.Web.UI.Page
    {
        User newUser;
        IBLL_User BllUser;
        string pass;

        IBLL_PurchaseDetails BllPurchase;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                setUserData();
                setUserPurchase();
            }
            
        }
        public WebForm2()
        {
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();

            BllPurchase = FactoryBLL_User.GetBllPurchase();
        }

        protected void setUserData()
        {
            DataTable dt;
            //search user by ID in data
            dt = BllUser.SearchById(Session["UserID"].ToString());

            FirstName.Text= dt.Rows[0]["First_Name"].ToString();
            LastName.Text= dt.Rows[0]["Last_Name"].ToString();
            Email.Text= dt.Rows[0]["Email"].ToString();
            Phone.Text= dt.Rows[0]["Phone"].ToString();
            Address.Text= dt.Rows[0]["Address"].ToString();
            pass = dt.Rows[0]["Password"].ToString();

        }

        protected void setUserPurchase()
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM[PurchaseDetails] WHERE [ID_User]=" + Session["UserID"].ToString();

        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            ////retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string orderNo=DataOut.Rows[gr].Cells[1].Text;
            Session["orderId"] = null;
            Session["orderId"] = orderNo;
            billFrame.Src = "PdfGenerator.aspx";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#billpage').modal();", true);
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            
            User updateUser;
            //get user by ID from data to object
            updateUser = BllUser.FromIdToObject(Session["UserID"].ToString()) as User;

            if (ChangePass.Visible)
            {
                //check if enterd password is the same as in the database 
                if (updateUser.Password.Equals(oldPass.Text.ToString()))
                {
                    updateUser.Password = Password.Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#passModal').modal();", true);
                    return;
                }
            }
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
                    updateUser.FirstName = FirstName.Text;
                    updateUser.LasttName = LastName.Text;
                    updateUser.Email = Email.Text;
                    updateUser.Phone = Phone.Text;
                    updateUser.Address = Address.Text;
                    updateUser.BuisnessWorker = false;
                    updateUser.AddDate = DateTime.Now;

                    //Update the data in the database  
                    bool success = BllUser.Update(updateUser);
                    if (success)
                    {
                        Response.Write("<script>alert('update successful');</script>");
                        Session["Name"] = FirstName.Text;
                    }
                    else
                    {
                        Response.Write("<script>alert('update didnt work');</script>");
                    }
                }
                
            }
        }

        protected void btn_pass_Click(object sender, EventArgs e)
        {
            if (ChangePass.Visible)
            {
                ChangePass.Visible = false;
            }
            else
            {
                ChangePass.Visible = true;
            }
        }
    }
}
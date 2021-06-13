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
    public partial class LoginAdmin : System.Web.UI.Page
    {
        User newUser;
        IBLL_User BllUser;

        public LoginAdmin()
        {
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(Email.Text) || String.IsNullOrEmpty(userPass.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#emailConfirm').modal();", true);
            }
            else
            {
                newUser.Email = Email.Text.Trim();
                newUser.Password = userPass.Text;
                //Check if the data matches the database
                bool success = BllUser.LoginCheck(newUser);
                if (success)
                {
                    Response.Write("<script>alert('please enter');</script>");
                    DataTable dt = BllUser.Search(Email.Text);
                    //update Session of user name and Type and ID
                    Session["BuisnessWorker"] = dt.Rows[0]["BuisnessWorker"].ToString();
                    Session["UserID"] = dt.Rows[0]["Id"].ToString();
                    Session["Name"] = dt.Rows[0]["First_Name"].ToString();

                    if (Session["fotterMaster"] != null)
                    {
                        Response.Redirect("Cart.aspx");
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#emailConfirm').modal();", true);
                    clear();
                }
            }
            
        }
        private void clear()
        {
            Email.Text = "";
            userPass.Text = "";
        }
    }
}
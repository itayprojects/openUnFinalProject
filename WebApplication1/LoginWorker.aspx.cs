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
    public partial class LoginWorker : System.Web.UI.Page
    {
        Worker newWorker;
        IBLL_User BllWorker;

        public LoginWorker()
        {
            newWorker = new Worker();
            BllWorker = FactoryBLL_User.GetBllWorker();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PersonalID.Text) || String.IsNullOrEmpty(userPass.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#workerConfirm').modal();", true);
            }
            else
            {
                newWorker.PersonalID = Convert.ToInt32(PersonalID.Text.Trim().ToString());
                newWorker.Password = userPass.Text.ToString();
                //Check if the data matches the database
                bool success = BllWorker.LoginCheck(newWorker);
                if (success)
                {
                    Response.Write("<script>alert('please enter');</script>");
                    DataTable dt = BllWorker.Search(PersonalID.Text);
                    //update Session of user name and Type
                    Session["BuisnessWorker"] = dt.Rows[0]["BuisnessWorker"].ToString();
                    Session["Name"] = dt.Rows[0]["First_Name"].ToString();
                    string[] AddressList = dt.Rows[0]["Authorizations"].ToString().Trim().Split(',');

                    foreach (string Authoriz in AddressList)
                    {
                        Session[Authoriz] = "true";
                    }

                    clear();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#workerConfirm').modal();", true);
                    clear();
                }
            }
            
        }
        private void clear()
        {
            PersonalID.Text = "";
            userPass.Text = "";
        }
    }
}
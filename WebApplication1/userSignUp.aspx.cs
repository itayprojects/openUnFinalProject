using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class userSignUp : System.Web.UI.Page
    {
        User newUser;
        IBLL_User BllUser;

        IBLL_StoreSet newSet;

        public userSignUp()
        {
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();

            newSet = FactoryBLL_User.GetBllStoreSet();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Button_sign_up_Click(object sender, EventArgs e)
        {
            //validated data
            if (IsValid)
            {
                //check if email all ready registerd
                DataTable dt = BllUser.Search(Email.Text.ToString());

                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#emailConfirm').modal();", true);
                }

                else//Enter validated data and insert it to the object
                {
                    newUser.FirstName = FirstName.Text;
                    newUser.LasttName = LastName.Text;
                    newUser.Email = Email.Text;
                    newUser.Password = Password.Text;
                    newUser.Phone = Phone.Text;
                    newUser.Address = Address.Text;
                    newUser.BuisnessWorker = false;
                    newUser.AddDate = DateTime.Now;



                    ////Entering the data into the database
                    bool success = BllUser.Add(newUser);
                    if (success)
                    {
                        Response.Write("<script>alert('Add is successful');</script>");
                        dt = BllUser.Search(Email.Text);

                        //update session to user
                        Session["BuisnessWorker"] = dt.Rows[0]["BuisnessWorker"].ToString();
                        Session["UserID"] = dt.Rows[0]["Id"].ToString();
                        Session["Name"] = FirstName.Text.ToString();
                        //send email to new user
                        newSet.SendEmail(Email.Text.ToString(), Password.Text.ToString());
                        clear();

                        if (Session["fotterMaster"] != null)
                        {
                            Response.Redirect("Cart.aspx");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Add didnt work');</script>");
                    }
                }
            }

            
        }
        
        private void clear()
        {

            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            Address.Text = "";


        }
    }
}
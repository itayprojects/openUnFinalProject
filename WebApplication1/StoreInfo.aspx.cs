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
    public partial class StoreInfo : System.Web.UI.Page
    {
        StoreSet newStore;
        IBLL_StoreSet BllStore;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                setStoreData();

            }
        }
        public StoreInfo()
        {
            newStore = new StoreSet();
            BllStore = FactoryBLL_User.GetBllStoreSet();
        }

        protected void setStoreData()
        {
            DataTable dt;
            dt = BllStore.Select();

            if (dt!= null)
            {
                btn_update.Visible = true;
                btn_Add.Visible = false;

                

                StoreName.Text = dt.Rows[0]["Name"].ToString();
                Phone.Text = dt.Rows[0]["Phone"].ToString();
                Address.Text = dt.Rows[0]["Address"].ToString();
                Email.Text = dt.Rows[0]["Email"].ToString();
                EmailAcssess.Text = dt.Rows[0]["EmailConfig"].ToString();
                FaceBook.Text = dt.Rows[0]["Facebook"].ToString();
                Instagram.Text = dt.Rows[0]["Instegram"].ToString();
                Twitter.Text = dt.Rows[0]["Twitter"].ToString();

                Session["storeId"] = 1;
                Session["StoreName"] = StoreName.Text;
                Session["StorePhone"] = Phone.Text;
                Session["StoreAddress"] = Address.Text;
                Session["StoreEmail"] = Email.Text;
                Session["StoreEmailAcssess"] = EmailAcssess.Text;
                Session["FaceBook"] = FaceBook.Text;
                Session["Instagram"] = Instagram.Text;
                Session["Twitter"] = Twitter.Text;
            }
            else
            {
                btn_update.Visible = false;
                btn_Add.Visible = true;
            }




        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newStore.Name = StoreName.Text;
                newStore.Phone = Phone.Text;
                newStore.Address = Address.Text;
                newStore.Email = Email.Text;
                newStore.EmailConfig = EmailAcssess.Text;
                newStore.Facebook = FaceBook.Text;
                newStore.Instegram = Instagram.Text;
                newStore.Twitter = Twitter.Text;

                //Update the data in the database
                bool success = BllStore.Update(newStore);

                if (success)
                {
                    Session["storeId"] = 1;
                    Session["StoreName"] = StoreName.Text;
                    Session["StorePhone"] = Phone.Text;
                    Session["StoreAddress"] = Address.Text;
                    Session["StoreEmail"] = Email.Text;
                    Session["StoreEmailAcssess"] = EmailAcssess.Text;
                    Session["FaceBook"] = FaceBook.Text;
                    Session["Instagram"] = Instagram.Text;
                    Session["Twitter"] = Twitter.Text;


                    Response.Redirect("Home.aspx");

                }
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newStore.Name = StoreName.Text;
                newStore.Phone = Phone.Text;
                newStore.Address = Address.Text;
                newStore.Email = Email.Text;
                newStore.EmailConfig = EmailAcssess.Text;
                newStore.Facebook = FaceBook.Text;
                newStore.Instegram = Instagram.Text;
                newStore.Twitter = Twitter.Text;

                //Entering the data into the database
                bool success = BllStore.Add(newStore);

                if (success)
                {
                    //update Sessions
                    Session["storeId"] = 1;
                    Session["StoreName"] = StoreName.Text;
                    Session["StorePhone"] = Phone.Text;
                    Session["StoreAddress"] = Address.Text;
                    Session["StoreEmail"] = Email.Text;
                    Session["StoreEmailAcssess"] = EmailAcssess.Text;
                    Session["FaceBook"] = FaceBook.Text;
                    Session["Instagram"] = Instagram.Text;
                    Session["Twitter"] = Twitter.Text;


                    Response.Redirect("Home.aspx");

                }
            }
        }
    }
}
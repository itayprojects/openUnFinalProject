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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        IBLL BllStore;
        public Site1()
        {
            BllStore = FactoryBLL_User.GetBllStoreSet();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StoreSetting();
            FooterControl();
            btn_on_off();

            if (Session["itemInLisr"]!=null)
            {
                Label2.Visible = true;
                Label2.Text = "("+TotalProductCount().ToString()+")";
            }
            else
            {
                Label2.Visible = false;
            }
            
        }

        protected void StoreSetting()
        {
            DataTable dt;
            dt = BllStore.Select();

            if (dt != null)
            {
                Session["storeId"] = 1;
                Session["StoreName"] = dt.Rows[0]["Name"].ToString();
                Session["StorePhone"] = dt.Rows[0]["Phone"].ToString();
                Session["StoreAddress"] = dt.Rows[0]["Address"].ToString();
                Session["StoreEmail"] = dt.Rows[0]["Email"].ToString();
                Session["StoreEmailAcssess"] = dt.Rows[0]["EmailConfig"].ToString();
                Session["FaceBook"] = dt.Rows[0]["Facebook"].ToString();
                Session["Instagram"] = dt.Rows[0]["Instegram"].ToString();
                Session["Twitter"] = dt.Rows[0]["Twitter"].ToString();

                storeName.Text = Session["StoreName"].ToString();
            }
            
        }

        protected void LinkButtonCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginUser.aspx");
        }

        protected void LinkButtonSign_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignUp.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["BuisnessWorker"] = null;
            Session["Name"] = null;
            Session["UserID"] = null;
            Session["Category Manage"] = null;
            Session["User Manage"] = null;
            Session["Purchase Manage"] = null;
            Session["Worker Manage"] = null;
            Session["DataAnalyst Manage"] = null;
            btn_on_off();
            Response.Redirect("Home.aspx");
        }

        protected void LinkButtonUser_Click(object sender, EventArgs e)
        {
           
                Response.Redirect("UserProfile.aspx");
        }

        protected void admin_cat_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagmentCategory.aspx");
        }

        protected void admin_user_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagmentUser.aspx");
        }

        protected void admin_product_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagmentProduct.aspx");
        }

        protected void admin_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void btn_on_off()
        {
            try
            {

                if (Session["BuisnessWorker"] == null || Session["BuisnessWorker"].ToString().Equals(""))
                {
                    LinkButtonLogin.Visible = true;
                    LinkButtonSign.Visible = true;
                    LinkButtonLogout.Visible = false;
                    navbarDropdown.Visible = false;
                   
                    
                    LinkButtonUser.Visible = false;
                }
                else if (Session["BuisnessWorker"].ToString().Equals("0"))
                {
                    LinkButtonLogin.Visible = false;
                    LinkButtonSign.Visible = false;
                    LinkButtonLogout.Visible = true;
                    navbarDropdown.Visible = false;
                    
                    
                    LinkButtonUser.Visible = true;
                    LinkButtonUser.Text = "Hello " + Session["Name"].ToString();
                }
                else
                {
                    LinkButtonLogin.Visible = false;
                    LinkButtonSign.Visible = false;
                    LinkButtonCart.Visible = false;
                    LinkButtonLogout.Visible = true;
                    LinkButtonUser.Enabled = false;
                    LinkButtonUser.CssClass = "nav-link";
                    navbarDropdown.Visible = true; ;

                    ManageControl();
                    
                    LinkButtonUser.Visible = true;
                    LinkButtonUser.Text = "Hello " + Session["Name"].ToString();

                    
                    
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ManageControl()
        {
            if (Session["Category Manage"] != null)
            {
                admin_cat.Visible = true;
            }
            else
            {
                admin_cat.Visible = false;
            }
            if (Session["User Manage"] != null)
            {
                admin_user.Visible = true;
            }
            else
            {
                admin_user.Visible = false;
            }
            if (Session["Purchase Manage"] != null)
            {
                admin_purchase.Visible = true;
            }
            else
            {
                admin_purchase.Visible = false;
            }
            if (Session["Worker Manage"] != null)
            {
                admin_worker.Visible = true;
            }
            else
            {
                admin_worker.Visible = false;
            }
            if (Session["DataAnalyst Manage"] != null)
            {
                admin_data.Visible = true;
            }
            else
            {
                admin_data.Visible = false;
            }
            if (Session["Product Manage"] != null)
            {
                admin_product.Visible = true;
            }
            else
            {
                admin_product.Visible = false;
            }
            if (Session["Store Manage"] != null)
            {
                admin_store.Visible = true;
            }
            else
            {
                admin_store.Visible = false;
            }
        }

        protected void FooterControl()
        {

            if (Session["StorePhone"] != null)
            {
                phone_control.Text = "Phone : " + Session["StorePhone"].ToString();
                phone_control.Visible = true;
            }
            else
            {
                phone_control.Visible = false;
            }

            if (Session["StoreAddress"] != null)
            {
                adress_control.Text = "Address : " + Session["StoreAddress"].ToString();
                adress_control.Visible = true;
            }
            else
            {
                adress_control.Visible = false;
            }

            if (Session["StoreEmail"] != null)
            {
                email_control.Text = "E-mail : " + Session["StoreEmail"].ToString();
                email_control.Visible = true;
            }
            else
            {
                email_control.Visible = false;
            }

            /*------------------------------------*/
            if (!string.IsNullOrEmpty(Session["FaceBook"].ToString()))
            {
                facebook.Visible = true;
            }
            else
            {
                facebook.Visible = false;
            }
            if (!string.IsNullOrEmpty(Session["Instagram"].ToString()))
            {
                instagram.Visible = true;
            }
            else
            {
                instagram.Visible = false;
            }
            if (!string.IsNullOrEmpty(Session["Twitter"].ToString()))
            {
                twitter.Visible = true;
            }
            else
            {
                twitter.Visible = false;
            }

        }


        protected int TotalProductCount()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["itemInLisr"];
            int i = 0, rows_in_data = dt.Rows.Count;
            int Total = 0;
            while (i < rows_in_data)
            {
                Total = Total + Convert.ToInt32(dt.Rows[i]["Pquantity"].ToString());
                i++;
            }
            return Total;
        }

        protected void admin_purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagmentPurchaseDetails.aspx");
        }

        protected void admin_worker_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagmentWworkers.aspx");
        }

        protected void admin_data_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataAnalyst.aspx");
        }

        protected void admin_store_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreInfo.aspx");
        }

        protected void facebook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Session["FaceBook"].ToString());
        }

        protected void instagram_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Session["Instagram"].ToString());
        }

        protected void twitter_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Session["Twitter"].ToString());
        }
    }
}
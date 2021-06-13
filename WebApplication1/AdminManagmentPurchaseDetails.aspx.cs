using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminManagmentPurchaseDetails : System.Web.UI.Page
    {
        PurchaseDetails newPurchase, updatePurchase;
        IBLL_PurchaseDetails BllPurchase;
        IBLL_User BllUser;

        public AdminManagmentPurchaseDetails()
        {
            newPurchase = new PurchaseDetails();
            BllPurchase = FactoryBLL_User.GetBllPurchase();

            BllUser = FactoryBLL_User.GetBllUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            DataTable dt, ut;
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            //get data by ID
            dt = BllPurchase.SearchById(DataOut.Rows[gr].Cells[1].Text);


            OrderID.Text = dt.Rows[0]["OrderID"].ToString();
            PurchaseDate.Text =Convert.ToDateTime( dt.Rows[0]["Purchase_Time"]).ToString("d");
            GrandTotal.Text = dt.Rows[0]["Grand_Total"].ToString();
            UserID.Text = dt.Rows[0]["ID_User"].ToString();
            CardNumber.Text = dt.Rows[0]["CardNumber"].ToString();
            CardExpirationDate.Text = dt.Rows[0]["CardExpirationDate"].ToString();
            CVV.Text = dt.Rows[0]["CVV"].ToString();
            RadioOrderComplete.SelectedValue = dt.Rows[0]["PurchaseComplete"].ToString();
            ut = BllUser.SearchById(dt.Rows[0]["ID_User"].ToString());
            UserName.Text = ut.Rows[0]["First_Name"].ToString() + " " + ut.Rows[0]["Last_Name"].ToString();
        }

        protected void btnShowBill_Click(object sender, EventArgs e)
        {
            Session["orderId"] = null;
            if (!String.IsNullOrEmpty(OrderID.Text))
            {
                Session["orderId"] = OrderID.Text.ToString();
                billFrame.Src = "PdfGenerator.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#billpage').modal();", true);
                
            }
            else
            {
                Response.Write("<script>alert('You didnt choose');</script>");
            }


             

        }

        protected void DataOut_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string aa;
            if (e.Row.RowIndex >= 0)
            {
                aa= e.Row.Cells[8].Text;
                if (Convert.ToBoolean(e.Row.Cells[8].Text))
                {
                    e.Row.Cells[8].CssClass= "table-dark bg-success ";
                }
                else
                {
                    e.Row.Cells[8].CssClass = "table-dark bg-danger";
                }
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Session["orderId"] = null;
            billFrame.Src = "";
            if (!String.IsNullOrEmpty(OrderID.Text))
            {
                //get object by ID from Data
                updatePurchase = BllPurchase.FromIdToObject(OrderID.Text) as PurchaseDetails;
                //update if Purchase Complete
                updatePurchase.PurchaseComplete = Convert.ToBoolean(RadioOrderComplete.SelectedValue.ToString());
                //Update the data in the database
                bool success = BllPurchase.Update(updatePurchase);
                if (!success)
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                    //clear();

                }
                DataOut.DataBind();
            }
            else
            {
                Response.Write("<script>alert('You didnt choose');</script>");
            }
        }
    }
}
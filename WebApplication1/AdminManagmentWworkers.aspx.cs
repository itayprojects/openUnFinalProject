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
    public partial class AdminManagmentWworkers : System.Web.UI.Page
    {
        Worker newWorker;
        IBLL_User BllWorker;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Disable Unobtrusive Validation Mode
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                reloadPage();
                if (String.IsNullOrEmpty(WorkerID.Text))
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

        public AdminManagmentWworkers()
        {
            newWorker = new Worker();
            BllWorker = FactoryBLL_User.GetBllWorker();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it to the object
            if (IsValid)
            {
                newWorker.PersonalID = Convert.ToInt32(PersonalID.Text);
                newWorker.FirstName = FirstName.Text;
                newWorker.LasttName = LastName.Text;
                newWorker.Password = Password.Text;
                newWorker.Phone = Phone.Text;
                newWorker.Address = Address.Text;
                newWorker.BuisnessWorker = true;
                newWorker.AddDate = DateTime.Now;


                //Enter all Authorization as a list
                newWorker.Authorization = AuthorizationToString().ToString();

                //Entering the data into the database
                bool success = BllWorker.Add(newWorker);
                if (success)
                {
                    Response.Write("<script>alert('Add is successful');</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('Add didnt work');</script>");
                }
                DataTable dt = BllWorker.Select();
                DataOut.DataSource = dt;
                DataOut.DataBind();
            }
            
        }

        private void clear()
        {
            WorkerID.Text = "";
            PersonalID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Password.Text = "";
            Address.Text = "";
            Authorization.ClearSelection();

        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            newWorker.ID = Convert.ToInt32(DataOut.Rows[gr].Cells[2].Text.ToString());

            ////Delete from database
            bool success = BllWorker.Delete(newWorker);
            if (success)
            {
                Response.Write("<script>alert('delete successful');</script>");
                clear();
            }
            else
            {
                Response.Write("<script>alert('delete didnt work');</script>");
            }
            DataTable dt = BllWorker.Select();
            DataOut.DataSource = dt;
            DataOut.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            DataTable dt;
            //retrieve a row index from gridview
            int gr = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            dt = BllWorker.SearchById(DataOut.Rows[gr].Cells[2].Text);
            
            WorkerID.Text = dt.Rows[0]["Id"].ToString();
            PersonalID.Text = dt.Rows[0]["PersonalID"].ToString();
            FirstName.Text = dt.Rows[0]["First_Name"].ToString();
            LastName.Text = dt.Rows[0]["Last_Name"].ToString();
            Password.Text = dt.Rows[0]["Password"].ToString();
            Phone.Text = dt.Rows[0]["Phone"].ToString();
            Address.Text = dt.Rows[0]["Address"].ToString();

            //Inserting a word string into a word set
            string[] AddressList= dt.Rows[0]["Authorizations"].ToString().Trim().Split(',');

            //Selecting Authorization according to the string
            foreach (ListItem item in Authorization.Items)
            {
                item.Selected = false;
                foreach (string valu in AddressList)
                {
                    if (item.Value.ToString().Equals(valu))
                    {
                        item.Selected = true;
                    }
                }
            }
            

            btn_add.Enabled = false;
            btn_update.Enabled = true;
        }

        protected void DataOut_Load(object sender, EventArgs e)
        {
            reloadPage();
        }
        protected void reloadPage()
        {
            DataTable dt = BllWorker.Select();
            DataOut.DataSource = dt;
            DataOut.DataBind();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //Enter validated data and insert it into the object
            if (IsValid)
            {
                newWorker.ID = Convert.ToInt32(WorkerID.Text);
                newWorker.PersonalID = Convert.ToInt32(PersonalID.Text);
                newWorker.FirstName = FirstName.Text;
                newWorker.LasttName = LastName.Text;
                newWorker.Password = Password.Text;
                newWorker.Phone = Phone.Text;
                newWorker.Address = Address.Text;
                newWorker.BuisnessWorker = true;
                newWorker.Authorization = AuthorizationToString();
                newWorker.AddDate = DateTime.Now;

                //Update the data in the database
                bool success = BllWorker.Update(newWorker);
                if (success)
                {
                    Response.Write("<script>alert('update successful');</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('update didnt work');</script>");
                }
                DataTable dt = BllWorker.Select();
                DataOut.DataSource = dt;
                DataOut.DataBind();
            }
            
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            clear();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
        }

        /*
         Turning ListItem into a string
         */
        protected string AuthorizationToString()
        {
            string AuthorizationList = string.Empty;

            foreach (ListItem item in Authorization.Items)
            {
                if (item.Selected == true)
                {
                    AuthorizationList += string.Format("{0},", item.Text);
                }
            }
            if (!string.IsNullOrEmpty(AuthorizationList))
            {
                AuthorizationList = AuthorizationList.Remove(AuthorizationList.Length - 1);
            }
            

            return AuthorizationList;

        }


    }
}
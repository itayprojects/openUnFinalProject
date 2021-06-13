using BE;
using BLL;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PdfGenerator : System.Web.UI.Page
    {
        Orders newOrder;
        IBLL BllOrder;

        PurchaseDetails newPurchase;
        IBLL BllPurchase;

        IBLL_User BllUser;

        DataTable dt;

        public PdfGenerator()
        {
            newOrder = new Orders();
            BllOrder = FactoryBLL_User.GetBllOrder();

            newPurchase = new PurchaseDetails();
            BllPurchase = FactoryBLL_User.GetBllPurchase();

            BllUser = FactoryBLL_User.GetBllUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderId;
            if (Session["storeId"] != null)
            {
                storeName.Text = Session["StoreName"].ToString();
                storeAdd.Text = Session["StoreAddress"].ToString();
                storePhone.Text = Session["StorePhone"].ToString();
                storeEmail.Text = Session["StoreEmail"].ToString();
            }
            try
            {
                orderId = Session["orderId"].ToString();
                fillUserAndOrderDetails(orderId);
                fillOrderDetails(orderId);
            }
            catch (Exception ex)
            {

                throw new Exception($"PDF can't be generated\n inner exception : " + ex.Message);
            }
            
        }
        protected void fillUserAndOrderDetails(string orderId)
        {
            DataTable ud;
            //Search Purchase By Id in the database
            dt = BllPurchase.SearchById(orderId);
            orderIdText.Text = orderId;
            billDate.Text = dt.Rows[0]["Purchase_Time"].ToString();
            ud = BllUser.SearchById(dt.Rows[0]["ID_User"].ToString());
            userName.Text = ud.Rows[0]["First_Name"].ToString() + " " + ud.Rows[0]["Last_Name"].ToString();
            address.Text = ud.Rows[0]["Address"].ToString();
            phone.Text= ud.Rows[0]["Phone"].ToString();

        }
        protected void fillOrderDetails(string orderId)
        {
            DataTable newdata = new DataTable();
            DataRow dr;
            int totalRow, quantity;
            double price,totalPrice, grandTotal = 0;


            //add new table
            newdata.Columns.Add("sno");
            newdata.Columns.Add("Pid");
            newdata.Columns.Add("Pname");
            newdata.Columns.Add("Pprice");
            newdata.Columns.Add("Pquantity");
            newdata.Columns.Add("Ptotal");

            //Search Order By Id in the database
            dt = BllOrder.SearchById(orderId);
            totalRow = dt.Rows.Count;

            //insert data to the table
            for (int i = 0; i < totalRow; i++)
            {
                dr = newdata.NewRow();

                dr["sno"]=i+1;
                dr["Pid"]= dt.Rows[i]["ProductId"].ToString();
                dr["Pname"]= dt.Rows[i]["ProductName"].ToString();
                quantity= Convert.ToInt32( dt.Rows[i]["Quantity"].ToString());
                price = Convert.ToDouble(dt.Rows[i]["Price"].ToString());
                dr["Pprice"]= price;
                dr["Pquantity"]= quantity;
                totalPrice = price * quantity;
                dr["Ptotal"]= totalPrice;

                grandTotal = grandTotal + totalPrice;

                newdata.Rows.Add(dr);
            }
            showBillDetail.DataSource = newdata;
            showBillDetail.DataBind();
            showBillDetail.FooterRow.Cells[4].Text = "Total:";
            showBillDetail.FooterRow.Cells[4].CssClass = "text-right";
            showBillDetail.FooterRow.Cells[5].Text = grandTotal.ToString();
            showBillDetail.FooterRow.Cells[5].CssClass = "text-right";


        }

        [Obsolete]
        protected void pdfOut_Click(object sender, EventArgs e)
        {
            generatePdf();
        }

        [Obsolete]
        private void generatePdf()
        {
            try
            {
                Response.ContentType = "application/pdf";
                //add file name
                Response.AddHeader("content-disposition", "attachment;filename=ReceiptOrder.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                //stores tracing information about the control
                panelToPdf.RenderControl(htw);
                StringReader sr = new StringReader(sw.ToString());
                //create page
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                //convert html page to pdf
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {

                throw new Exception($"Runtime error in generatePdf method\n inner exception : " + ex.Message);
            }
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }
    }
}
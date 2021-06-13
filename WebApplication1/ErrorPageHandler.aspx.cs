using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ErrorPageHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get exeption
            Exception ex = Server.GetLastError().GetBaseException();
            //get StackTrace of exeption
            var frame = new StackTrace(ex, true).GetFrame(0);
            var sourceFile = frame.GetFileName();
            var lineNumber = frame.GetFileLineNumber();

            //Check if it's a manager or a user
            if (Session["BuisnessWorker"] == null || Session["BuisnessWorker"].ToString().Equals("")|| Session["BuisnessWorker"].ToString().Equals("0"))
            {
                WorkerEx.Visible = false;
                UserEx.Visible = true;
            }
            else
            {
                //exeption details
                UserEx.Visible = false;
                WorkerEx.Visible = true;
                ErrFile.Text = sourceFile;
                ErrLine.Text = lineNumber.ToString();
                ErrMessage.Text = ex.Message;
                ErrStac.Text = ex.StackTrace;
            }
            Server.ClearError();
            
        }
    }
}
using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL_PurchaseDetails: IBLL
    {
        DataTable SelectByDate(DateTime startDate, DateTime endDate);
        void SendEmail(string mailToSend, string orderID);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_Orders: IDAL_PurchaseDetails
    {
        DataTable SelectProductByDate(string startDate, string endDate, string ProductName);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL_Orders: IBLL
    {
        DataTable SelectByDate(DateTime startDate, DateTime endDate);
        DataTable SelectProductByDate(DateTime startDate, DateTime endDate, string ProductName);
    }
}

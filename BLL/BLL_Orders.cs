using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Orders : IBLL_Orders
    {
        IDAL_Orders newOrder;

        public BLL_Orders()
        {
            newOrder = FactoryDal.GetDalOrders();
        }

        public bool Add(object NewObject)
        {
            return newOrder.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string KeyWord)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchById(string id)
        {
            return newOrder.SearchById(id);
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(object NewObject)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectByDate(DateTime startDate, DateTime endDate)
        {
            return newOrder.SelectByDate(startDate.ToString("d"), endDate.ToString("d"));
        }
        public DataTable SelectProductByDate(DateTime startDate, DateTime endDate, string ProductName)
        {
            return newOrder.SelectProductByDate(startDate.ToString("d"), endDate.ToString("d"), ProductName);
        }

        public object FromIdToObject(string id)
        {
            throw new NotImplementedException();
        }
    }
}

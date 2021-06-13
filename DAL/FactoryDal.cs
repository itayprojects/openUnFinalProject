using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        public static IDAL_User GetDalUser()
        {
            return new DAL_User();
        }

        public static IDAL_User GetDalWorker()
        {
            return new DAL_Worker();
        }

        public static IDAL_DATABASE GetDalCategory()
        {
            return new DAL_Category();
        }

        public static IDAL_DATABASE GetDalProduct()
        {
            return new DAL_Product();
        }

        

        public static IDAL_Orders GetDalOrders()
        {
            return new DAL_Orders();
        }

        public static IDAL_PurchaseDetails GetPurchaseDetails()
        {
            return new DAL_PurchaseDetails();
        }

        public static IDAL_DATABASE GetStoreSet()
        {
            return new DAL_StoreSet();
        }
    }
}

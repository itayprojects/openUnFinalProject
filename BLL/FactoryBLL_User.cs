using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FactoryBLL_User
    {
        static IBLL_User user = null;
        static IBLL_User worker = null;
        static IBLL category = null;
        static IBLL_Product product = null;
        static IBLL_StoreSet storeSet = null;
        static IBLL_Orders order = null;
        static IBLL_PurchaseDetails Purchase = null;

        public static IBLL_User GetBllUser()
        {
            if (user==null)
            {
                user = new BLL_User();
            }

            return user;
        }

        public static IBLL_User GetBllWorker()
        {
            if (worker == null)
            {
                worker = new BLL_Worker();
            }

            return worker;
        }

        public static IBLL GetBllCategory()
        {
            if (category == null)
            {
                category = new BLL_Category();
            }

            return category;
        }

        public static IBLL_Product GetBllProduct()
        {
            if (product == null)
            {
                product = new BLL_Product();
            }

            return product;
        }

        public static IBLL_StoreSet GetBllStoreSet()
        {
            if (storeSet == null)
            {
                storeSet = new BLL_StoreSet();
            }

            return storeSet;
        }

        public static IBLL_Orders GetBllOrder()
        {
            if (order == null)
            {
                order = new BLL_Orders();
            }

            return order;
        }
        public static IBLL_PurchaseDetails GetBllPurchase()
        {
            if (Purchase == null)
            {
                Purchase = new BLL_PurchaseDetails();
            }

            return Purchase;
        }
    }
}

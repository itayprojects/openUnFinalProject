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
    public class BLL_Worker : IBLL_User
    {
        IDAL_User newWorker;

        public BLL_Worker()
        {
            newWorker = FactoryDal.GetDalWorker();
        }

        public DataTable Select()
        {
            return newWorker.Select();
        }

        public DataTable Search(string KeyWord)
        {
            return newWorker.Search(KeyWord);
        }

        public bool Add(object NewObject)
        {
            return newWorker.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            return newWorker.Delete(NewObject);
        }

        public bool Update(object NewObject)
        {
            return newWorker.Update(NewObject);
        }

        public DataTable SearchById(string id)
        {
            return newWorker.SearchById(id);
        }

        public bool LoginCheck(object NewObject)
        {
            return newWorker.LoginCheck(NewObject);
        }

        public object FromIdToObject(string id)
        {
            throw new NotImplementedException();
        }
    }
}

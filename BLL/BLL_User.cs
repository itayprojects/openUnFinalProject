using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_User : IBLL_User
    {
        IDAL_User newUser;

        public BLL_User()
        {
            newUser = FactoryDal.GetDalUser();
        }

        public DataTable Select()
        {
            return newUser.Select();
        }

        public DataTable Search(string KeyWord)
        {
            return newUser.Search(KeyWord);
        }

        public bool LoginCheck(object NewObject)
        {
            return newUser.LoginCheck(NewObject);
        }

        public bool Add(object NewObject)
        {
            return newUser.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            return newUser.Delete(NewObject);
        }

        public bool Update(object NewObject)
        {
            return newUser.Update(NewObject);
        }

        public DataTable SearchById(string id)
        {
            return newUser.SearchById(id);
        }

        public object FromIdToObject(string id)
        {
            return newUser.FromIdToObject(id);
        }
    }
}

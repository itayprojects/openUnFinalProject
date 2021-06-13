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
    public class BLL_Category : IBLL
    {
        IDAL_DATABASE newCategory;

        public BLL_Category()
        {
            newCategory = FactoryDal.GetDalCategory();
        }

        public bool Add(object NewObject)
        {
            return newCategory.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            return newCategory.Delete(NewObject);
        }

        public object FromIdToObject(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string KeyWord)
        {
            return newCategory.Search(KeyWord);
        }

        public DataTable SearchById(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            return newCategory.Select();
        }

        public bool Update(object NewObject)
        {
            return newCategory.Update(NewObject);
        }
    }
}

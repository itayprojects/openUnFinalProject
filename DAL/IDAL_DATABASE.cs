using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_DATABASE
    {
        bool Add(Object NewObject);
        bool Delete(Object NewObject);
        bool Update(Object NewObject);
        DataTable Select();
        DataTable Search(string KeyWord);
        DataTable SearchById(string id);
        object FromIdToObject(string id);
    }
}

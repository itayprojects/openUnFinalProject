using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_User : IDAL_DATABASE
    {
        bool LoginCheck(Object NewObject);
    }
}

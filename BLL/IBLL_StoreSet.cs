using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL_StoreSet:IBLL
    {
        void SendEmail(string mailToSend, string pass);
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_config
    {
        public static string MyConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;
        public string command { get; set; }
        public SqlConnection connect { get; set; }
        public SqlCommand cmd { get; set; }
        public SqlDataAdapter adapter { get; set; }
        public bool AddSuccess { get; set; }
    }
}

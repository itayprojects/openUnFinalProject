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
    public class BLL_Product : IBLL_Product
    {
        IDAL_DATABASE newProduct;

        public BLL_Product()
        {
            newProduct = FactoryDal.GetDalProduct();
        }

        public bool Add(object NewObject)
        {
            return newProduct.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            return newProduct.Delete(NewObject);
        }

        public DataTable Search(string KeyWord)
        {
            return newProduct.Search(KeyWord);
        }

        public DataTable SearchById(string id)
        {
            return newProduct.SearchById(id);
        }

        public DataTable ProductInventoryZero()
        {
            DataTable dt, ndt;
            DataRow dr;

            ndt = new DataTable();
            //get all product
            dt = newProduct.Select();
            //create table for all zero Quantity product
            ndt.Columns.Add("Pid");
            ndt.Columns.Add("Pname");

            dr = ndt.NewRow();
            //insert all zero Quantity product to the table
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Int32.Parse(dt.Rows[i]["Quantity"].ToString())==0)
                {
                    dr = ndt.NewRow();
                    dr["Pid"] = dt.Rows[i]["Id"];
                    dr["Pname"] = dt.Rows[i]["Name"].ToString();
                    ndt.Rows.Add(dr);
                }
                
            }

            return ndt;

        }

        public DataTable Select()
        {
            return newProduct.Select();
        }

        public bool Update(object NewObject)
        {
            return newProduct.Update(NewObject);
        }

        public object FromIdToObject(string id)
        {
            return newProduct.FromIdToObject(id);
        }
    }
}

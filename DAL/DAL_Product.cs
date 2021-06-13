using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Product : DAL_config,IDAL_DATABASE
    {
        #region Add
        public bool Add(object NewObject)
        {
            Product NewUser = (Product)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO Product (Name, Category, Description, Price, Quantity, Added_Date, Product_Img_Link) VALUES (@Name, @Category, @Description, @Price, @Quantity, @Added_Date ,@Product_Img_Link)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Name", NewUser.Name);
                cmd.Parameters.AddWithValue("@Category", NewUser.Category);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);
                cmd.Parameters.AddWithValue("@Product_Img_Link", NewUser.Product_Img_Link);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }
        #endregion

        #region Delete
        public bool Delete(object NewObject)
        {
            Product NewUser = (Product)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "DELETE FROM Product WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ID);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }
        #endregion

        #region Search
        public DataTable Search(string KeyWord)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Product WHERE Id LIKE '%" + KeyWord + "%' OR Name LIKE '%" + KeyWord + "%' OR Category LIKE '%" + KeyWord + "%'";
                cmd = new SqlCommand(command, connect);
                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }
        #endregion

        #region Select
        public DataTable Select()
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Product";
                cmd = new SqlCommand(command, connect);
                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }
        #endregion

        #region Update
        public bool Update(object NewObject)
        {
            Product NewUser = (Product)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE Product SET Name=@Name, Category=@Category, Description=@Description, Price=@Price, Quantity=@Quantity, Added_Date=@Added_Date, Product_Img_Link=@Product_Img_Link WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ID);
                cmd.Parameters.AddWithValue("@Name", NewUser.Name);
                cmd.Parameters.AddWithValue("@Category", NewUser.Category);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);
                cmd.Parameters.AddWithValue("@Product_Img_Link", NewUser.Product_Img_Link);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }
        #endregion

        #region Product By Id
        public DataTable SearchById(string id)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Product WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", id);

                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }
        #endregion

        #region From Id To Object
        public object FromIdToObject(string id)
        {
            Product selectProduct = new Product();
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Product WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", id);

                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);

                selectProduct.ID = Int32.Parse(dt.Rows[0]["Id"].ToString());
                selectProduct.Name = dt.Rows[0]["Name"].ToString();
                selectProduct.Category = dt.Rows[0]["Category"].ToString();
                selectProduct.Description = dt.Rows[0]["Description"].ToString();
                selectProduct.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                selectProduct.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                selectProduct.AddDate = DateTime.Now;
                selectProduct.Product_Img_Link = dt.Rows[0]["Product_Img_Link"].ToString();

            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return selectProduct;
        }
        #endregion
    }
}

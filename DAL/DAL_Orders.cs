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
    public class DAL_Orders : DAL_config,IDAL_Orders
    {
        #region Add
        public bool Add(object NewObject)
        {
            Orders NewOrder = (Orders)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO Orders (OrderID, ProductId, ProductName, Price, Quantity, Purchase_Time) VALUES (@OrderID, @ProductId, @ProductName, @Price, @Quantity, @Purchase_Time)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@OrderID", NewOrder.OrderID);
                cmd.Parameters.AddWithValue("@ProductId", NewOrder.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", NewOrder.ProductName);
                cmd.Parameters.AddWithValue("@Price", NewOrder.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewOrder.Quantity);
                cmd.Parameters.AddWithValue("@Purchase_Time", NewOrder.Purchase_Time);

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
            throw new NotImplementedException();
        }
        #endregion

        #region Order By Id
        public DataTable SearchById(string id)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Orders WHERE OrderID=@OrderID";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@OrderID", id);

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

        #region Search
        public DataTable Search(string KeyWord)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Select
        public DataTable Select()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(object NewObject)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Select By Date
        public DataTable SelectByDate(string startDate, string endDate)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT ProductName,SUM(Quantity) AS Total FROM Orders WHERE Purchase_Time BETWEEN CONVERT(datetime,@startDate,103) AND CONVERT(datetime,@endDate,103) GROUP BY ProductName  ";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

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

        #region Select Product By Date
        public DataTable SelectProductByDate(string startDate, string endDate, string ProductName)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT SUM(Quantity) AS Total,CAST(Purchase_Time AS DATE) AS Date FROM Orders WHERE Purchase_Time BETWEEN CONVERT(datetime,@startDate,103) AND CONVERT(datetime,@endDate,103) AND ProductName=@PName GROUP BY CAST(Purchase_Time AS DATE)  ";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@PName", ProductName);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
            throw new NotImplementedException();
        }
        #endregion
    }
}

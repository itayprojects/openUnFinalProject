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
    public class DAL_PurchaseDetails : DAL_config,IDAL_PurchaseDetails
    {
        #region Add
        public bool Add(Object NewObject)
        {
            PurchaseDetails NewPurchase = (PurchaseDetails)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO PurchaseDetails (ID_User, OrderID, Grand_Total, Purchase_Time, CardNumber, CardExpirationDate, CVV, PurchaseComplete) VALUES (@ID_User, @OrderID, @Grand_Total, @Purchase_Time, @CardNumber, @CardExpirationDate, @CVV, @PurchaseComplete)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@ID_User", NewPurchase.ID_User);
                cmd.Parameters.AddWithValue("@OrderID", NewPurchase.OrderID);
                cmd.Parameters.AddWithValue("@Grand_Total", NewPurchase.Grand_Total);
                cmd.Parameters.AddWithValue("@Purchase_Time", NewPurchase.Purchase_Time);
                cmd.Parameters.AddWithValue("@CardNumber", NewPurchase.CardNumber);
                cmd.Parameters.AddWithValue("@CardExpirationDate", NewPurchase.CardExpirationDate);
                cmd.Parameters.AddWithValue("@CVV", NewPurchase.CVV);
                cmd.Parameters.AddWithValue("@PurchaseComplete", NewPurchase.PurchaseComplete);

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

        #region Update
        public bool Update(Object NewObject)
        {
            PurchaseDetails NewPurchase = (PurchaseDetails)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE PurchaseDetails SET ID_User=@ID_User, Grand_Total=@Grand_Total, Purchase_Time=@Purchase_Time, CardNumber=@CardNumber, CardExpirationDate=@CardExpirationDate, CVV=@CVV, PurchaseComplete=@PurchaseComplete WHERE OrderID=@OrderID";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@ID_User", NewPurchase.ID_User);
                cmd.Parameters.AddWithValue("@OrderID", NewPurchase.OrderID);
                cmd.Parameters.AddWithValue("@Grand_Total", NewPurchase.Grand_Total);
                cmd.Parameters.AddWithValue("@Purchase_Time", NewPurchase.Purchase_Time);
                cmd.Parameters.AddWithValue("@CardNumber", NewPurchase.CardNumber);
                cmd.Parameters.AddWithValue("@CardExpirationDate", NewPurchase.CardExpirationDate);
                cmd.Parameters.AddWithValue("@CVV", NewPurchase.CVV);
                cmd.Parameters.AddWithValue("@PurchaseComplete", NewPurchase.PurchaseComplete);

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

        #region Select By Date
        public DataTable SelectByDate(string startDate, string endDate)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT SUM(Grand_Total) AS Total,CAST(Purchase_Time AS DATE) AS Date FROM PurchaseDetails WHERE Purchase_Time BETWEEN CONVERT(datetime,@startDate,103) AND CONVERT(datetime,@endDate,103) GROUP BY CAST(Purchase_Time AS DATE)";
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

        #region Order By Id
        public DataTable SearchById(string id)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM PurchaseDetails WHERE OrderID=@OrderID";
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

        #region From Id To Object
        public object FromIdToObject(string id)
        {
            PurchaseDetails selectPurchase = new PurchaseDetails();
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM PurchaseDetails WHERE OrderID=@OrderID";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@OrderID", id);

                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);

                selectPurchase.ID_User = Int32.Parse(dt.Rows[0]["ID_User"].ToString());
                selectPurchase.OrderID = dt.Rows[0]["OrderID"].ToString();
                selectPurchase.Grand_Total =Decimal.Parse( dt.Rows[0]["Grand_Total"].ToString());
                selectPurchase.Purchase_Time = DateTime.Parse( dt.Rows[0]["Purchase_Time"].ToString());
                selectPurchase.CardNumber = Int32.Parse(dt.Rows[0]["CardNumber"].ToString());
                selectPurchase.CardExpirationDate = dt.Rows[0]["CardExpirationDate"].ToString();
                selectPurchase.CVV = Int32.Parse(dt.Rows[0]["CVV"].ToString());
                selectPurchase.PurchaseComplete = Boolean.Parse( dt.Rows[0]["PurchaseComplete"].ToString());

            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return selectPurchase;
        }
        #endregion

    }
}

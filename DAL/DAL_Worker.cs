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
    public class DAL_Worker : DAL_config,IDAL_User
    {

        #region Select Worker
        public DataTable Select()
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Workers";
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

        #region Add Worker
        public bool Add(Object NewObject)
        {
            Worker NewWorker = (Worker)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO Workers (PersonalID, First_Name, Last_Name, Password, Phone, Address, BuisnessWorker, Authorizations, Added_Date) VALUES(@PersonalID, @First_Name, @Last_Name, @Password, @Phone, @Address, @BuisnessWorker, @Authorizations, @Added_Date)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@PersonalID", NewWorker.PersonalID);
                cmd.Parameters.AddWithValue("@First_Name", NewWorker.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewWorker.LasttName);
                cmd.Parameters.AddWithValue("@Password", NewWorker.Password);
                cmd.Parameters.AddWithValue("@Phone", NewWorker.Phone);
                cmd.Parameters.AddWithValue("@Address", NewWorker.Address);
                cmd.Parameters.AddWithValue("@BuisnessWorker", NewWorker.BuisnessWorker);
                cmd.Parameters.AddWithValue("@Authorizations", NewWorker.Authorization);
                cmd.Parameters.AddWithValue("@Added_Date", NewWorker.AddDate);

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

        #region Delete Worker
        public bool Delete(Object NewObject)
        {
            Worker NewWorker = (Worker)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "DELETE FROM Workers WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewWorker.ID);

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

        #region Update Worker
        public bool Update(Object NewObject)
        {
            Worker NewWorker = (Worker)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE Workers SET PersonalID=@PersonalID, First_Name=@First_Name, Last_Name=@Last_Name, Password=@Password, Phone=@Phone, Address=@Address, BuisnessWorker=@BuisnessWorker, Authorizations=@Authorizations, Added_Date=@Added_Date WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewWorker.ID);
                cmd.Parameters.AddWithValue("@PersonalID", NewWorker.PersonalID);
                cmd.Parameters.AddWithValue("@First_Name", NewWorker.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewWorker.LasttName);
                cmd.Parameters.AddWithValue("@Password", NewWorker.Password);
                cmd.Parameters.AddWithValue("@Phone", NewWorker.Phone);
                cmd.Parameters.AddWithValue("@Address", NewWorker.Address);
                cmd.Parameters.AddWithValue("@BuisnessWorker", NewWorker.BuisnessWorker);
                cmd.Parameters.AddWithValue("@Authorizations", NewWorker.Authorization);
                cmd.Parameters.AddWithValue("@Added_Date", NewWorker.AddDate);
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

        #region Search Worker
        public DataTable Search(string KeyWord)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Workers WHERE Id LIKE '%" + KeyWord + "%' OR First_Name LIKE '%" + KeyWord + "%' OR Last_Name LIKE '%" + KeyWord + "%' OR PersonalID LIKE '%" + KeyWord + "%'";
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

        #region Login Worker
        public bool LoginCheck(Object NewObject)
        {
            Worker NewWorker = (Worker)NewObject;
            bool Success = false;
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Workers WHERE PersonalID=@PersonalID AND Password=@Password";
                cmd = new SqlCommand(command, connect);


                cmd.Parameters.AddWithValue("@PersonalID", NewWorker.PersonalID);
                cmd.Parameters.AddWithValue("@Password", NewWorker.Password);

                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
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
            return Success;
        }
        #endregion


        #region Worker By Id
        public DataTable SearchById(string id)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Workers WHERE Id=@Id";
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
            throw new NotImplementedException();
        }
        #endregion
    }
}

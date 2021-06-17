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
    public class DAL_User : DAL_config,IDAL_User
    {
        

        #region SelectUser
        public DataTable Select()
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Users";
                cmd = new SqlCommand(command, connect);
                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " +ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dt;

        }
        #endregion

        #region AddUser
        public bool Add(Object NewObject)
        {
            User NewUser = (User)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO Users (First_Name, Last_Name, Email, Password, Phone, Address, BuisnessWorker, Added_Date) VALUES (@First_Name, @Last_Name, @Email, @Password, @Phone, @Address, @BuisnessWorker, @Added_Date)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@First_Name", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewUser.LasttName);
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                cmd.Parameters.AddWithValue("@Phone", NewUser.Phone);
                cmd.Parameters.AddWithValue("@Address", NewUser.Address);
                cmd.Parameters.AddWithValue("@BuisnessWorker", NewUser.BuisnessWorker);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);

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

        #region DeleteUser
        public bool Delete(Object NewObject)
        {
            User NewUser = (User)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "DELETE FROM Users WHERE Id=@Id";
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

        #region Update User
        public bool Update(Object NewObject)
        {
            User NewUser = (User)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE Users SET First_Name=@First_Name, Last_Name=@Last_Name, Email=@Email, Password=@Password, Phone=@Phone, Address=@Address, BuisnessWorker=@BuisnessWorker, Added_Date=@Added_Date WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ID);
                cmd.Parameters.AddWithValue("@First_Name", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewUser.LasttName);
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                cmd.Parameters.AddWithValue("@Phone", NewUser.Phone);
                cmd.Parameters.AddWithValue("@Address", NewUser.Address);
                cmd.Parameters.AddWithValue("@BuisnessWorker", NewUser.BuisnessWorker);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);

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

        #region Search User
        public DataTable Search(string KeyWord)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Users WHERE Id LIKE '%"+KeyWord+ "%' OR First_Name LIKE '%"+KeyWord+ "%' OR Last_Name LIKE '%"+KeyWord+ "%' OR Email LIKE '%"+KeyWord+"%'";
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

        #region Login User
        public bool LoginCheck(Object NewObject)
        {
            User NewUser = (User)NewObject;
            bool Success = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";
                cmd = new SqlCommand(command, connect);

                
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);

                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
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


        #region user By Id
        public DataTable SearchById(string id)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Users WHERE Id=@Id";
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
            User selectUser = new User();
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Users WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", id);

                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);

                selectUser.ID = Int32.Parse(dt.Rows[0]["Id"].ToString());
                selectUser.FirstName = dt.Rows[0]["First_Name"].ToString();
                selectUser.LasttName = dt.Rows[0]["Last_Name"].ToString();
                selectUser.Email = dt.Rows[0]["Email"].ToString();
                selectUser.Password = dt.Rows[0]["Password"].ToString();
                selectUser.Phone = dt.Rows[0]["Phone"].ToString();
                selectUser.Address = dt.Rows[0]["Address"].ToString();
                selectUser.BuisnessWorker = false;
                selectUser.AddDate = DateTime.Now;

            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return selectUser;
        }
        #endregion

    }
}

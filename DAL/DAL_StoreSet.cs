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
    public class DAL_StoreSet: DAL_config,IDAL_DATABASE
    {
        #region Add
        public bool Add(object NewObject)
        {
            StoreSet NewSet = (StoreSet)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "INSERT INTO StoreSetting (Name, Phone, Email, EmailConfig, Address, Facebook, Instegram, Twitter) VALUES (@Name, @Phone, @Email, @EmailConfig, @Address, @Facebook, @Instegram, @Twitter)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Name", NewSet.Name);
                cmd.Parameters.AddWithValue("@Phone", NewSet.Phone);
                cmd.Parameters.AddWithValue("@Email", NewSet.Email);
                cmd.Parameters.AddWithValue("@EmailConfig", NewSet.EmailConfig);
                cmd.Parameters.AddWithValue("@Address", NewSet.Address);
                cmd.Parameters.AddWithValue("@Facebook", NewSet.Facebook);
                cmd.Parameters.AddWithValue("@Instegram", NewSet.Instegram);
                cmd.Parameters.AddWithValue("@Twitter", NewSet.Twitter);

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

        #region Update
        public bool Update(object NewObject)
        {
            StoreSet NewSet = (StoreSet)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE StoreSetting SET Name=@Name, Phone=@Phone, Email=@Email, EmailConfig=@EmailConfig, Address=@Address, Facebook=@Facebook, Instegram=@Instegram, Twitter=@Twitter WHERE Id=1";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Name", NewSet.Name);
                cmd.Parameters.AddWithValue("@Phone", NewSet.Phone);
                cmd.Parameters.AddWithValue("@Email", NewSet.Email);
                cmd.Parameters.AddWithValue("@EmailConfig", NewSet.EmailConfig);
                cmd.Parameters.AddWithValue("@Address", NewSet.Address);
                cmd.Parameters.AddWithValue("@Facebook", NewSet.Facebook);
                cmd.Parameters.AddWithValue("@Instegram", NewSet.Instegram);
                cmd.Parameters.AddWithValue("@Twitter", NewSet.Twitter);

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

        #region Select
        public DataTable Select()
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM StoreSetting";
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

        #region From Id To Object
        public object FromIdToObject(string id)
        {
            StoreSet selectStoreSet = new StoreSet();
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM StoreSetting WHERE Id=1";
                cmd = new SqlCommand(command, connect);


                adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);

                
                selectStoreSet.Name = dt.Rows[0]["Name"].ToString();
                selectStoreSet.Phone = dt.Rows[0]["Phone"].ToString();
                selectStoreSet.Email = dt.Rows[0]["Email"].ToString();
                selectStoreSet.EmailConfig = dt.Rows[0]["EmailConfig"].ToString();
                selectStoreSet.Address = dt.Rows[0]["Address"].ToString();
                selectStoreSet.Facebook = dt.Rows[0]["Facebook"].ToString();
                selectStoreSet.Instegram = dt.Rows[0]["Instegram"].ToString();
                selectStoreSet.Twitter = dt.Rows[0]["Twitter"].ToString();

            }
            catch (SqlException ex)
            {
                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return selectStoreSet;
        }
        #endregion

        #region Delete
        public bool Delete(object NewObject)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Search
        public DataTable Search(string KeyWord)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Search By Id
        public DataTable SearchById(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

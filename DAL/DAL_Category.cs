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
    public class DAL_Category : DAL_config,IDAL_DATABASE
    {
        #region Add
        public bool Add(object NewObject)
        {
            Category NewUser = (Category)NewObject;
            connect = new SqlConnection(MyConnString);
            AddSuccess = false;

            try
            {
                command = "INSERT INTO Categories (Title, Description, Added_Date) VALUES (@Title, @Description, @Added_Date)";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Title", NewUser.Title);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
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

        #region Delete
        public bool Delete(object NewObject)
        {
            Category NewUser = (Category)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "DELETE FROM Categories WHERE Id=@Id";
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

        #region From Id To Object
        public object FromIdToObject(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Search
        public DataTable Search(string KeyWord)
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Categories WHERE Id LIKE '%" + KeyWord + "%' OR Title LIKE '%" + KeyWord + "%' OR Description LIKE '%" + KeyWord +  "%'";
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

        #region Search By Id
        public DataTable SearchById(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Select
        public DataTable Select()
        {
            connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                command = "SELECT * FROM Categories";
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
            Category NewUser = (Category)NewObject;
            AddSuccess = false;
            connect = new SqlConnection(MyConnString);

            try
            {
                command = "UPDATE Categories SET Title=@Title, Description=@Description, Added_Date=@Added_Date WHERE Id=@Id";
                cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ID);
                cmd.Parameters.AddWithValue("@Title", NewUser.Title);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
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
    }
}

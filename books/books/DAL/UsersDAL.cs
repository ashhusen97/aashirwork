using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using books.BLL;
using System.Windows.Forms;
using System.IO;
namespace books.DAL
{
    class UsersDAL
    {

        static String myconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        #region LoginCheck Function
        public bool Login(UsersBLL usersbll)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                string sql = "SELECT * FROM Users where Username = @username AND Password = @password AND User_type = @user_type";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", usersbll.Username);
                cmd.Parameters.AddWithValue("@password", usersbll.Password);
                cmd.Parameters.AddWithValue("@user_type", usersbll.UserType);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();

            }
            return isSuccess;
        }
        #endregion
        #region Insert Data Function
        public bool insertData(UsersBLL userbll)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            byte[] image = null;
            FileStream stream = new FileStream(userbll.img, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            image = brs.ReadBytes((int)stream.Length);
            try
            {
                con.Open();
                string sql = "INSERT INTO Users (Firstname,Lastname,Email,Username,Password,Contact,Image,User_type,Department,Batch,Gender,Added_by,Added_date) Values (@Firstname,@Lastname,@Email,@Username,@Password,@Contact,@Image,@User_type,@Department,@Batch,@Gender,@Added_by,@Added_date)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Firstname", userbll.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", userbll.Lastname);
                cmd.Parameters.AddWithValue("@Email", userbll.Email);
                cmd.Parameters.AddWithValue("@Username", userbll.Username);
                cmd.Parameters.AddWithValue("@Password", userbll.Password);
                cmd.Parameters.AddWithValue("@Contact", userbll.Contact);
                cmd.Parameters.AddWithValue("@User_type", userbll.UserType);
                cmd.Parameters.AddWithValue("@Department", userbll.Depart);
                cmd.Parameters.AddWithValue("@Batch", userbll.Batch);
                cmd.Parameters.AddWithValue("@Gender", userbll.Gender);
                cmd.Parameters.AddWithValue("@Added_by", userbll.Added_by);
                cmd.Parameters.AddWithValue("@Added_date", userbll.Added_date);
                cmd.Parameters.Add(new SqlParameter("@Image", image));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                    isSuccess = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


            return isSuccess;
        }
        #endregion
        #region SHow Data 
        public DataTable show()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                String sql = "SELECT * FROM Users where User_type = 'Student'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally

            {
                con.Close();
            }
            return dt;
        }


        #endregion
        #region search data through keyword
        public DataTable search(string keyword)
        {
            SqlConnection con = new SqlConnection(myconnection);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Users WHERE User_type = 'Student' OR Id LIKE '%" + keyword + "%' OR Firstname LIKE '%" + keyword + "%' OR Lastname LIKE '%" + keyword + "%' OR Username LIKE '%" + keyword + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }
            return dt;
        }

        #endregion
        #region Update Student in database
        public bool update(UsersBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                String sql = "UPDATE Users SET Firstname=@Firstname,Lastname=@Lastname,Email=@Email,Username=@Username,Password=@Password,Contact=@Contact,User_type=@User_type,Added_Date=@Added_date,Added_by=@Added_By,Department=@Department,Batch=@Batch,Gender=@Gender WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Firstname", c.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", c.Lastname);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Username", c.Username);
                cmd.Parameters.AddWithValue("@Password", c.Password);
                cmd.Parameters.AddWithValue("@Contact", c.Contact);
                cmd.Parameters.AddWithValue("@User_type", c.UserType);
                cmd.Parameters.AddWithValue("@Added_date", c.Added_date);
                cmd.Parameters.AddWithValue("@Added_by", c.Added_by);
                cmd.Parameters.AddWithValue("@Department", c.Depart);
                cmd.Parameters.AddWithValue("@Batch", c.Batch);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@id", c.Id);
                

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
        #endregion

    }
}
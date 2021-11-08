using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Dao
{
    public class UserDao
    {

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public int insertUser(Users user)
        {
            int status = 0;
            try
            {
                string sql = "insert into users(fname, lname, email) values('" + user.fname + "', '" + user.lname + "','" + user.email + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
              
            } catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return status;
        }

        public List<Users> getAllUsers()
        {
            try {
                string sql ="select id,fname, lname,email from users";
                List<Users> userlist = new List<Users>();
                
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                     cmd.CommandType = System.Data.CommandType.Text;
                        using(SqlDataAdapter sda =  new SqlDataAdapter(cmd))
                        {
                        using(System.Data.DataTable dt =  new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            foreach (System.Data.DataRow dr in dt.Rows)
                            {
                                Users user = new Users();
                                user.id = Convert.ToInt32(dr[0]);
                                user.fname = dr[1].ToString();
                                user.lname = dr[2].ToString();
                                user.email = dr[3].ToString();
                                userlist.Add(user);
                            }
                        }
                        }
                   }
               

                return userlist;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }


        public List<Users> getAllUsersByid(string id)
        {
            try
            {
                string sql = "select id,fname, lname,email from users where id = '"+id+"'";
                List<Users> userlist = new List<Users>();

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            foreach (System.Data.DataRow dr in dt.Rows)
                            {
                                Users user = new Users();
                                user.id = Convert.ToInt32(dr[0]);
                                user.fname = dr[1].ToString();
                                user.lname = dr[2].ToString();
                                user.email = dr[3].ToString();
                                userlist.Add(user);
                            }
                        }
                    }
                }


                return userlist;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }finally
            {
                con.Close();
            }

            return null;
        }


        public int UpdateUser(Users user)
        {
            int status = 0;
            try
            {
                //  string sql = "insert into users(fname, lname, email) values('" + user.fname + "', '" + user.lname + "','" + user.email + "')";
                string sql = "update users set fname = '" + user.fname + "', lname = '" + user.lname + "', email = '" + user.email + "' where id  = '"+user.id+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }


        public int DeleteUser(string id)
        {
            int status = 0;
            try
            {
                //  string sql = "insert into users(fname, lname, email) values('" + user.fname + "', '" + user.lname + "','" + user.email + "')";
                string sql = "delete from users  where id  = '" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }
}
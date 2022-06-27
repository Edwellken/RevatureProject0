using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bankapp
{
    class Actor
    {
        private string connectionString;
        private string user;
        private string pass;
        private bool isadmin;
        //private bool isactive;
        private int attempts;
        private int id;

        public Actor(string connect, string un)
        {
            connectionString = connect;
            user = un;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Actor where Username = '" + un + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        pass = reader["Password"].ToString();
                        isadmin = (bool)reader["Admin"];
                        attempts = (int)reader["Attempts"];
                        id = (int)reader["ID"];

                        //Console.WriteLine("Username = " + user);
                        //Console.WriteLine("Password = " + pass);
                        //Console.WriteLine("Admin = " + isadmin);
                        //Console.WriteLine("Attempts = " + attempts);
                        //Console.WriteLine("ID = " + id);
                    }
                    else
                    {
                        id = 0;
                    }
                    
                }
            }
        }

        public string GetUser()
        {
            return user;
        }

        public string GetPass()
        {
            return pass;
        }

        public bool GetIsAdmin()
        {
            return isadmin;
        }

        public int GetAttempts()
        {
            return attempts;
        }

        public int GetId()
        {
            return id;
        }

        public bool VerifyUserName(string un)
        {
            bool exists = false;
            //connect to db
            //if un !== username in db then return false, else return true
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Actor where Username = " + un;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string userName = reader["Username"].ToString();
                        if (userName == un)
                        {
                            exists = true;
                        }
                    }
                }
            }
            return exists;
        }
    }
}

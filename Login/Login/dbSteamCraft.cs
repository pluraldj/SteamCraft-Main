using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    public class dbSteamCraft
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["SteamCraftString"].ConnectionString;

        public bool Login(string email, string password)
        {
            SqlConnection myconn = new SqlConnection(this.ConnectionString);
            try
            {
                myconn.Open();

                SqlCommand cmdLogin = new SqlCommand("spLogin", myconn);
                cmdLogin.CommandType = CommandType.StoredProcedure;
                cmdLogin.Parameters.AddWithValue("@EmailAddress", email);
                cmdLogin.Parameters.AddWithValue("@Password", password);

                int LoginSuccess = (int)cmdLogin.ExecuteScalar();
                if(! DBNull.Value.Equals(LoginSuccess) && LoginSuccess == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (myconn != null && myconn.State == ConnectionState.Open)
                {
                    myconn.Close();
                    myconn.Dispose();
                }
            }
        }
    }
}

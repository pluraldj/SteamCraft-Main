using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    public class dbSteamCraft
    {
        public string ConnectionString
        {
            get
            {
                return "Server=strawberry.arvixe.com;" + "Database=SteamCraft;" + "user id=pluraldj;" + "password=Mikhail03;" + "connection timeout=30;";
            }
        }
        public bool spLogin(string Email, string Password)
        {
            SqlConnection myconn = new SqlConnection(this.ConnectionString);
            try
            {
                myconn.Open();

                SqlCommand cmdLogin = new SqlCommand("spLogin", myconn);
                cmdLogin.CommandType = CommandType.StoredProcedure;
                cmdLogin.Parameters.Add("@EmailAddress", Email);
                cmdLogin.Parameters.Add("@Password", Password);

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

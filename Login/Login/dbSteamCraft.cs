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
                return "Server=THEBIGBAD\\PluralDB;" + "Database=SteamCraft;" + "Trusted_Connection=yes;" + "connection timeout=30;";
            }
        }
        public bool spLogin(string Email, string Password)
        {
            bool LoginSuccess;
            SqlConnection myconn = new SqlConnection(this.ConnectionString);
            try
            {
                myconn.Open();

                SqlCommand cmdLogin = new SqlCommand("spLogin", myconn);
                cmdLogin.CommandType = CommandType.StoredProcedure;

                SqlParameter P1 = new SqlParameter()
                {
                    ParameterName = "@EmailAddress",
                    Value = Email
                };

                SqlParameter P2 = new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = Password
                };
                cmdLogin.Parameters.Add(P1);
                cmdLogin.Parameters.Add(P2);

                LoginSuccess = (bool)cmdLogin.ExecuteScalar();
                cmdLogin.Parameters.Clear();
                return LoginSuccess;
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

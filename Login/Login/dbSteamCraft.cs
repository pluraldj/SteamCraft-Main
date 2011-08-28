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
            int LoginSuccess;
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

                LoginSuccess = (int)cmdLogin.ExecuteScalar();
                if(! DBNull.Value.Equals(LoginSuccess))
                {
                    if((int)LoginSuccess==1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

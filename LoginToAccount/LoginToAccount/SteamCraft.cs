using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginToAccount
{
    class SteamCraft
    {
        public void connectSteamCraft()
        {
            SqlConnection steamConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SteamCraftConnectionString"].ConnectionString);
            steamConn.Open();
        }

        public string getSalt(string emailaddress)
        {
            SqlCommand getsalt = new SqlCommand("spLogin", this.connectSteamCraft);
            getsalt.CommandType = CommandType.StoredProcedure;
            getsalt.Parameters.AddWithValue("@EmailAddress", emailaddress);
            string passwordsalt = (string)getsalt.ExecuteScalar();
            return passwordsalt;
        }
    }
}

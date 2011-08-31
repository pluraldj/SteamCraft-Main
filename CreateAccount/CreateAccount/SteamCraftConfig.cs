using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CreateAccount
{
    class SteamCraftConfig
    {
        
        public static string SteamCraftString()
        {

            return ConfigurationManager.ConnectionStrings["SteamCraftConnectionString"].ConnectionString;
        
        }

        public void SteamCraftConn()
        {
            SqlConnection scConn = new SqlConnection(SteamCraftString());

        }

    }
}

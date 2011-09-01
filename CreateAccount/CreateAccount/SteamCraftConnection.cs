using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CreateAccount
{
    class SteamCraftConnection
    {
        public static string SteamCraftString()
        {
            string connstring = ConfigurationManager.ConnectionStrings["SteamCraftConnectionString"].ConnectionString;
            return connstring;
        }
    }
}

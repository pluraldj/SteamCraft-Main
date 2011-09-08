using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace LoginToAccount
{
    class SteamCraft
    {
        private SqlConnection connectSteamCraft
        {
            get
            {
                SqlConnection steamConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SteamCraftConnectionString"].ConnectionString);
                steamConn.Open();
                return steamConn;
            }
        }

        private string getSalt(string emailaddress)
        {
            try
            {
                SqlCommand getsalt = new SqlCommand("spGetSalt", this.connectSteamCraft);
                getsalt.CommandType = CommandType.StoredProcedure;
                getsalt.Parameters.AddWithValue("@EmailAddress", emailaddress);
                string passwordsalt = (string)getsalt.ExecuteScalar();
                return passwordsalt;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                this.connectSteamCraft.Close();
                this.connectSteamCraft.Dispose();
            }
        }

        private string getHashedPassword(string emailaddress)
        {
            try
            {
                SqlCommand gethashedpassword = new SqlCommand("spGetHashedPassword", this.connectSteamCraft);
                gethashedpassword.CommandType = CommandType.StoredProcedure;
                gethashedpassword.Parameters.AddWithValue("@EmailAddress", emailaddress);
                string hashedpassword = (string)gethashedpassword.ExecuteScalar();
                return hashedpassword;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                this.connectSteamCraft.Close();
                this.connectSteamCraft.Dispose();
            }
        }

        public bool verifyPassword(string emailaddress, string password)
        {
            string salt = this.getSalt(emailaddress);

            string hashedpassword = this.getHashedPassword(emailaddress);

            SteamCraftHash hashnow = new SteamCraftHash();
            string passwordhash = hashnow.getHash(password, salt);

            if (hashedpassword == passwordhash)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

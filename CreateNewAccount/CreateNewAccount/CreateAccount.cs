using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CreateNewAccount
{
    // This is SteamCraft.cs in the winform app
    public class CreateAccount
    {
        private static string SteamCraftString
        {
            get
            {
                string connstring = ConfigurationManager.ConnectionStrings["SteamCraftConnectionString"].ConnectionString;
                return connstring;
            }
        }

        private static SqlConnection connectSteamCraft
        {
            get
            {
                SqlConnection myconn = new SqlConnection(SteamCraftString);
                myconn.Open();
                return myconn;
            }
        }

        public bool createAccount(string email, string firstname, string lastname, string password)
        {
            PasswordHash hashpassword = new PasswordHash();
            string salt = hashpassword.getSalt;
            string hashedpassword = hashpassword.getHash(password);

            try
            {
                SqlCommand createaccountnow = new SqlCommand("spCreateAccount", connectSteamCraft);
                createaccountnow.CommandType = CommandType.StoredProcedure;
                createaccountnow.Parameters.AddWithValue("@EmailAddress", email);
                createaccountnow.Parameters.AddWithValue("@FirstName", firstname);
                createaccountnow.Parameters.AddWithValue("@LastName", lastname);
                createaccountnow.Parameters.AddWithValue("@Password", hashedpassword);
                createaccountnow.Parameters.AddWithValue("@ID", salt);

                int accountcreated = createaccountnow.ExecuteNonQuery();

                createaccountnow.Parameters.Clear();

                if (accountcreated == 1)
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
                if (connectSteamCraft != null && connectSteamCraft.State == ConnectionState.Open)
                {
                    connectSteamCraft.Close();
                    connectSteamCraft.Dispose();
                }
            }
        }
    }
}
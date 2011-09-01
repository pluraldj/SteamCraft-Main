using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CreateAccount
{
    class SteamCraft
    {
        private static SqlConnection connectSteamCraft
        {
            get
            {
                SqlConnection myconn = new SqlConnection(SteamCraftConnection.SteamCraftString());
                myconn.Open();
                return myconn;
            }
        }

        public bool createAccount(string email, string firstname, string lastname, string password)
        {
            SteamCraftHash passwordhash = new SteamCraftHash();
            string salt = passwordhash.getSalt;
            string hashedpassword = passwordhash.getHash(password, salt);

            try
            {
                SqlCommand commandCreateAccount = new SqlCommand("spCreateAccount", connectSteamCraft);
                commandCreateAccount.CommandType = CommandType.StoredProcedure;
                commandCreateAccount.Parameters.AddWithValue("@EmailAddress", email);
                commandCreateAccount.Parameters.AddWithValue("@FirstName", firstname);
                commandCreateAccount.Parameters.AddWithValue("@LastName", lastname);
                commandCreateAccount.Parameters.AddWithValue("@Password", hashedpassword);
                commandCreateAccount.Parameters.AddWithValue("@ID", salt);

                int accountcreated = commandCreateAccount.ExecuteNonQuery();

                commandCreateAccount.Parameters.Clear();

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

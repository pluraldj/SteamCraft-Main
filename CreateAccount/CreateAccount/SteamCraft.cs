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
        public bool createAccount(string email, string firstname, string lastname, string password)
        {
            SqlConnection myconn = new SqlConnection(SteamCraftConnection.SteamCraftString());

            SteamCraftHash passwordhash = new SteamCraftHash();
            string salt = passwordhash.getSalt;
            string hashedpassword = passwordhash.getHash(password, salt);

            try
            {
                SqlCommand commandCreateAccount = new SqlCommand("spCreateAccount", myconn);
                commandCreateAccount.CommandType = CommandType.StoredProcedure;
                commandCreateAccount.Parameters.AddWithValue("@EmailAddress", email);
                commandCreateAccount.Parameters.AddWithValue("@FirstName", firstname);
                commandCreateAccount.Parameters.AddWithValue("@LastName", lastname);
                commandCreateAccount.Parameters.AddWithValue("@Password", hashedpassword);
                commandCreateAccount.Parameters.AddWithValue("@ID", salt);

                int accountcreated = commandCreateAccount.ExecuteNonQuery();

                commandCreateAccount.Parameters.Clear();

                if (accountcreated != null && accountcreated == 1)
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

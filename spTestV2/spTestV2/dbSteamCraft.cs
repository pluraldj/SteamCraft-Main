using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace spTestV2
{
    public class dbSteamCraft
    {
        // property for the sql connection details
        public string ConnectionString
        {
            get
            {
                // it would be better to get these from a settings file, but i'm not going to try to tackle that right now
                return "Server=THEBIGBAD\\PluralDB;" + "Database=SteamCraft;" + "Trusted_Connection=yes;" + "connection timeout=30;";
            }
        }

        // a method to execute SteamCraft.dbo.spCreateAccount
        public int spCA(string eMail, string FirstName, string LastName, string Password)
    	{
        	int successCA;
        	// create and open connection
        	SqlConnection myconn = new SqlConnection(this.ConnectionString);

            try
            {
                myconn.Open();

                // create a command object for the sp
                SqlCommand cmdCA = new SqlCommand("spCreateAccount", myconn);

                // set the command object so it knows to execute an sp
                cmdCA.CommandType = CommandType.StoredProcedure;

                // set up parameters
                SqlParameter p1 = new SqlParameter()
				{
					ParameterName = "@EmailAddress",
					Value = eMail
				};

                SqlParameter p2 = new SqlParameter()
                {
                    ParameterName = "@FirstName",
                    Value = FirstName
                };

                SqlParameter p3 = new SqlParameter()
				{
					ParameterName = "@LastName",
					Value = LastName
				};

                SqlParameter p4 = new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = Password
                };

                // add the parameters to the command
                cmdCA.Parameters.Add(p1);
                cmdCA.Parameters.Add(p2);
                cmdCA.Parameters.Add(p3);
                cmdCA.Parameters.Add(p4);

                // run the sp, then clear the parameters and return the number of rows affected
                successCA = cmdCA.ExecuteNonQuery();
                cmdCA.Parameters.Clear();
                return successCA;	//this is an int variable, but it should only return 0 or 1, since only one row should be affected if it succeeds

            }
            catch (Exception)
            {
                //if executing the sp fails, toss the error over to form1
                throw;
            }
            finally
            {
                myconn.Close(); // close the connection
                myconn.Dispose();   // dispose of the connection
            }
    	}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreateNewAccount
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            string email = textEmailAddress.Text;
            string firstname = textFirstName.Text;
            string lastname = textLastName.Text;
            string password = textPassword.Text;

            CreateAccount createaccountnow = new CreateAccount();
            bool success = false;

            try
            {
                success = createaccountnow.createAccount(email, firstname, lastname, password);

                if (success)
                {
                    Response.Write("Account successfully created!");
                }

                else
                {
                    Response.Write("Account failed to be created!");
                }
            }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
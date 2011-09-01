using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateAccount
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string firstname = textFirstName.Text;
            string lastname = textLastName.Text;
            string password = textPassword.Text;

            SteamCraft createaccountnow = new SteamCraft();
            bool success = false;

            try
            {
                success = createaccountnow.createAccount(email, firstname, lastname, password);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (success == true)
            {
                MessageBox.Show("Account successfully created!");
            }

            if (success == false)
            {
                MessageBox.Show("Account failed to be created!");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginToAccount
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            SteamCraft verifynow = new SteamCraft();
            bool verified = false;

            try
            {
                verified = verifynow.verifyPassword(email, password);

                if (verified)
                {
                    MessageBox.Show("Login successful!");
                }

                else
                {
                    MessageBox.Show("Login failed!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

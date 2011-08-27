using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace spTestV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //assign the textboxes to variables
            string eMail = textBox1.Text;
            string FirstName = textBox2.Text;
            string LastName = textBox3.Text;
            string Password = textBox4.Text;

            //create an object for dbSteamCraft
            dbSteamCraft dbSC = new dbSteamCraft();
            int result = 0;

            //attempt to execute spCreateAccount through the spCA method
            try
            {
                result = dbSC.spCA(eMail, FirstName, LastName, Password);

            }
            //if it doesn't work, shows us the error
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }

            if (result != 0) //this means it worked - one row would be affected, so 1 is returned
            {
                MessageBox.Show("Yes!");
            }

            if (result == 0) //it didn't work - no rows were affected, so 0 is returned
            {
                MessageBox.Show("No.");
            }
        }
    }
}

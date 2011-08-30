using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            string Password = textBox2.Text;
            dbSteamCraft dbSC = new dbSteamCraft();
            bool result = false;
            try
            {
                result = dbSC.spLogin(Email, Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (result == true)
            {
                MessageBox.Show("Yes");
            }
            if (result == false)
            {
                MessageBox.Show("No");
            }
        }
    }
}

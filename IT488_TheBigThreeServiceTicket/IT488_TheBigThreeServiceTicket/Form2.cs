using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT488_TheBigThreeServiceTicket
{
    public partial class Form2 : Form
    {
        private DB db;

        public Form2()
        {
            InitializeComponent();
        }

        //Attempts to login based on user name and password.
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
            {
                isValid = false;
                MessageBox.Show("You must enter user name, password, server, and database values");
            }
            else if (textBox2.Text.Length < 8)
            {
                isValid = false;
                MessageBox.Show("Password length must be 8 characters or more");
            }
            
            //Checks for proper authentication before going to employee service ticket form.
            if (isValid)
            {
                db = new DB("Server = K2107N0117911\\SQLEXPRESS;" +
                                       "Trusted_Connection=true;" +
                "Database = TheBigThreeSupport ;" +
                                       "User Id = " + textBox1 + ";" +
                                       "Password = " + textBox2 + ";"
                                       );
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();


            }
            
        }
    }
}

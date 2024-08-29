using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT499_RiskyShoppingProject
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = Database.GetConnection())
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string firstname = textBox3.Text;
                string lastname = textBox4.Text;
                string email = textBox5.Text;

                var command = new SqlCommand("INSERT INTO Customers (username, password, firstname, lastname, email) VALUES (@Username, @Password, @FirstName, @LastName, @Email)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@FirstName", firstname);
                command.Parameters.AddWithValue("@LastName", lastname);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }

            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}

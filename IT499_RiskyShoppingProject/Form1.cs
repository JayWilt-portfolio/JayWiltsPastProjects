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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT CustomerID FROM Customers WHERE Username = @username AND Password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int customerId = (int)reader["CustomerID"];
                    MainForm mainForm = new MainForm(customerId);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration Registration = new Registration();
            Registration.Show();
            this.Hide();
        }
    }
}

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
    public partial class CartForm : Form
    {
        private int _customerId;

        public CartForm(int customerId)
        {
            _customerId = customerId;
            InitializeComponent();
            LoadCart();
        }

        private void LoadCart()
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT CartID, Product, Quantity, DateAdded FROM ShoppingCart WHERE CustomerID = @customerId", connection);
                command.Parameters.AddWithValue("@customerId", _customerId);
                var adapter = new SqlDataAdapter(command);
                var table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string product = textBox1.Text;
            int quantity = int.Parse(textBox2.Text);
            DateTime dateAdded = DateTime.Now;

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO ShoppingCart (CustomerID, Product, Quantity, DateAdded) VALUES (@customerId, @product, @quantity, @dateAdded)", connection);
                command.Parameters.AddWithValue("@customerId", _customerId);
                command.Parameters.AddWithValue("@product", product);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@dateAdded", dateAdded);
                command.ExecuteNonQuery();
            }

            LoadCart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Shopping cart saved successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int cartId = (int)selectedRow.Cells["CartID"].Value;

                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("DELETE FROM ShoppingCart WHERE CartID = @cartId", connection);
                    command.Parameters.AddWithValue("@cartId", cartId);
                    command.ExecuteNonQuery();
                }

                LoadCart();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }

        }
    }
}

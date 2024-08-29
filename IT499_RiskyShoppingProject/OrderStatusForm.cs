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
    public partial class OrderStatusForm : Form
    {
        private int _customerId;

        public OrderStatusForm(int customerId)
        {
            _customerId = customerId;
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT OrderID, Product, Quantity, OrderStatus, OrderDate FROM Orders WHERE CustomerID = @customerId", connection);
                command.Parameters.AddWithValue("@customerId", _customerId);
                var adapter = new SqlDataAdapter(command);
                var table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int orderId = (int)selectedRow.Cells["OrderID"].Value;
                string orderStatus = selectedRow.Cells["OrderStatus"].Value.ToString();

                if (orderStatus != "Shipped")
                {
                    using (var connection = Database.GetConnection())
                    {
                        var command = new SqlCommand("DELETE FROM Orders WHERE OrderID = @orderId", connection);
                        command.Parameters.AddWithValue("@orderId", orderId);
                        command.ExecuteNonQuery();
                    }

                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Cannot cancel orders that have been shipped.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT499_RiskyShoppingProject
{
    public partial class MainForm : Form
    {
        private int _customerId;

        public MainForm(int customerId)
        {
            _customerId = customerId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderStatusForm orderStatusForm = new OrderStatusForm(_customerId);
            orderStatusForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CartForm shoppingCartForm = new CartForm(_customerId);
            shoppingCartForm.Show();
        }
    }
}

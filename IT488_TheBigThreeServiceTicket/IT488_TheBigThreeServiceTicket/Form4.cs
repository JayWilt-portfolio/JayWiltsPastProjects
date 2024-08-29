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

namespace IT488_TheBigThreeServiceTicket
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //Pulls description and Solution from Service Ticket Closed to create a self generating faqs form.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var con = new SqlConnection(@"Data Source = K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;");
            con.Open();
            var da = new SqlDataAdapter("SELECT Ticket_Description, Ticket_Solution FROM Service_Ticket_Closed WHERE Service_Tech_ID LIKE 1 ORDER BY Ticket_Number", con);
            var dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        //Pulls description and Solution from Service Ticket Closed to create a self generating faqs form.
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var con = new SqlConnection(@"Data Source = K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;");
            con.Open();
            var da = new SqlDataAdapter("SELECT Ticket_Description, Ticket_Solution FROM Service_Ticket_Closed WHERE Service_Tech_ID LIKE 2 ORDER BY Ticket_Number", con);
            var dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        //Pulls description and Solution from Service Ticket Closed to create a self generating faqs form.
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var con = new SqlConnection(@"Data Source = K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;");
            con.Open();
            var da = new SqlDataAdapter("SELECT Ticket_Description, Ticket_Solution FROM Service_Ticket_Closed WHERE Service_Tech_ID LIKE 3 ORDER BY Ticket_Number", con);
            var dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        //Pulls description and Solution from Service Ticket Closed to create a self generating faqs form.
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var con = new SqlConnection(@"Data Source = K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;");
            con.Open();
            var da = new SqlDataAdapter("SELECT Ticket_Description, Ticket_Solution FROM Service_Ticket_Closed WHERE Service_Tech_ID LIKE 5 ORDER BY Ticket_Number", con);
            var dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}

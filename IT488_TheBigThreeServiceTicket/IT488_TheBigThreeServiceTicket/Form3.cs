using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IT488_TheBigThreeServiceTicket
{
    public partial class Form3 : Form
    {
        // Connects to Database
        SqlConnection con = new SqlConnection(@"Data Source =K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security = True;");
        SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
        }


        //Submits service ticket with solution.
        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            int TicketNumber = Convert.ToInt32(numericUpDown1.Text);
            var sql1 = "insert into Service_Ticket_Closed ( [Ticket_Number], [Ticket_Date], [Customer_First_Name], [Customer_Last_Name], [Customer_Email], [Customer_Phone], [Ticket_Description], [Ticket_Solution], [Service_Tech_ID]) VALUES(@TicketNumber, @TicketDate, @FirstName, @LastName, @Email, @Phone, @Description, @Solution, @ServiceTechID)";
            using (var cmd = new SqlCommand(sql1, con))
            {
                cmd.Parameters.Add("@TicketNumber", SqlDbType.Int).Value = numericUpDown1.Text;
                cmd.Parameters.Add("@TicketDate", SqlDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = textBox6.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = textBox7.Text;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = richTextBox1.Text;
                cmd.Parameters.Add("@Solution", SqlDbType.VarChar).Value = richTextBox2.Text;
                cmd.Parameters.Add("@ServiceTechID", SqlDbType.VarChar).Value = textBox8.Text;

                cmd.ExecuteNonQuery();
            }


            con.Close();

            //Sends email to customer giving the solution.
            try
            {



                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp-mail.outlook.com");
                mm.From = new MailAddress("bigthreeserviceticket@outlook.com");
                mm.To.Add(textBox6.Text);
                mm.Subject = ("Response Involving Ticket Number" + numericUpDown1.Text);
                var rc = new StringBuilder();
                rc.Append("Hello " + textBox5.Text + ", " + textBox4.Text);
                rc.Append(Environment.NewLine);
                rc.Append(Environment.NewLine);
                rc.Append("On " + textBox3.Text + "you contacted The Big three regarding an issue involving:");
                rc.Append(Environment.NewLine);
                rc.Append(richTextBox1.Text);
                rc.Append(Environment.NewLine);
                rc.Append("The solution to this problem is " + richTextBox2.Text);
                rc.Append(Environment.NewLine);
                rc.Append(Environment.NewLine);
                rc.Append("Please do not reply to this message.");
                mm.Body = rc.ToString();
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("bigthreeserviceticket@outlook.com", "P@ssw0rd1234567");
                sc.EnableSsl = true;
                sc.Send(mm);
                MessageBox.Show("Response Involving Ticket Number" + numericUpDown1.Text);

            }
            catch (Exception ex) { }

        }



        //Unneccessary but could be used as an update system in the future.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //Pulls data from database based on ticket number.
        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = K2107N0117911\\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Ticket_Number, Ticket_Date, Customer_First_Name, Customer_Last_Name, Customer_Email, Customer_Phone, Ticket_Description, Service_Tech_ID From Service_Ticket Where Ticket_Number =@Ticket_Number ", con);
            cmd.Parameters.AddWithValue("@Ticket_Number", int.Parse(textBox1.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                numericUpDown1.Text = dr.GetValue(0).ToString();
                textBox3.Text = dr.GetValue(1).ToString();
                textBox4.Text = dr.GetValue(2).ToString();
                textBox5.Text = dr.GetValue(3).ToString();
                textBox6.Text = dr.GetValue(4).ToString();
                textBox7.Text = dr.GetValue(5).ToString();
                textBox8.Text = dr.GetValue(7).ToString();
                richTextBox1.Text = dr.GetValue(6).ToString();
            }
            con.Close();
        }

        //Shows all available tickets in the Service_Ticket into a data grid view.
        private void button3_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source = K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security=True;");
            con.Open();
            var da = new SqlDataAdapter("SELECT * FROM Service_Ticket", con);
            var dtbl = new DataTable();
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}

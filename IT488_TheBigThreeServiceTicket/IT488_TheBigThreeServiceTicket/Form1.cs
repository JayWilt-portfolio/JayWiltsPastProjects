using System.Net.Mail;
using System.Net.Security;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Drawing.Text;

namespace IT488_TheBigThreeServiceTicket
{
    public partial class Form1 : Form
    {
        //***SQL Connection goes here
        SqlConnection con = new SqlConnection(@"Data Source =K2107N0117911\SQLEXPRESS; Initial Catalog = TheBigThreeSupport; Integrated Security = True;");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }
        //Submit information to Database and send email to department based email.
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter First Name");
                return;
            }
            else if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Last Name");
                return;
            }
            else if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Email");
                return;
            }
            else if (textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Phone Number");
                return;
            }

            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select Department");
                return;
            }

            if (richTextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Describe Issue");
                return;
            }
            //Opens connection to database and inserts the information into the database
            con.Open();
            var sql = "insert into Service_Ticket ( [Customer_First_Name], [Customer_Last_Name], [Ticket_Date], [Customer_Email], [Customer_Phone], [Ticket_Description], [Service_Tech_ID]) VALUES(@FirstName, @LastName, @Date, @Email, @Phone, @Description, @ServiceTechID)";
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.Char).Value = textBox4.Text;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = richTextBox1.Text;

                if (comboBox1.Text == "Account")
                {
                    cmd.Parameters.Add("@ServiceTechID", SqlDbType.VarChar).Value = "1";
                }
                else if (comboBox1.Text == "Hardware")
                {
                    cmd.Parameters.Add("@ServiceTechID", SqlDbType.VarChar).Value = "2";
                }
                else if (comboBox1.Text == "Store")
                {
                    cmd.Parameters.Add("@ServiceTechID", SqlDbType.VarChar).Value = "3";
                }
                else if (comboBox1.Text == "Software")
                {
                    cmd.Parameters.Add("@ServiceTechID", SqlDbType.VarChar).Value = "4";
                }
                cmd.ExecuteNonQuery();
            }
            con.Close();
            
            //Sends mail message using SMTP client, (NO google email accounts will work to send email), based on department selection.
            if (comboBox1.Text == "Account")
            {
                try
                {

                    MailMessage mm = new MailMessage();
                    SmtpClient sc = new SmtpClient("smtp-mail.outlook.com");
                    mm.From = new MailAddress("bigthreeserviceticket@outlook.com");
                    mm.To.Add("bigthreeserviceticketqccount@outlook.com");
                    mm.Subject = "Test-account";
                    var sb = new StringBuilder();
                    sb.Append("Name: " + textBox1.Text.Substring(0, 1) + "  " + textBox2.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + textBox3.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone: " + textBox4.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Description: " + richTextBox1.Text);
                    mm.Body = sb.ToString();
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("bigthreeserviceticket@outlook.com", "P@ssw0rd1234567");
                    sc.EnableSsl = true;
                    sc.Send(mm);
                    MessageBox.Show("Ticket Submitted. Your ticket number is");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.Text == "Hardware")
            {
                try
                {

                    MailMessage mm = new MailMessage();
                    SmtpClient sc = new SmtpClient("smtp-mail.outlook.com");
                    mm.From = new MailAddress("bigthreeserviceticket@outlook.com");
                    mm.To.Add("bigthreeservicehardware@outlook.com");
                    mm.Subject = "Test-hardware";
                    var sb = new StringBuilder();
                    sb.Append("Name: " + textBox1.Text.Substring(0, 1) + "  " + textBox2.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + textBox3.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone: " + textBox4.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Description: " + richTextBox1.Text);
                    mm.Body = sb.ToString();
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("bigthreeserviceticket@outlook.com", "P@ssw0rd1234567");
                    sc.EnableSsl = true;
                    sc.Send(mm);
                    MessageBox.Show("Ticket Submitted. Your ticket number is");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.Text == "Software")
            {
                try
                {

                    MailMessage mm = new MailMessage();
                    SmtpClient sc = new SmtpClient("smtp-mail.outlook.com");
                    mm.From = new MailAddress("bigthreeserviceticket@outlook.com");
                    mm.To.Add("bigthreeservicesoftware@outlook.com");
                    mm.Subject = "Test-software";
                    var sb = new StringBuilder();
                    sb.Append("Name: " + textBox1.Text.Substring(0, 1) + "  " + textBox2.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + textBox3.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone: " + textBox4.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Description: " + richTextBox1.Text);
                    mm.Body = sb.ToString();
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("bigthreeserviceticket@outlook.com", "P@ssw0rd1234567");
                    sc.EnableSsl = true;
                    sc.Send(mm);
                    MessageBox.Show("Ticket Submitted. Your ticket number is");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.Text == "Store")
            {
                try
                {

                    MailMessage mm = new MailMessage();
                    SmtpClient sc = new SmtpClient("smtp-mail.outlook.com");
                    mm.From = new MailAddress("bigthreeserviceticket@outlook.com");
                    mm.To.Add("bigthreeservicestore@outlook.com");
                    mm.Subject = "Test-store";
                    var sb = new StringBuilder();
                    sb.Append("Name: " + textBox1.Text.Substring(0, 1) + "  " + textBox2.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + textBox3.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone: " + textBox4.Text);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Description: " + richTextBox1.Text);
                    mm.Body = sb.ToString();
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("bigthreeserviceticket@outlook.com", "P@ssw0rd1234567");
                    sc.EnableSsl = true;
                    sc.Send(mm);
                    MessageBox.Show("Ticket Submitted. Your ticket number is");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        //Connects to employee login.
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
        
        //Connects to faqs form.
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }

}

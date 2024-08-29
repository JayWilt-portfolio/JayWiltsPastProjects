using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient();
                smtp.Host = "smtp.outlook.com";
                mm.From = new MailAddress("crazy.eyes10@live.com");
                mm.To.Add("jay.wilt87@gmail.com");
                mm.Subject = "Test";
                var sb = new StringBuilder();
                sb.Append("Name:" + textBox1.Text + textBox2.Text);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(textBox3.Text);
                mm.Body = sb.ToString();
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("crazy.eyes10@live.com", "Ax!svsall1es");
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
}

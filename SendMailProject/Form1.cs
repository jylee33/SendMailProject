using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SendMailProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yubbi33@gmail.com");
                mail.Subject = "이메일 테스트";
                mail.IsBodyHtml = true;
                mail.Body = richBody.Text + "<p></p>회신 받을 주소 : " + "yubbi@nate.com";
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;

                mail.To.Add(new MailAddress("jylee@hamonsoft.co.kr"));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Timeout = 10000;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailID"], ConfigurationManager.AppSettings["MailPW"]);

                smtp.Send(mail);
                mail.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine("에러 발생 : " + ex.Message);
            }

            Console.WriteLine("이메일 전달 완료!");
            richProgress.AppendText("이메일 전달 완료\r\n");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

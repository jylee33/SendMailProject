using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SendMailProject
{
    public partial class Form1 : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 XML;HDR={1}'";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string fileExtension = Path.GetExtension(filePath);
            string header = "Yes";// rbHeaderYes.Checked ? "Yes" : "No";
            string connectionString = string.Empty;
            string sheetName = string.Empty;

            // 확장자로 구분하여 커넥션 스트링을 가져옮
            switch (fileExtension)
            {
                case ".xls":    //Excel 97-03
                    connectionString = string.Format(Excel03ConString, filePath, header);
                    break;
                case ".xlsx":  //Excel 07
                    connectionString = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            // 첫 번째 시트의 이름을 가져옮
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }
            Console.WriteLine("sheetName = " + sheetName);

            // 첫 번째 쉬트의 데이타를 읽어서 datagridview 에 보이게 함.
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        //Populate DataGridView.
                        dataGridView1.DataSource = dt;
                    }
                }
                for(int col = 0; col < dataGridView1.Columns.Count; col++)
                    dataGridView1.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yubbi33@gmail.com", ConfigurationManager.AppSettings["SenderName"]);
                mail.Subject = txtTitle.Text;
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

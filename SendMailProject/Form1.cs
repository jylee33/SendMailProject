using SendMailProject.Properties;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

        private void btnSampleDownload_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string destPath = saveFileDialog1.FileName;
            System.IO.FileInfo sourceFileInfo = new System.IO.FileInfo("resources\\sample.xlsx");
            System.IO.File.Copy(sourceFileInfo.FullName, destPath);
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
            Thread mailThread = new Thread(sendMail);
            mailThread.Start();
        }

        private void sendMail()
        {
            try
            {
                appendProgress("------------------- 메일 전송 시작 -------------------");

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Timeout = 10000;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailID"], ConfigurationManager.AppSettings["MailPW"]);
        
                int totalCnt = dataGridView1.Rows.Count;
                int cnt = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string mailFromAddress = "yubbi33@gmail.com";
                    string mailFromName = "HAMONSOFT";
                    string mailToAddress = "jylee@hamonsoft.co.kr";
                    for(int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        switch(col)
                        {
                            case 0:
                                mailFromName = row.Cells[col].Value.ToString();
                                break;
                            case 1:
                                mailFromAddress = row.Cells[col].Value.ToString();
                                break;
                            case 2:
                                mailToAddress = row.Cells[col].Value.ToString();
                                break;
                            default:
                                break;
                        }
                    }

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailFromAddress, mailFromName);
                    mail.Subject = txtTitle.Text;
                    mail.IsBodyHtml = true;

                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        mail.Body = richBody.Text + "<p></p>회신 받을 주소 : " + mailFromAddress;
                    }));

                    //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;

                    mail.To.Add(new MailAddress(mailToAddress));

                    smtp.Send(mail);
                    mail.Dispose();
                   
                    string message = string.Format("Sent Mail [{0,3} / {1,3}]- from : {2} [{3}] , to : {4}", ++cnt, totalCnt, mailFromName, mailFromAddress, mailToAddress);
                    appendProgress(message);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("에러 발생 : " + ex.Message);
                appendProgress("에러 발생 : " + ex.Message);
            }

            Console.WriteLine("------------------- 메일 전송 완료 -------------------");
            appendProgress("------------------- 메일 전송 완료 -------------------");
        }

        private void appendProgress(string message)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                richProgress.AppendText(message + "\r\n");
            }));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
            e.PaintHeader(DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
            e.Handled = true;

            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}

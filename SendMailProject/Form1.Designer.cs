namespace SendMailProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richProgress = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcelLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richBody = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(664, 401);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(655, 29);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "메일 전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.richProgress, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnSend, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnExcelLoad, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.richBody, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1322, 826);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // richProgress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richProgress, 2);
            this.richProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richProgress.Location = new System.Drawing.Point(3, 466);
            this.richProgress.Name = "richProgress";
            this.richProgress.ReadOnly = true;
            this.richProgress.Size = new System.Drawing.Size(1316, 322);
            this.richProgress.TabIndex = 0;
            this.richProgress.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "메일 송수신자 리스트";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(655, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "진행 상태";
            // 
            // btnExcelLoad
            // 
            this.btnExcelLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcelLoad.Location = new System.Drawing.Point(3, 401);
            this.btnExcelLoad.Name = "btnExcelLoad";
            this.btnExcelLoad.Size = new System.Drawing.Size(655, 29);
            this.btnExcelLoad.TabIndex = 2;
            this.btnExcelLoad.Text = "엑셀 불러오기";
            this.btnExcelLoad.UseVisualStyleBackColor = true;
            this.btnExcelLoad.Click += new System.EventHandler(this.btnExcelLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 3);
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(655, 372);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnClose, 2);
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(3, 794);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1316, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(664, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(655, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "이메일 내용(HTML)";
            // 
            // richBody
            // 
            this.richBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richBody.Location = new System.Drawing.Point(664, 73);
            this.richBody.Name = "richBody";
            this.richBody.Size = new System.Drawing.Size(655, 322);
            this.richBody.TabIndex = 6;
            this.richBody.Text = "<H1>안녕하세요. Hamonsoft NETIS CLOUD 서비스 가입 안내 메일입니다.</H1>\n<img src=\"http://hamonsoft" +
    ".co.kr/wp-content/uploads/2019/07/it-specialist0.png\">\n<br>\n<a href=\\\"http://ham" +
    "onsoft.co.kr\\\">하몬소프트</a>\n";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls; *.xlsx|Comma Separated Value files (CSV)|*.csv" +
    "|모든 파일 (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(664, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(655, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "메일 제목";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(664, 23);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(655, 25);
            this.txtTitle.TabIndex = 8;
            this.txtTitle.Text = "NETIS CLOUD 서비스 가입 안내";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 826);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcelLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richBody;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
    }
}


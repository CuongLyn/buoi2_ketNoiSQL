namespace btthBuoi3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_DsDichVu = new System.Windows.Forms.ListBox();
            this.cbBox_DichVu = new System.Windows.Forms.ComboBox();
            this.txt_Nam = new System.Windows.Forms.TextBox();
            this.txt_Thang = new System.Windows.Forms.TextBox();
            this.txt_Ngay = new System.Windows.Forms.TextBox();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Chon = new System.Windows.Forms.Button();
            this.btn_TiepTuc = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.listKetQua = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lb_mabn = new System.Windows.Forms.Label();
            this.cbb_mabn = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_mabn);
            this.groupBox1.Controls.Add(this.lb_mabn);
            this.groupBox1.Controls.Add(this.listBox_DsDichVu);
            this.groupBox1.Controls.Add(this.cbBox_DichVu);
            this.groupBox1.Controls.Add(this.txt_Nam);
            this.groupBox1.Controls.Add(this.txt_Thang);
            this.groupBox1.Controls.Add(this.txt_Ngay);
            this.groupBox1.Controls.Add(this.txt_Ten);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1260, 534);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bệnh nhân";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listBox_DsDichVu
            // 
            this.listBox_DsDichVu.FormattingEnabled = true;
            this.listBox_DsDichVu.ItemHeight = 25;
            this.listBox_DsDichVu.Location = new System.Drawing.Point(907, 200);
            this.listBox_DsDichVu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBox_DsDichVu.Name = "listBox_DsDichVu";
            this.listBox_DsDichVu.Size = new System.Drawing.Size(294, 304);
            this.listBox_DsDichVu.TabIndex = 5;
            // 
            // cbBox_DichVu
            // 
            this.cbBox_DichVu.FormattingEnabled = true;
            this.cbBox_DichVu.Items.AddRange(new object[] {
            "Cắt môi trái tim",
            "Lăn kim",
            "Nâng mũi",
            "Cắt mí mắt",
            "Xăm lông mày",
            "Xăm môi"});
            this.cbBox_DichVu.Location = new System.Drawing.Point(234, 223);
            this.cbBox_DichVu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbBox_DichVu.Name = "cbBox_DichVu";
            this.cbBox_DichVu.Size = new System.Drawing.Size(354, 33);
            this.cbBox_DichVu.TabIndex = 4;
            this.cbBox_DichVu.SelectedIndexChanged += new System.EventHandler(this.cbBox_DichVu_SelectedIndexChanged);
            // 
            // txt_Nam
            // 
            this.txt_Nam.Location = new System.Drawing.Point(554, 160);
            this.txt_Nam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Nam.Name = "txt_Nam";
            this.txt_Nam.Size = new System.Drawing.Size(122, 31);
            this.txt_Nam.TabIndex = 3;
            // 
            // txt_Thang
            // 
            this.txt_Thang.Location = new System.Drawing.Point(313, 157);
            this.txt_Thang.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Thang.Name = "txt_Thang";
            this.txt_Thang.Size = new System.Drawing.Size(100, 31);
            this.txt_Thang.TabIndex = 2;
            // 
            // txt_Ngay
            // 
            this.txt_Ngay.Location = new System.Drawing.Point(96, 160);
            this.txt_Ngay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Ngay.Name = "txt_Ngay";
            this.txt_Ngay.Size = new System.Drawing.Size(98, 31);
            this.txt_Ngay.TabIndex = 1;
            // 
            // txt_Ten
            // 
            this.txt_Ten.Location = new System.Drawing.Point(204, 112);
            this.txt_Ten.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(442, 31);
            this.txt_Ten.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(655, 223);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Danh sách dịch vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chọn dịch vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên bệnh nhân";
            // 
            // btn_Chon
            // 
            this.btn_Chon.Location = new System.Drawing.Point(49, 587);
            this.btn_Chon.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Chon.Name = "btn_Chon";
            this.btn_Chon.Size = new System.Drawing.Size(150, 44);
            this.btn_Chon.TabIndex = 6;
            this.btn_Chon.Text = "Chọn ";
            this.btn_Chon.UseVisualStyleBackColor = true;
            this.btn_Chon.Click += new System.EventHandler(this.btn_Chon_Click);
            // 
            // btn_TiepTuc
            // 
            this.btn_TiepTuc.Location = new System.Drawing.Point(447, 587);
            this.btn_TiepTuc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_TiepTuc.Name = "btn_TiepTuc";
            this.btn_TiepTuc.Size = new System.Drawing.Size(150, 44);
            this.btn_TiepTuc.TabIndex = 7;
            this.btn_TiepTuc.Text = "Tiếp tục";
            this.btn_TiepTuc.UseVisualStyleBackColor = true;
            this.btn_TiepTuc.Click += new System.EventHandler(this.btn_TiepTuc_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(906, 587);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(150, 44);
            this.btn_Thoat.TabIndex = 8;
            this.btn_Thoat.Text = "Thoát ";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // listKetQua
            // 
            this.listKetQua.FormattingEnabled = true;
            this.listKetQua.ItemHeight = 25;
            this.listKetQua.Location = new System.Drawing.Point(49, 687);
            this.listKetQua.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listKetQua.Name = "listKetQua";
            this.listKetQua.Size = new System.Drawing.Size(1506, 279);
            this.listKetQua.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(56, 637);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Kết quả";
            // 
            // lb_mabn
            // 
            this.lb_mabn.AutoSize = true;
            this.lb_mabn.Location = new System.Drawing.Point(20, 59);
            this.lb_mabn.Name = "lb_mabn";
            this.lb_mabn.Size = new System.Drawing.Size(150, 25);
            this.lb_mabn.TabIndex = 6;
            this.lb_mabn.Text = "Mã bệnh nhân";
            // 
            // cbb_mabn
            // 
            this.cbb_mabn.FormattingEnabled = true;
            this.cbb_mabn.Location = new System.Drawing.Point(262, 64);
            this.cbb_mabn.Name = "cbb_mabn";
            this.cbb_mabn.Size = new System.Drawing.Size(393, 33);
            this.cbb_mabn.TabIndex = 7;
            this.cbb_mabn.SelectedIndexChanged += new System.EventHandler(this.cbb_mabn_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1167);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listKetQua);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_TiepTuc);
            this.Controls.Add(this.btn_Chon);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Thẩm mỹ viện";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_DsDichVu;
        private System.Windows.Forms.ComboBox cbBox_DichVu;
        private System.Windows.Forms.TextBox txt_Nam;
        private System.Windows.Forms.TextBox txt_Thang;
        private System.Windows.Forms.TextBox txt_Ngay;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Chon;
        private System.Windows.Forms.Button btn_TiepTuc;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.ListBox listKetQua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbb_mabn;
        private System.Windows.Forms.Label lb_mabn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


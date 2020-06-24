namespace QL_KhoHang
{
    partial class fSuaNhanVien
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
            this.lsvSuaNhanVien = new System.Windows.Forms.ListView();
            this.stt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.diaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDiaChiMoi = new System.Windows.Forms.TextBox();
            this.tbEmailMoi = new System.Windows.Forms.TextBox();
            this.tbPhoneMoi = new System.Windows.Forms.TextBox();
            this.tbTenMoi = new System.Windows.Forms.TextBox();
            this.tbIdMoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDiaChiCu = new System.Windows.Forms.TextBox();
            this.tbEmailCu = new System.Windows.Forms.TextBox();
            this.tbPhoneCu = new System.Windows.Forms.TextBox();
            this.tbTenCu = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIdCu = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvSuaNhanVien
            // 
            this.lsvSuaNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stt,
            this.id,
            this.ten,
            this.phone,
            this.email,
            this.diaChi});
            this.lsvSuaNhanVien.FullRowSelect = true;
            this.lsvSuaNhanVien.GridLines = true;
            this.lsvSuaNhanVien.HideSelection = false;
            this.lsvSuaNhanVien.Location = new System.Drawing.Point(2, 1);
            this.lsvSuaNhanVien.Name = "lsvSuaNhanVien";
            this.lsvSuaNhanVien.Size = new System.Drawing.Size(891, 261);
            this.lsvSuaNhanVien.TabIndex = 0;
            this.lsvSuaNhanVien.UseCompatibleStateImageBehavior = false;
            this.lsvSuaNhanVien.View = System.Windows.Forms.View.Details;
            this.lsvSuaNhanVien.SelectedIndexChanged += new System.EventHandler(this.lsvSuaNhanVien_SelectedIndexChanged);
            // 
            // stt
            // 
            this.stt.Text = "stt";
            // 
            // id
            // 
            this.id.Text = "Mã";
            this.id.Width = 102;
            // 
            // ten
            // 
            this.ten.Text = "Họ tên";
            this.ten.Width = 236;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 119;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.Width = 156;
            // 
            // diaChi
            // 
            this.diaChi.Text = "Địa chỉ";
            this.diaChi.Width = 214;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbDiaChiMoi);
            this.panel1.Controls.Add(this.tbEmailMoi);
            this.panel1.Controls.Add(this.tbPhoneMoi);
            this.panel1.Controls.Add(this.tbTenMoi);
            this.panel1.Controls.Add(this.tbIdMoi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbDiaChiCu);
            this.panel1.Controls.Add(this.tbEmailCu);
            this.panel1.Controls.Add(this.tbPhoneCu);
            this.panel1.Controls.Add(this.tbTenCu);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbIdCu);
            this.panel1.Location = new System.Drawing.Point(2, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 265);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(571, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Thông tin mới";
            // 
            // tbDiaChiMoi
            // 
            this.tbDiaChiMoi.Location = new System.Drawing.Point(458, 214);
            this.tbDiaChiMoi.Name = "tbDiaChiMoi";
            this.tbDiaChiMoi.Size = new System.Drawing.Size(280, 20);
            this.tbDiaChiMoi.TabIndex = 16;
            // 
            // tbEmailMoi
            // 
            this.tbEmailMoi.Location = new System.Drawing.Point(458, 170);
            this.tbEmailMoi.Name = "tbEmailMoi";
            this.tbEmailMoi.Size = new System.Drawing.Size(280, 20);
            this.tbEmailMoi.TabIndex = 15;
            // 
            // tbPhoneMoi
            // 
            this.tbPhoneMoi.Location = new System.Drawing.Point(458, 125);
            this.tbPhoneMoi.Name = "tbPhoneMoi";
            this.tbPhoneMoi.Size = new System.Drawing.Size(280, 20);
            this.tbPhoneMoi.TabIndex = 14;
            // 
            // tbTenMoi
            // 
            this.tbTenMoi.Location = new System.Drawing.Point(458, 78);
            this.tbTenMoi.Name = "tbTenMoi";
            this.tbTenMoi.Size = new System.Drawing.Size(280, 20);
            this.tbTenMoi.TabIndex = 13;
            // 
            // tbIdMoi
            // 
            this.tbIdMoi.Location = new System.Drawing.Point(458, 31);
            this.tbIdMoi.Name = "tbIdMoi";
            this.tbIdMoi.Size = new System.Drawing.Size(280, 20);
            this.tbIdMoi.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Thông tin cũ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ tên";
            // 
            // tbDiaChiCu
            // 
            this.tbDiaChiCu.Location = new System.Drawing.Point(117, 214);
            this.tbDiaChiCu.Name = "tbDiaChiCu";
            this.tbDiaChiCu.Size = new System.Drawing.Size(280, 20);
            this.tbDiaChiCu.TabIndex = 6;
            // 
            // tbEmailCu
            // 
            this.tbEmailCu.Location = new System.Drawing.Point(117, 170);
            this.tbEmailCu.Name = "tbEmailCu";
            this.tbEmailCu.Size = new System.Drawing.Size(280, 20);
            this.tbEmailCu.TabIndex = 5;
            // 
            // tbPhoneCu
            // 
            this.tbPhoneCu.Location = new System.Drawing.Point(117, 125);
            this.tbPhoneCu.Name = "tbPhoneCu";
            this.tbPhoneCu.Size = new System.Drawing.Size(280, 20);
            this.tbPhoneCu.TabIndex = 4;
            // 
            // tbTenCu
            // 
            this.tbTenCu.Location = new System.Drawing.Point(117, 78);
            this.tbTenCu.Name = "tbTenCu";
            this.tbTenCu.Size = new System.Drawing.Size(280, 20);
            this.tbTenCu.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(792, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã";
            // 
            // tbIdCu
            // 
            this.tbIdCu.Location = new System.Drawing.Point(117, 31);
            this.tbIdCu.Name = "tbIdCu";
            this.tbIdCu.Size = new System.Drawing.Size(280, 20);
            this.tbIdCu.TabIndex = 0;
            // 
            // fSuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsvSuaNhanVien);
            this.Name = "fSuaNhanVien";
            this.Text = "Sửa nhân viên";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvSuaNhanVien;
        private System.Windows.Forms.ColumnHeader stt;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader ten;
        private System.Windows.Forms.ColumnHeader phone;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader diaChi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbIdCu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDiaChiMoi;
        private System.Windows.Forms.TextBox tbEmailMoi;
        private System.Windows.Forms.TextBox tbPhoneMoi;
        private System.Windows.Forms.TextBox tbTenMoi;
        private System.Windows.Forms.TextBox tbIdMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDiaChiCu;
        private System.Windows.Forms.TextBox tbEmailCu;
        private System.Windows.Forms.TextBox tbPhoneCu;
        private System.Windows.Forms.TextBox tbTenCu;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}
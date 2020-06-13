namespace QL_KhoHang
{
    partial class fSuaKhachHang
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
            this.lsvSuaKhachHang = new System.Windows.Forms.ListView();
            this.stt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.diaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIdCu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMaCu = new System.Windows.Forms.TextBox();
            this.tbTenCu = new System.Windows.Forms.TextBox();
            this.tbPhoneCu = new System.Windows.Forms.TextBox();
            this.tbEmailCu = new System.Windows.Forms.TextBox();
            this.tbDiaChiCu = new System.Windows.Forms.TextBox();
            this.tbIdMoi = new System.Windows.Forms.TextBox();
            this.tbMaMoi = new System.Windows.Forms.TextBox();
            this.tbTenMoi = new System.Windows.Forms.TextBox();
            this.tbPhoneMoi = new System.Windows.Forms.TextBox();
            this.tbEmailMoi = new System.Windows.Forms.TextBox();
            this.tbDiaChiMoi = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvSuaKhachHang
            // 
            this.lsvSuaKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stt,
            this.id,
            this.ma,
            this.ten,
            this.phone,
            this.email,
            this.diaChi});
            this.lsvSuaKhachHang.FullRowSelect = true;
            this.lsvSuaKhachHang.GridLines = true;
            this.lsvSuaKhachHang.HideSelection = false;
            this.lsvSuaKhachHang.Location = new System.Drawing.Point(0, 2);
            this.lsvSuaKhachHang.Name = "lsvSuaKhachHang";
            this.lsvSuaKhachHang.Size = new System.Drawing.Size(1058, 254);
            this.lsvSuaKhachHang.TabIndex = 0;
            this.lsvSuaKhachHang.UseCompatibleStateImageBehavior = false;
            this.lsvSuaKhachHang.View = System.Windows.Forms.View.Details;
            this.lsvSuaKhachHang.SelectedIndexChanged += new System.EventHandler(this.lsvSuaKhachHang_SelectedIndexChanged);
            // 
            // stt
            // 
            this.stt.Text = "stt";
            this.stt.Width = 44;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 77;
            // 
            // ma
            // 
            this.ma.Text = "Mã";
            this.ma.Width = 129;
            // 
            // ten
            // 
            this.ten.Text = "Họ tên";
            this.ten.Width = 233;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 134;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.Width = 184;
            // 
            // diaChi
            // 
            this.diaChi.Text = "Địa chỉ";
            this.diaChi.Width = 251;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.tbDiaChiMoi);
            this.panel1.Controls.Add(this.tbEmailMoi);
            this.panel1.Controls.Add(this.tbPhoneMoi);
            this.panel1.Controls.Add(this.tbTenMoi);
            this.panel1.Controls.Add(this.tbMaMoi);
            this.panel1.Controls.Add(this.tbIdMoi);
            this.panel1.Controls.Add(this.tbDiaChiCu);
            this.panel1.Controls.Add(this.tbEmailCu);
            this.panel1.Controls.Add(this.tbPhoneCu);
            this.panel1.Controls.Add(this.tbTenCu);
            this.panel1.Controls.Add(this.tbMaCu);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbIdCu);
            this.panel1.Location = new System.Drawing.Point(2, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 245);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thông tin cũ";
            // 
            // tbIdCu
            // 
            this.tbIdCu.Enabled = false;
            this.tbIdCu.Location = new System.Drawing.Point(116, 45);
            this.tbIdCu.Name = "tbIdCu";
            this.tbIdCu.Size = new System.Drawing.Size(297, 20);
            this.tbIdCu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(591, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thông tin mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Họ tên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Địa chỉ";
            // 
            // tbMaCu
            // 
            this.tbMaCu.Location = new System.Drawing.Point(116, 79);
            this.tbMaCu.Name = "tbMaCu";
            this.tbMaCu.Size = new System.Drawing.Size(297, 20);
            this.tbMaCu.TabIndex = 12;
            // 
            // tbTenCu
            // 
            this.tbTenCu.Location = new System.Drawing.Point(116, 116);
            this.tbTenCu.Name = "tbTenCu";
            this.tbTenCu.Size = new System.Drawing.Size(297, 20);
            this.tbTenCu.TabIndex = 13;
            // 
            // tbPhoneCu
            // 
            this.tbPhoneCu.Location = new System.Drawing.Point(116, 154);
            this.tbPhoneCu.Name = "tbPhoneCu";
            this.tbPhoneCu.Size = new System.Drawing.Size(297, 20);
            this.tbPhoneCu.TabIndex = 14;
            // 
            // tbEmailCu
            // 
            this.tbEmailCu.Location = new System.Drawing.Point(116, 186);
            this.tbEmailCu.Name = "tbEmailCu";
            this.tbEmailCu.Size = new System.Drawing.Size(297, 20);
            this.tbEmailCu.TabIndex = 15;
            // 
            // tbDiaChiCu
            // 
            this.tbDiaChiCu.Location = new System.Drawing.Point(116, 217);
            this.tbDiaChiCu.Name = "tbDiaChiCu";
            this.tbDiaChiCu.Size = new System.Drawing.Size(297, 20);
            this.tbDiaChiCu.TabIndex = 16;
            // 
            // tbIdMoi
            // 
            this.tbIdMoi.Enabled = false;
            this.tbIdMoi.Location = new System.Drawing.Point(460, 45);
            this.tbIdMoi.Name = "tbIdMoi";
            this.tbIdMoi.Size = new System.Drawing.Size(297, 20);
            this.tbIdMoi.TabIndex = 17;
            // 
            // tbMaMoi
            // 
            this.tbMaMoi.Location = new System.Drawing.Point(460, 79);
            this.tbMaMoi.Name = "tbMaMoi";
            this.tbMaMoi.Size = new System.Drawing.Size(297, 20);
            this.tbMaMoi.TabIndex = 18;
            // 
            // tbTenMoi
            // 
            this.tbTenMoi.Location = new System.Drawing.Point(460, 116);
            this.tbTenMoi.Name = "tbTenMoi";
            this.tbTenMoi.Size = new System.Drawing.Size(297, 20);
            this.tbTenMoi.TabIndex = 19;
            // 
            // tbPhoneMoi
            // 
            this.tbPhoneMoi.Location = new System.Drawing.Point(460, 154);
            this.tbPhoneMoi.Name = "tbPhoneMoi";
            this.tbPhoneMoi.Size = new System.Drawing.Size(297, 20);
            this.tbPhoneMoi.TabIndex = 20;
            // 
            // tbEmailMoi
            // 
            this.tbEmailMoi.Location = new System.Drawing.Point(460, 186);
            this.tbEmailMoi.Name = "tbEmailMoi";
            this.tbEmailMoi.Size = new System.Drawing.Size(297, 20);
            this.tbEmailMoi.TabIndex = 21;
            // 
            // tbDiaChiMoi
            // 
            this.tbDiaChiMoi.Location = new System.Drawing.Point(460, 216);
            this.tbDiaChiMoi.Name = "tbDiaChiMoi";
            this.tbDiaChiMoi.Size = new System.Drawing.Size(297, 20);
            this.tbDiaChiMoi.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(889, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 37);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fSuaKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsvSuaKhachHang);
            this.Name = "fSuaKhachHang";
            this.Text = "fSuaKhachHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvSuaKhachHang;
        private System.Windows.Forms.ColumnHeader stt;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader ma;
        private System.Windows.Forms.ColumnHeader ten;
        private System.Windows.Forms.ColumnHeader phone;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader diaChi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDiaChiMoi;
        private System.Windows.Forms.TextBox tbEmailMoi;
        private System.Windows.Forms.TextBox tbPhoneMoi;
        private System.Windows.Forms.TextBox tbTenMoi;
        private System.Windows.Forms.TextBox tbMaMoi;
        private System.Windows.Forms.TextBox tbIdMoi;
        private System.Windows.Forms.TextBox tbDiaChiCu;
        private System.Windows.Forms.TextBox tbEmailCu;
        private System.Windows.Forms.TextBox tbPhoneCu;
        private System.Windows.Forms.TextBox tbTenCu;
        private System.Windows.Forms.TextBox tbMaCu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIdCu;
    }
}
namespace QL_KhoHang
{
    partial class fDonVi
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
            this.lsvDonVi = new System.Windows.Forms.ListView();
            this.tbTenDonVi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvDonVi
            // 
            this.lsvDonVi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stt,
            this.id,
            this.ten});
            this.lsvDonVi.HideSelection = false;
            this.lsvDonVi.Location = new System.Drawing.Point(0, 0);
            this.lsvDonVi.Name = "lsvDonVi";
            this.lsvDonVi.Size = new System.Drawing.Size(343, 182);
            this.lsvDonVi.TabIndex = 0;
            this.lsvDonVi.UseCompatibleStateImageBehavior = false;
            this.lsvDonVi.View = System.Windows.Forms.View.Details;
            // 
            // tbTenDonVi
            // 
            this.tbTenDonVi.Location = new System.Drawing.Point(15, 263);
            this.tbTenDonVi.Name = "tbTenDonVi";
            this.tbTenDonVi.Size = new System.Drawing.Size(228, 20);
            this.tbTenDonVi.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(240, 330);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 36);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên đơn vị";
            // 
            // stt
            // 
            this.stt.Text = "stt";
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 86;
            // 
            // ten
            // 
            this.ten.Text = "Tên đơn vị";
            this.ten.Width = 193;
            // 
            // fDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 388);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.tbTenDonVi);
            this.Controls.Add(this.lsvDonVi);
            this.Name = "fDonVi";
            this.Text = "Đơn vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvDonVi;
        private System.Windows.Forms.ColumnHeader stt;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader ten;
        private System.Windows.Forms.TextBox tbTenDonVi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
    }
}
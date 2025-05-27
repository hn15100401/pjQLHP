namespace pjQuanLyHocPhi
{
    partial class FormLogout
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Thoat = new System.Windows.Forms.Label();
            this.lbl_NoiDung = new System.Windows.Forms.Label();
            this.btn_DangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lbl_Thoat);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 63);
            this.panel1.TabIndex = 0;
            // 
            // lbl_Thoat
            // 
            this.lbl_Thoat.AutoSize = true;
            this.lbl_Thoat.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thoat.ForeColor = System.Drawing.Color.White;
            this.lbl_Thoat.Location = new System.Drawing.Point(280, 9);
            this.lbl_Thoat.Name = "lbl_Thoat";
            this.lbl_Thoat.Size = new System.Drawing.Size(161, 38);
            this.lbl_Thoat.TabIndex = 0;
            this.lbl_Thoat.Text = "Đăng xuất";
            // 
            // lbl_NoiDung
            // 
            this.lbl_NoiDung.AutoSize = true;
            this.lbl_NoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NoiDung.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_NoiDung.Location = new System.Drawing.Point(178, 124);
            this.lbl_NoiDung.Name = "lbl_NoiDung";
            this.lbl_NoiDung.Size = new System.Drawing.Size(401, 32);
            this.lbl_NoiDung.TabIndex = 1;
            this.lbl_NoiDung.Text = "Bạn có chắc chắn muốn đăng xuất?";
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.BorderRadius = 10;
            this.btn_DangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DangXuat.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_DangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangXuat.ForeColor = System.Drawing.Color.White;
            this.btn_DangXuat.Location = new System.Drawing.Point(143, 223);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(180, 45);
            this.btn_DangXuat.TabIndex = 2;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(429, 223);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Hủy";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // FormLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 313);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btn_DangXuat);
            this.Controls.Add(this.lbl_NoiDung);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogout";
            this.Text = "FormLogout";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Thoat;
        private System.Windows.Forms.Label lbl_NoiDung;
        private Guna.UI2.WinForms.Guna2Button btn_DangXuat;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
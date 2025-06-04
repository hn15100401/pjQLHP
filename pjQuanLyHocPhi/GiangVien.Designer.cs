namespace pjQuanLyHocPhi
{
    partial class GiangVien
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_text = new System.Windows.Forms.Label();
            this.pn_button = new System.Windows.Forms.Panel();
            this.btn_DSLop = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Thaotac = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pn_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 100);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Azure;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbl_text, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1540, 100);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // lbl_text
            // 
            this.lbl_text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_text.AutoSize = true;
            this.lbl_text.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_text.Location = new System.Drawing.Point(564, 26);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(411, 48);
            this.lbl_text.TabIndex = 0;
            this.lbl_text.Text = "QUẢN LÝ GIẢNG VIÊN";
            // 
            // pn_button
            // 
            this.pn_button.BackColor = System.Drawing.Color.Azure;
            this.pn_button.Controls.Add(this.btn_DSLop);
            this.pn_button.Controls.Add(this.btn_Thaotac);
            this.pn_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_button.Location = new System.Drawing.Point(0, 100);
            this.pn_button.Name = "pn_button";
            this.pn_button.Size = new System.Drawing.Size(229, 560);
            this.pn_button.TabIndex = 5;
            // 
            // btn_DSLop
            // 
            this.btn_DSLop.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_DSLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DSLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DSLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DSLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DSLop.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_DSLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSLop.ForeColor = System.Drawing.Color.White;
            this.btn_DSLop.Location = new System.Drawing.Point(0, 116);
            this.btn_DSLop.Name = "btn_DSLop";
            this.btn_DSLop.Size = new System.Drawing.Size(229, 57);
            this.btn_DSLop.TabIndex = 1;
            this.btn_DSLop.Text = "Hiển Thị";
            this.btn_DSLop.Click += new System.EventHandler(this.btn_DSLop_Click);
            // 
            // btn_Thaotac
            // 
            this.btn_Thaotac.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_Thaotac.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Thaotac.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Thaotac.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Thaotac.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Thaotac.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Thaotac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thaotac.ForeColor = System.Drawing.Color.White;
            this.btn_Thaotac.Location = new System.Drawing.Point(0, 57);
            this.btn_Thaotac.Name = "btn_Thaotac";
            this.btn_Thaotac.Size = new System.Drawing.Size(229, 59);
            this.btn_Thaotac.TabIndex = 0;
            this.btn_Thaotac.Text = "Thao Tác";
            this.btn_Thaotac.Click += new System.EventHandler(this.btn_Thaotac_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(229, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1311, 560);
            this.panel2.TabIndex = 6;
            // 
            // GiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1540, 660);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pn_button);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GiangVien";
            this.Text = "GiangVien";
            this.Load += new System.EventHandler(this.GiangVien_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.pn_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Panel pn_button;
        private Guna.UI2.WinForms.Guna2Button btn_DSLop;
        private Guna.UI2.WinForms.Guna2Button btn_Thaotac;
        private System.Windows.Forms.Panel panel2;
    }
}
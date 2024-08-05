namespace APP_QuanLiDungCuAmNhac.UserControls
{
    partial class UC_ND_NND
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGVND = new System.Windows.Forms.DataGridView();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.DGVND_NND = new System.Windows.Forms.DataGridView();
            this.QL_NhomNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBBNND = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVND_NND)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVND
            // 
            this.DGVND.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.DGVND.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVND.Location = new System.Drawing.Point(21, 162);
            this.DGVND.Name = "DGVND";
            this.DGVND.ReadOnly = true;
            this.DGVND.RowHeadersWidth = 51;
            this.DGVND.RowTemplate.Height = 24;
            this.DGVND.Size = new System.Drawing.Size(426, 356);
            this.DGVND.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.BorderRadius = 10;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(473, 224);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 50);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = ">>";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(473, 334);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 51);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "<<";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // DGVND_NND
            // 
            this.DGVND_NND.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DGVND_NND.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.DGVND_NND.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVND_NND.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QL_NhomNguoiDung,
            this.NhanVien});
            this.DGVND_NND.Location = new System.Drawing.Point(588, 162);
            this.DGVND_NND.Name = "DGVND_NND";
            this.DGVND_NND.ReadOnly = true;
            this.DGVND_NND.RowHeadersWidth = 51;
            this.DGVND_NND.RowTemplate.Height = 24;
            this.DGVND_NND.Size = new System.Drawing.Size(443, 356);
            this.DGVND_NND.TabIndex = 3;
            // 
            // QL_NhomNguoiDung
            // 
            this.QL_NhomNguoiDung.DataPropertyName = "QL_NhomNguoiDung";
            this.QL_NhomNguoiDung.HeaderText = "";
            this.QL_NhomNguoiDung.MinimumWidth = 6;
            this.QL_NhomNguoiDung.Name = "QL_NhomNguoiDung";
            this.QL_NhomNguoiDung.ReadOnly = true;
            this.QL_NhomNguoiDung.Visible = false;
            this.QL_NhomNguoiDung.Width = 125;
            // 
            // NhanVien
            // 
            this.NhanVien.DataPropertyName = "NhanVien";
            this.NhanVien.HeaderText = "";
            this.NhanVien.MinimumWidth = 6;
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.ReadOnly = true;
            this.NhanVien.Visible = false;
            this.NhanVien.Width = 125;
            // 
            // CBBNND
            // 
            this.CBBNND.BackColor = System.Drawing.Color.Transparent;
            this.CBBNND.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBBNND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBNND.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBBNND.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBBNND.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBBNND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBBNND.ItemHeight = 30;
            this.CBBNND.Location = new System.Drawing.Point(594, 49);
            this.CBBNND.Name = "CBBNND";
            this.CBBNND.Size = new System.Drawing.Size(267, 36);
            this.CBBNND.TabIndex = 4;
            this.CBBNND.SelectedIndexChanged += new System.EventHandler(this.CBBNND_SelectedIndexChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(21, 125);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(255, 31);
            this.guna2HtmlLabel1.TabIndex = 8;
            this.guna2HtmlLabel1.Text = "Danh mục người dùng";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(588, 125);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(326, 31);
            this.guna2HtmlLabel2.TabIndex = 9;
            this.guna2HtmlLabel2.Text = "Danh mục nhóm người dùng";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(594, 12);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(272, 31);
            this.guna2HtmlLabel3.TabIndex = 10;
            this.guna2HtmlLabel3.Text = "Chọn nhóm người dùng";
            // 
            // UC_ND_NND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.CBBNND);
            this.Controls.Add(this.DGVND_NND);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.DGVND);
            this.Name = "UC_ND_NND";
            this.Size = new System.Drawing.Size(1072, 697);
            this.Load += new System.EventHandler(this.UC_ND_NND_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVND_NND)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVND;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private System.Windows.Forms.DataGridView DGVND_NND;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_NhomNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
        private Guna.UI2.WinForms.Guna2ComboBox CBBNND;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}

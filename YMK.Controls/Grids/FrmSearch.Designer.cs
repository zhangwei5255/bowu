namespace Win.YMK.Controls.Grids
{
    partial class FrmSearch
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnCalcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCol = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "検索内容：";
            // 
            // txtSearch
            // 
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSearch.Location = new System.Drawing.Point(173, 113);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(326, 21);
            this.txtSearch.TabIndex = 3;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.BtnSearch.Location = new System.Drawing.Point(268, 199);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(90, 31);
            this.BtnSearch.TabIndex = 5;
            this.BtnSearch.Text = "検索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnCalcel
            // 
            this.BtnCalcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCalcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCalcel.Font = new System.Drawing.Font("宋体", 12F);
            this.BtnCalcel.Location = new System.Drawing.Point(375, 198);
            this.BtnCalcel.Name = "BtnCalcel";
            this.BtnCalcel.Size = new System.Drawing.Size(90, 31);
            this.BtnCalcel.TabIndex = 6;
            this.BtnCalcel.Text = "キャンセル";
            this.BtnCalcel.UseVisualStyleBackColor = true;
            this.BtnCalcel.Click += new System.EventHandler(this.BtnCalcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "検索コラム：";
            // 
            // cmbCol
            // 
            this.cmbCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCol.FormattingEnabled = true;
            this.cmbCol.Location = new System.Drawing.Point(173, 70);
            this.cmbCol.Name = "cmbCol";
            this.cmbCol.Size = new System.Drawing.Size(185, 20);
            this.cmbCol.TabIndex = 8;
            // 
            // FrmSearch
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCalcel;
            this.ClientSize = new System.Drawing.Size(544, 265);
            this.ControlBox = false;
            this.Controls.Add(this.cmbCol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCalcel);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnCalcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCol;
    }
}
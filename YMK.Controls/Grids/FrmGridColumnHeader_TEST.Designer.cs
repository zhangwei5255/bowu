namespace JPBook2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridViewExt1 = new Win.YMK.Controls.Grids.GridViewExt(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericTextBox2 = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.numericTextBox1 = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExt1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewExt1
            // 
            this.gridViewExt1.AllowPaging = true;
            this.gridViewExt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridViewExt1.ColorEven = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridViewExt1.ColorOdd = System.Drawing.Color.White;
            this.gridViewExt1.ColumnHeaderRowCount = 2;
            this.gridViewExt1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridViewExt1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewExt1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewExt1.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewExt1.FindCol = 0;
            this.gridViewExt1.FindString = null;
            this.gridViewExt1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridViewExt1.HeaderCells = null;
            this.gridViewExt1.Location = new System.Drawing.Point(114, 184);
            this.gridViewExt1.Name = "gridViewExt1";
            this.gridViewExt1.PageIndex = 0;
            this.gridViewExt1.PageSize = 10;
            this.gridViewExt1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridViewExt1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridViewExt1.RowTemplate.Height = 21;
            this.gridViewExt1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridViewExt1.SelectionForeColor = System.Drawing.Color.Black;
            this.gridViewExt1.Size = new System.Drawing.Size(603, 150);
            this.gridViewExt1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.AllowNegative = true;
            this.numericTextBox2.DecimalPoint = '.';
            this.numericTextBox2.DigitsInGroup = 0;
            this.numericTextBox2.Double = 53620;
            this.numericTextBox2.Flags = 0;
            this.numericTextBox2.GroupSeparator = ',';
            this.numericTextBox2.Int = 53620;
            this.numericTextBox2.Location = new System.Drawing.Point(395, 13);
            this.numericTextBox2.Long = ((long)(53620));
            this.numericTextBox2.MaxDecimalPlaces = 4;
            this.numericTextBox2.MaxWholeDigits = 9;
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.NegativeSign = '-';
            this.numericTextBox2.OutPutFormat = "###,0";
            this.numericTextBox2.Prefix = "";
            this.numericTextBox2.RangeMax = 1.7976931348623157E+308;
            this.numericTextBox2.RangeMin = -1.7976931348623157E+308;
            this.numericTextBox2.Size = new System.Drawing.Size(100, 19);
            this.numericTextBox2.TabIndex = 2;
            this.numericTextBox2.Text = "53,620";
            this.numericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTextBox2.Value = "53620";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowNegative = true;
            this.numericTextBox1.DecimalPoint = '.';
            this.numericTextBox1.DigitsInGroup = 0;
            this.numericTextBox1.Double = 5200;
            this.numericTextBox1.Flags = 0;
            this.numericTextBox1.GroupSeparator = ',';
            this.numericTextBox1.Int = 5200;
            this.numericTextBox1.Location = new System.Drawing.Point(255, 13);
            this.numericTextBox1.Long = ((long)(5200));
            this.numericTextBox1.MaxDecimalPlaces = 4;
            this.numericTextBox1.MaxWholeDigits = 9;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.NegativeSign = '-';
            this.numericTextBox1.OutPutFormat = "#,##0";
            this.numericTextBox1.Prefix = "";
            this.numericTextBox1.RangeMax = 1.7976931348623157E+308;
            this.numericTextBox1.RangeMin = -1.7976931348623157E+308;
            this.numericTextBox1.Size = new System.Drawing.Size(100, 19);
            this.numericTextBox1.TabIndex = 1;
            this.numericTextBox1.Text = "5,200";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTextBox1.Value = "5200";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 542);
            this.Controls.Add(this.gridViewExt1);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExt1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox numericTextBox1;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox numericTextBox2;
        private Win.YMK.Controls.Grids.GridViewExt gridViewExt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}


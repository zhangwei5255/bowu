namespace bowu
{
    partial class FrmBowu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBowu));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblSh1 = new System.Windows.Forms.Label();
            this.lblSz1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblLt1 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.txtBody = new System.Windows.Forms.TextBox();
            this.wb2 = new Win.YMK.Controls.WebBrowsers.WebBrowser2();
            this.txtLtMax = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.txtLtMin = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.txtSZMax = new Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox();
            this.txtSZMin = new Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox();
            this.txtShMax = new Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox();
            this.txtShMin = new Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox();
            this.wb = new Win.YMK.Controls.WebBrowsers.WebBrowser2();
            this.LblStk = new System.Windows.Forms.Label();
            this.txtMax4 = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.txtMin4 = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // lblSh1
            // 
            this.lblSh1.AutoSize = true;
            this.lblSh1.Location = new System.Drawing.Point(66, 70);
            this.lblSh1.Name = "lblSh1";
            this.lblSh1.Size = new System.Drawing.Size(11, 12);
            this.lblSh1.TabIndex = 5;
            this.lblSh1.Text = "2";
            // 
            // lblSz1
            // 
            this.lblSz1.AutoSize = true;
            this.lblSz1.Location = new System.Drawing.Point(221, 70);
            this.lblSz1.Name = "lblSz1";
            this.lblSz1.Size = new System.Drawing.Size(11, 12);
            this.lblSz1.TabIndex = 9;
            this.lblSz1.Text = "2";
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblLt1
            // 
            this.lblLt1.AutoSize = true;
            this.lblLt1.Location = new System.Drawing.Point(64, 120);
            this.lblLt1.Name = "lblLt1";
            this.lblLt1.Size = new System.Drawing.Size(11, 12);
            this.lblLt1.TabIndex = 13;
            this.lblLt1.Text = "2";
            // 
            // timer3
            // 
            this.timer3.Interval = 5000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtBody.Location = new System.Drawing.Point(6, 158);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(313, 145);
            this.txtBody.TabIndex = 19;
            // 
            // wb2
            // 
            this.wb2.Location = new System.Drawing.Point(275, 15);
            this.wb2.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb2.Name = "wb2";
            this.wb2.Size = new System.Drawing.Size(54, 20);
            this.wb2.TabIndex = 18;
            this.wb2.Visible = false;
            this.wb2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb2_DocumentCompleted);
            // 
            // txtLtMax
            // 
            this.txtLtMax.AllowNegative = true;
            this.txtLtMax.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtLtMax.DecimalPoint = '.';
            this.txtLtMax.DigitsInGroup = 0;
            this.txtLtMax.Double = 9999D;
            this.txtLtMax.Flags = 0;
            this.txtLtMax.GroupSeparator = ',';
            this.txtLtMax.Int = 9999;
            this.txtLtMax.Location = new System.Drawing.Point(6, 133);
            this.txtLtMax.Long = ((long)(9999));
            this.txtLtMax.MaxDecimalPlaces = 4;
            this.txtLtMax.MaxWholeDigits = 9;
            this.txtLtMax.Name = "txtLtMax";
            this.txtLtMax.NegativeSign = '-';
            this.txtLtMax.OutPutFormat = "";
            this.txtLtMax.Prefix = "";
            this.txtLtMax.RangeMax = 1.7976931348623157E+308D;
            this.txtLtMax.RangeMin = -1.7976931348623157E+308D;
            this.txtLtMax.Size = new System.Drawing.Size(46, 19);
            this.txtLtMax.TabIndex = 17;
            this.txtLtMax.Text = "9999";
            this.txtLtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLtMax.Value = "9999";
            // 
            // txtLtMin
            // 
            this.txtLtMin.AllowNegative = true;
            this.txtLtMin.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtLtMin.DecimalPoint = '.';
            this.txtLtMin.DigitsInGroup = 0;
            this.txtLtMin.Double = -1D;
            this.txtLtMin.Flags = 0;
            this.txtLtMin.GroupSeparator = ',';
            this.txtLtMin.Int = -1;
            this.txtLtMin.Location = new System.Drawing.Point(6, 106);
            this.txtLtMin.Long = ((long)(-1));
            this.txtLtMin.MaxDecimalPlaces = 4;
            this.txtLtMin.MaxWholeDigits = 9;
            this.txtLtMin.Name = "txtLtMin";
            this.txtLtMin.NegativeSign = '-';
            this.txtLtMin.OutPutFormat = "";
            this.txtLtMin.Prefix = "";
            this.txtLtMin.RangeMax = 1.7976931348623157E+308D;
            this.txtLtMin.RangeMin = -1.7976931348623157E+308D;
            this.txtLtMin.Size = new System.Drawing.Size(46, 19);
            this.txtLtMin.TabIndex = 16;
            this.txtLtMin.Text = "-1";
            this.txtLtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLtMin.Value = "-1";
            // 
            // txtSZMax
            // 
            this.txtSZMax.AllowNegative = true;
            this.txtSZMax.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSZMax.DecimalPoint = '.';
            this.txtSZMax.DigitsInGroup = 0;
            this.txtSZMax.Double = 9999D;
            this.txtSZMax.Flags = 0;
            this.txtSZMax.GroupSeparator = ',';
            this.txtSZMax.Int = 9999;
            this.txtSZMax.Location = new System.Drawing.Point(168, 81);
            this.txtSZMax.Long = ((long)(9999));
            this.txtSZMax.MaxDecimalPlaces = 0;
            this.txtSZMax.MaxLength = 4;
            this.txtSZMax.MaxWholeDigits = 9;
            this.txtSZMax.Name = "txtSZMax";
            this.txtSZMax.NegativeSign = '-';
            this.txtSZMax.OutPutFormat = "";
            this.txtSZMax.Prefix = "";
            this.txtSZMax.RangeMax = 2147483647D;
            this.txtSZMax.RangeMin = -2147483648D;
            this.txtSZMax.Size = new System.Drawing.Size(42, 19);
            this.txtSZMax.TabIndex = 11;
            this.txtSZMax.Text = "9999";
            this.txtSZMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSZMax.Value = "9999";
            // 
            // txtSZMin
            // 
            this.txtSZMin.AllowNegative = true;
            this.txtSZMin.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSZMin.DecimalPoint = '.';
            this.txtSZMin.DigitsInGroup = 0;
            this.txtSZMin.Double = -1D;
            this.txtSZMin.Flags = 0;
            this.txtSZMin.GroupSeparator = ',';
            this.txtSZMin.Int = -1;
            this.txtSZMin.Location = new System.Drawing.Point(168, 56);
            this.txtSZMin.Long = ((long)(-1));
            this.txtSZMin.MaxDecimalPlaces = 0;
            this.txtSZMin.MaxLength = 4;
            this.txtSZMin.MaxWholeDigits = 9;
            this.txtSZMin.Name = "txtSZMin";
            this.txtSZMin.NegativeSign = '-';
            this.txtSZMin.OutPutFormat = "";
            this.txtSZMin.Prefix = "";
            this.txtSZMin.RangeMax = 2147483647D;
            this.txtSZMin.RangeMin = -2147483648D;
            this.txtSZMin.Size = new System.Drawing.Size(42, 19);
            this.txtSZMin.TabIndex = 8;
            this.txtSZMin.Text = "-1";
            this.txtSZMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSZMin.Value = "-1";
            // 
            // txtShMax
            // 
            this.txtShMax.AllowNegative = true;
            this.txtShMax.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtShMax.DecimalPoint = '.';
            this.txtShMax.DigitsInGroup = 0;
            this.txtShMax.Double = 9999D;
            this.txtShMax.Flags = 0;
            this.txtShMax.GroupSeparator = ',';
            this.txtShMax.Int = 9999;
            this.txtShMax.Location = new System.Drawing.Point(6, 81);
            this.txtShMax.Long = ((long)(9999));
            this.txtShMax.MaxDecimalPlaces = 0;
            this.txtShMax.MaxLength = 4;
            this.txtShMax.MaxWholeDigits = 9;
            this.txtShMax.Name = "txtShMax";
            this.txtShMax.NegativeSign = '-';
            this.txtShMax.OutPutFormat = "";
            this.txtShMax.Prefix = "";
            this.txtShMax.RangeMax = 2147483647D;
            this.txtShMax.RangeMin = -2147483648D;
            this.txtShMax.Size = new System.Drawing.Size(46, 19);
            this.txtShMax.TabIndex = 7;
            this.txtShMax.Text = "9999";
            this.txtShMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShMax.Value = "9999";
            // 
            // txtShMin
            // 
            this.txtShMin.AllowNegative = true;
            this.txtShMin.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtShMin.DecimalPoint = '.';
            this.txtShMin.DigitsInGroup = 0;
            this.txtShMin.Double = -1D;
            this.txtShMin.Flags = 0;
            this.txtShMin.GroupSeparator = ',';
            this.txtShMin.Int = -1;
            this.txtShMin.Location = new System.Drawing.Point(6, 56);
            this.txtShMin.Long = ((long)(-1));
            this.txtShMin.MaxDecimalPlaces = 0;
            this.txtShMin.MaxLength = 4;
            this.txtShMin.MaxWholeDigits = 9;
            this.txtShMin.Name = "txtShMin";
            this.txtShMin.NegativeSign = '-';
            this.txtShMin.OutPutFormat = "";
            this.txtShMin.Prefix = "";
            this.txtShMin.RangeMax = 2147483647D;
            this.txtShMin.RangeMin = -2147483648D;
            this.txtShMin.Size = new System.Drawing.Size(46, 19);
            this.txtShMin.TabIndex = 4;
            this.txtShMin.Text = "-1";
            this.txtShMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShMin.Value = "-1";
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(200, 15);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(54, 20);
            this.wb.TabIndex = 1;
            this.wb.Visible = false;
            this.wb.NavigateError += new Win.YMK.Controls.WebBrowsers.WebBrowserNavigateErrorEventHandler(this.wb_NavigateError);
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb_Navigated);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            // 
            // LblStk
            // 
            this.LblStk.AutoSize = true;
            this.LblStk.Location = new System.Drawing.Point(12, 15);
            this.LblStk.Name = "LblStk";
            this.LblStk.Size = new System.Drawing.Size(35, 12);
            this.LblStk.TabIndex = 20;
            this.LblStk.Text = "進捗：";
            // 
            // txtMax4
            // 
            this.txtMax4.AllowNegative = true;
            this.txtMax4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMax4.DecimalPoint = '.';
            this.txtMax4.DigitsInGroup = 0;
            this.txtMax4.Double = 9999D;
            this.txtMax4.Flags = 0;
            this.txtMax4.GroupSeparator = ',';
            this.txtMax4.Int = 9999;
            this.txtMax4.Location = new System.Drawing.Point(168, 133);
            this.txtMax4.Long = ((long)(9999));
            this.txtMax4.MaxDecimalPlaces = 4;
            this.txtMax4.MaxWholeDigits = 9;
            this.txtMax4.Name = "txtMax4";
            this.txtMax4.NegativeSign = '-';
            this.txtMax4.OutPutFormat = "";
            this.txtMax4.Prefix = "";
            this.txtMax4.RangeMax = 1.7976931348623157E+308D;
            this.txtMax4.RangeMin = -1.7976931348623157E+308D;
            this.txtMax4.Size = new System.Drawing.Size(46, 19);
            this.txtMax4.TabIndex = 23;
            this.txtMax4.Text = "9999";
            this.txtMax4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMax4.Value = "9999";
            // 
            // txtMin4
            // 
            this.txtMin4.AllowNegative = true;
            this.txtMin4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMin4.DecimalPoint = '.';
            this.txtMin4.DigitsInGroup = 0;
            this.txtMin4.Double = -1D;
            this.txtMin4.Flags = 0;
            this.txtMin4.GroupSeparator = ',';
            this.txtMin4.Int = -1;
            this.txtMin4.Location = new System.Drawing.Point(168, 106);
            this.txtMin4.Long = ((long)(-1));
            this.txtMin4.MaxDecimalPlaces = 4;
            this.txtMin4.MaxWholeDigits = 9;
            this.txtMin4.Name = "txtMin4";
            this.txtMin4.NegativeSign = '-';
            this.txtMin4.OutPutFormat = "";
            this.txtMin4.Prefix = "";
            this.txtMin4.RangeMax = 1.7976931348623157E+308D;
            this.txtMin4.RangeMin = -1.7976931348623157E+308D;
            this.txtMin4.Size = new System.Drawing.Size(46, 19);
            this.txtMin4.TabIndex = 22;
            this.txtMin4.Text = "-1";
            this.txtMin4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMin4.Value = "-1";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(226, 120);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(11, 12);
            this.lbl4.TabIndex = 21;
            this.lbl4.Text = "2";
            // 
            // timer4
            // 
            this.timer4.Interval = 5000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // FrmBowu
            // 
            this.ClientSize = new System.Drawing.Size(341, 48);
            this.Controls.Add(this.txtMax4);
            this.Controls.Add(this.txtMin4);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.LblStk);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.wb2);
            this.Controls.Add(this.txtLtMax);
            this.Controls.Add(this.txtLtMin);
            this.Controls.Add(this.lblLt1);
            this.Controls.Add(this.txtSZMax);
            this.Controls.Add(this.lblSz1);
            this.Controls.Add(this.txtSZMin);
            this.Controls.Add(this.txtShMax);
            this.Controls.Add(this.lblSh1);
            this.Controls.Add(this.txtShMin);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBowu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmBowu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private Win.YMK.Controls.WebBrowsers.WebBrowser2 wb;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox txtShMin;
        private System.Windows.Forms.Label lblSh1;
        private Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox txtShMax;
        private Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox txtSZMax;
        private System.Windows.Forms.Label lblSz1;
        private Win.YMK.Controls.InputMan.TextBoxs.IntegerTextBox txtSZMin;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblLt1;
        private System.Windows.Forms.Timer timer3;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox txtLtMin;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox txtLtMax;
        private Win.YMK.Controls.WebBrowsers.WebBrowser2 wb2;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label LblStk;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox txtMax4;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox txtMin4;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Timer timer4;
    }
}

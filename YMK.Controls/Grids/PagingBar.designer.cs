namespace Win.YMK.Controls.Grids
{
    partial class PagingBar
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLast = new System.Windows.Forms.LinkLabel();
            this.linkPre = new System.Windows.Forms.LinkLabel();
            this.linkNext = new System.Windows.Forms.LinkLabel();
            this.linkFirst = new System.Windows.Forms.LinkLabel();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.txtPage = new Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox();
            this.SuspendLayout();
            // 
            // linkLast
            // 
            this.linkLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLast.AutoSize = true;
            this.linkLast.Location = new System.Drawing.Point(341, 6);
            this.linkLast.Name = "linkLast";
            this.linkLast.Size = new System.Drawing.Size(17, 12);
            this.linkLast.TabIndex = 6;
            this.linkLast.TabStop = true;
            this.linkLast.Tag = "3";
            this.linkLast.Text = ">>";
            this.linkLast.Click += new System.EventHandler(this.linkLast_Click);
            // 
            // linkPre
            // 
            this.linkPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkPre.AutoSize = true;
            this.linkPre.Location = new System.Drawing.Point(202, 6);
            this.linkPre.Name = "linkPre";
            this.linkPre.Size = new System.Drawing.Size(11, 12);
            this.linkPre.TabIndex = 2;
            this.linkPre.TabStop = true;
            this.linkPre.Tag = "1";
            this.linkPre.Text = "<";
            this.linkPre.Click += new System.EventHandler(this.linkPre_Click);
            // 
            // linkNext
            // 
            this.linkNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkNext.AutoSize = true;
            this.linkNext.Location = new System.Drawing.Point(328, 5);
            this.linkNext.Name = "linkNext";
            this.linkNext.Size = new System.Drawing.Size(11, 12);
            this.linkNext.TabIndex = 5;
            this.linkNext.TabStop = true;
            this.linkNext.Tag = "2";
            this.linkNext.Text = ">";
            this.linkNext.Click += new System.EventHandler(this.linkNext_Click);
            // 
            // linkFirst
            // 
            this.linkFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFirst.AutoSize = true;
            this.linkFirst.Location = new System.Drawing.Point(183, 6);
            this.linkFirst.Name = "linkFirst";
            this.linkFirst.Size = new System.Drawing.Size(17, 12);
            this.linkFirst.TabIndex = 1;
            this.linkFirst.TabStop = true;
            this.linkFirst.Tag = "0";
            this.linkFirst.Text = "<<";
            this.linkFirst.Click += new System.EventHandler(this.linkFirst_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(292, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(3, 6);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(47, 12);
            this.lblPage.TabIndex = 0;
            this.lblPage.Text = "第0/0页";
            // 
            // txtPage
            // 
            this.txtPage.AllowNegative = true;
            this.txtPage.DecimalPoint = '.';
            this.txtPage.DigitsInGroup = 0;
            this.txtPage.Double = 0;
            this.txtPage.Flags = 0;
            this.txtPage.GroupSeparator = ',';
            this.txtPage.Int = 0;
            this.txtPage.Location = new System.Drawing.Point(214, 2);
            this.txtPage.Long = ((long)(0));
            this.txtPage.MaxDecimalPlaces = 4;
            this.txtPage.MaxLength = 9;
            this.txtPage.MaxWholeDigits = 9;
            this.txtPage.Name = "txtPage";
            this.txtPage.NegativeSign = '-';
            this.txtPage.OutPutFormat = "#,##0";
            this.txtPage.Prefix = "";
            this.txtPage.RangeMax = 1.7976931348623157E+308;
            this.txtPage.RangeMin = -1.7976931348623157E+308;
            this.txtPage.Size = new System.Drawing.Size(78, 19);
            this.txtPage.TabIndex = 7;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPage.Value = "";
            // 
            // PagingBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.linkFirst);
            this.Controls.Add(this.linkNext);
            this.Controls.Add(this.linkPre);
            this.Controls.Add(this.linkLast);
            this.Name = "PagingBar";
            this.Size = new System.Drawing.Size(361, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLast;
        private System.Windows.Forms.LinkLabel linkPre;
        private System.Windows.Forms.LinkLabel linkNext;
        private System.Windows.Forms.LinkLabel linkFirst;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblPage;
        private Win.YMK.Controls.InputMan.TextBoxs.NumericTextBox txtPage;
    }
}

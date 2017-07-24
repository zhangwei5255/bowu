namespace bowu_ts
{
    partial class FrmTs
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
            this.txtBody = new System.Windows.Forms.TextBox();
            this.wb = new Win.YMK.Controls.WebBrowsers.WebBrowser2();
            this.wb2 = new Win.YMK.Controls.WebBrowsers.WebBrowser2();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Location = new System.Drawing.Point(0, 0);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(538, 327);
            this.txtBody.TabIndex = 0;
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(2, 26);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(52, 28);
            this.wb.TabIndex = 1;
            this.wb.Visible = false;
            this.wb.NavigateError += new Win.YMK.Controls.WebBrowsers.WebBrowserNavigateErrorEventHandler(this.wb_NavigateError);
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            // 
            // wb2
            // 
            this.wb2.Location = new System.Drawing.Point(0, 0);
            this.wb2.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb2.Name = "wb2";
            this.wb2.Size = new System.Drawing.Size(54, 20);
            this.wb2.TabIndex = 19;
            this.wb2.Visible = false;
            this.wb2.NavigateError += new Win.YMK.Controls.WebBrowsers.WebBrowserNavigateErrorEventHandler(this.wb2_NavigateError);
            this.wb2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb2_DocumentCompleted);
            this.wb2.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb2_Navigated);
            this.wb2.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb2_Navigating);
            // 
            // FrmTs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 327);
            this.Controls.Add(this.wb2);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.txtBody);
            this.Name = "FrmTs";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmTs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBody;
        private Win.YMK.Controls.WebBrowsers.WebBrowser2 wb;
        private Win.YMK.Controls.WebBrowsers.WebBrowser2 wb2;
    }
}


namespace Win.YMK.Controls.HttpImages
{
	partial class HttpImage
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

		#region 组件设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.wbImage = new System.Windows.Forms.WebBrowser();
			this.btnAddImg = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// wbImage
			// 
			this.wbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.wbImage.Location = new System.Drawing.Point(0, 0);
			this.wbImage.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbImage.Name = "wbImage";
			this.wbImage.ScrollBarsEnabled = false;
			this.wbImage.Size = new System.Drawing.Size(400, 366);
			this.wbImage.TabIndex = 0;
			this.wbImage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbImage_DocumentCompleted);
			// 
			// btnAddImg
			// 
			this.btnAddImg.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAddImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAddImg.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAddImg.ForeColor = System.Drawing.Color.Black;
			this.btnAddImg.Location = new System.Drawing.Point(150, 372);
			this.btnAddImg.Name = "btnAddImg";
			this.btnAddImg.Size = new System.Drawing.Size(100, 28);
			this.btnAddImg.TabIndex = 17;
			this.btnAddImg.Text = "上传图片";
			this.btnAddImg.UseVisualStyleBackColor = false;
			this.btnAddImg.Click += new System.EventHandler(this.btnAddImg_Click);
			// 
			// HttpImage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.btnAddImg);
			this.Controls.Add(this.wbImage);
			this.Name = "HttpImage";
			this.Size = new System.Drawing.Size(400, 400);
			this.ResumeLayout(false);

		}
		#endregion
		private System.Windows.Forms.WebBrowser wbImage;
		internal System.Windows.Forms.Button btnAddImg;
	}
}

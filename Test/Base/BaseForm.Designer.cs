namespace JPBook.YMK.UI.Base
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rootState = new JPBook.YMK.UI.Base.Rooter();
            this.Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuFormClose = new System.Windows.Forms.ToolStripMenuItem();
            this.hdTitle = new JPBook.YMK.UI.Base.Header();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.rootState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 81);
            this.panel1.TabIndex = 1;
            // 
            // rootState
            // 
            this.rootState.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rootState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rootState.Location = new System.Drawing.Point(0, 60);
            this.rootState.Name = "rootState";
            this.rootState.Size = new System.Drawing.Size(782, 21);
            this.rootState.TabIndex = 0;
            this.rootState.TabStop = false;
            // 
            // Notify
            // 
            this.Notify.ContextMenuStrip = this.contextMenuStrip1;
            this.Notify.Text = "notifyIcon1";
            this.Notify.Visible = true;
            this.Notify.DoubleClick += new System.EventHandler(this.Notify_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFormClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // MenuFormClose
            // 
            this.MenuFormClose.Name = "MenuFormClose";
            this.MenuFormClose.Size = new System.Drawing.Size(112, 22);
            this.MenuFormClose.Text = "閉じる";
            this.MenuFormClose.Click += new System.EventHandler(this.MenuFormClose_Click);
            // 
            // hdTitle
            // 
            this.hdTitle.BackColor = System.Drawing.SystemColors.Control;
            this.hdTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdTitle.Location = new System.Drawing.Point(0, 0);
            this.hdTitle.Name = "hdTitle";
            this.hdTitle.Size = new System.Drawing.Size(782, 50);
            this.hdTitle.TabIndex = 0;
            this.hdTitle.TabStop = false;
            this.hdTitle.VolumeName = "中级(上)";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "JP.ico");
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 526);
            this.Controls.Add(this.hdTitle);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.BaseForm_ClientSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseForm_KeyPress);
            this.Resize += new System.EventHandler(this.BaseForm_Resize);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel panel1;
        private Header hdTitle;
        private Rooter rootState;
        private System.Windows.Forms.NotifyIcon Notify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFormClose;
        private System.Windows.Forms.ImageList imageList1;
    }
}
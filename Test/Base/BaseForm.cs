using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMK.Commons.Messages;

namespace JPBook.YMK.UI.Base
{
    public partial class BaseForm : Form
    {
        //private int _closeFrmReason;                 //0:フォーム右上の「X」ボタンをクリックする
        private Color preColor;                     //元背景色を回避する　add by I.TYOU 20140114
        //メッセージ
        public Msg msg;

        //add by zhangwei 20130705 start
        private bool _autoControlSize = false;       //フォームのリサイズしたら、フォーム比率に従ってコントロールのサイズも変化する
        Hashtable htCtrlsInfo = new Hashtable();
        Single _frmWid;
        Single _frmHgt;
        private class ControlPositionType
        {
            public Single left;
            public Single top;
            public Single width;
            public Single height;
            public Single fontSize;
        }
        //add by zhangwei 20130705 end

        //add by zhangwei 20150106 start
        //ウィンドウの状態を保存するためのフィールド
        private FormWindowState windowState;
        //add by zhangwei 20150106 end

        public BaseForm()
        {
            InitializeComponent();

            // CloseFrmReason = 0;

            //WinVar.curForm = this;                    //カレントのフォームをセット

            //delete by I.TYOU 20150219 「デザインモードでXMLパスが見つかりません」というエラーの対応　共通フォームから各フォームに移す　start
            //メッセージのインストール
            //msg = Msg.GetInstance();
            //delete by I.TYOU 20150219「デザインモードでXMLパスが見つかりません」というエラーの対応　共通フォームから各フォームに移す end

            this.ShowInTaskbar = false;               //フォームが任務バーに隠す
            windowState = WindowState;                //add by zhangwei 20150106
        }

        ///// <summary>
        ///// ファームをクローズする原因（0:フォーム右上の「X」ボタン）
        ///// </summary>
        //public int CloseFrmReason
        //{
        //    get
        //    {
        //        return this._closeFrmReason;
        //    }
        //    set
        //    {
        //        this._closeFrmReason = value;
        //    }
        //}
        /// <summary>
        /// 標準日本語の冊数名
        /// </summary>
        public String VolumeName
        {
            get
            {
                return this.hdTitle.VolumeName;
            }
            set
            {
                this.hdTitle.VolumeName = value;
            }
        }

        /// <summary>
        /// ヘッダのタイトル
        /// </summary>
        public String HeadTitle
        {
            get
            {
                return this.hdTitle.LblTitle.Text;
            }
            set
            {
                this.hdTitle.LblTitle.Text = value;
            }
        }

        //add by I.TYOU 20140519 start
        /// <summary>
        /// ヘッダの可視
        /// </summary>
        public Boolean HeadVisible
        {
            get
            {
                return this.hdTitle.Visible;
            }
            set
            {
                this.hdTitle.Visible = value;
            }
        }
        //add by I.TYOU 20140519 end



        /// <summary>
        /// フォームを表す
        /// </summary>
        public void Show()
        {
            this.Notify.Visible = true;
            base.Show();
        }

        public void Close()
        {
            Notify.Dispose();
            Notify = null;
            base.Close();
        }

        /// <summary>
        /// フォームを表す
        /// </summary>
        public void ShowDialog()
        {
            this.Notify.Visible = true;
            base.ShowDialog();

        }


        //add by zhangwei 20130705 start
        [Browsable(true)]
        [Description("フォームのリサイズしたら、フォーム比率に従ってコントロールのサイズも変化する")]
        public bool AutoControlSize
        {
            get
            {
                return _autoControlSize;
            }
            set
            {
                _autoControlSize = value;
            }
        }


        private void BaseForm_Resize(object sender, EventArgs e)
        {
            //最小化時何もしない
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            if (AutoControlSize == true)
            {
                if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0)
                {
                    return;
                }

                //SaveSizesメソッドを呼び出さない場合
                if (htCtrlsInfo.Count == 0)
                {
                    return;
                }

                ResizeControls(this);
            }
        }
        //add by zhangwei 20130705 end

        /// <summary>
        ///BaseFormBean_Loadイベント
        /// </summary>
        /// <param name="sender">イベントが起こったオブジェクト</param>
        /// <param name="e">イベント</param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.Notify.Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)imageList1.Images[0]).GetHicon());

            //コントロール背景色をセットする
            SetControlBackColor(this.Controls);

            //add by zhangwei 20130705 start
            if (AutoControlSize == true)
            {
                SaveSizes(this);

                //フォームのサイズを退避する
                _frmWid = ClientRectangle.Width;
                _frmHgt = ClientRectangle.Height;

            }
            //add by zhangwei 20130705 end
        }

        public void Hide()
        {

            base.Hide();
            Notify.Visible = false;
        }

        /// <summary>
        /// Returnキー（Enterキー）が押された場合、ProcessTabKeyメソッドを使用する
        /// </summary>
        /// <param name="sender">イベントが起こったオブジェクト</param>
        /// <param name="e">キープレスイベントアーグス</param>
        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    ProcessTabKey(true);
            //}

        }

        /// <summary>
        /// BaseForm_KeyDownイベント
        /// </summary>
        /// <param name="sender">イベントが起こったオブジェクト</param>
        /// <param name="e">キープレスイベントアーグス</param>
        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            //「Ctrl+Enter」キーが押下された場合
            if (e.Control && e.KeyCode == Keys.Return)
            {
                switch (this.WindowState)
                {
                    case FormWindowState.Normal:
                        this.WindowState = FormWindowState.Maximized;
                        break;
                    case FormWindowState.Maximized:
                        this.WindowState = FormWindowState.Normal;
                        break;
                }

                return;
            }

            if (e.Shift && e.KeyCode == Keys.Return)
            {
                return;
            }

            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }

        ///// <summary>
        ///// 閉じる（Close）機能の無効化
        ///// ・「閉じる」ボタンが無効化し押下不可
        ///// ・システムメニューの「閉じる」非表示
        ///// ・「Alt」+「F4」キー無効
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        const int CS_NOCLOSE = 0x200;
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

        //        return cp;
        //    }
        //        //}

        /// <summary>
        /// フォームのクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Notify != null)
            {
                Notify.Dispose();
                Notify = null;
            }

            //delete by I.TYOU 20150106 start
            ////フォーム右上の「X」ボタンをクリックする場合
            //if (CloseFrmReason == 0)
            //{
            //    //プログラムを閉じる
            //    Application.ExitThread();
            //}
            //delete by I.TYOU 20150106 end

            ////add by I.TYOU 20150106 start
            ////フォームを閉じる時、タスクトレイに表示されている場合は閉じずに非表示
            //if (Notify.Visible)
            //{
            //    e.Cancel = true;
            //    this.Hide();
            //}
            //add by I.TYOU 20150106 start

        }

        /// <summary>
        /// フォームに各コントロールのEnterイベント
        /// </summary>
        /// <param name="sender">イベントが起こったオブジェクト</param>
        /// <param name="e">イベント</param>
        private void ctl_Enter(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;
            preColor = ctl.BackColor;    //元背景色を格納する add by I.TYOU 20130114 
            //フォーカスを得た時のコントロール背景色をセットする
            ctl.BackColor = Color.FromArgb(255, 224, 192);
        }

        /// <summary>
        /// フォームに各コントロールのLeaveイベント
        /// </summary>
        /// <param name="sender">イベントが起こったオブジェクト</param>
        /// <param name="e">イベント</param>
        private void ctl_Leave(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;
            //フォーカスを失った時のコントロール背景色をセットする
            //ctl.BackColor = System.Drawing.SystemColors.Window;
            ctl.BackColor = preColor;   //元背景色を回復する add by I.TYOU 20130114 

        }

        /// <summary>
        /// コントロール背景色をセットする
        /// </summary>
        /// <param name="ctls"></param>
        private void SetControlBackColor(Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                if (ctl.Controls.Count == 0)
                {
                    ctl.Enter += new EventHandler(ctl_Enter);
                    ctl.Leave += new EventHandler(ctl_Leave);
                }
                else
                {
                    SetControlBackColor(ctl.Controls);
                }
            }
        }

        //add by zhangwei 20130705 start
        private void SaveSizes(Control curCtl)
        {
            ControlPositionType cpt;

            foreach (Control ctl in curCtl.Controls)
            {
                cpt = new ControlPositionType();
                cpt.left = ctl.Left;
                cpt.top = ctl.Top;
                cpt.width = ctl.Width;
                cpt.height = ctl.Height;
                cpt.fontSize = ctl.Font.SizeInPoints;

                htCtrlsInfo[GetControlId(ctl)] = cpt;

                if (ctl.HasChildren)
                {
                    SaveSizes(ctl);
                }
            }
        }

        private String GetControlId(Control ctl)
        {
            String controlId = ctl.Name;
            if ((ctl.Parent as Form) == null)
            {
                controlId += GetControlId(ctl.Parent);
            }

            return controlId;

        }

        private void ResizeControls(Control curCtl)
        {
            ControlPositionType cpt;
            Single xScale;
            Single yScale;

            //フォーム変化前後比率を取得する
            xScale = ClientRectangle.Width / _frmWid;
            yScale = ClientRectangle.Height / _frmHgt;

            foreach (Control ctl in curCtl.Controls)
            {
                cpt = (ControlPositionType)htCtrlsInfo[GetControlId(ctl)];
                ctl.Left = (int)(cpt.left * xScale);
                ctl.Top = (int)(cpt.top * yScale);
                ctl.Width = (int)(cpt.width * xScale);
                if (ctl.GetType() != typeof(ComboBox))
                {
                    //Cannot change height of ComboBoxes.
                    ctl.Height = (int)(cpt.height * yScale);

                }
                ctl.Font = new Font(ctl.Font.Name, cpt.fontSize * yScale, ctl.Font.Style);

                if (ctl.HasChildren)
                {
                    ResizeControls(ctl);
                }
            }

        }

        //add by zhangwei 20130705 end

        //add by zhangwei 20150106 start
        private void BaseForm_ClientSizeChanged(object sender, EventArgs e)
        {
            //ウィンドウが最小化された場合はフォームを非表示
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            //最小化以外の場合はウィンドウの状態を保存しておく
            else
            {
                windowState = WindowState;
            }
        }

        private void Notify_DoubleClick(object sender, EventArgs e)
        {
            //ウィンドウを表示、保存しておいた状態に戻し、アクティブ化する
            this.Show();
            this.WindowState = windowState;
            this.Activate();
        }

        private void MenuFormClose_Click(object sender, EventArgs e)
        {
            //NotifyIconのコンテキストメニューで閉じるメニューを実行した場合
            //NotifyIconを非表示にしてアプリケーションを終了する
            //Notify.Visible = false;
            Notify.Dispose();
            Notify = null;
            Application.Exit();
        }
        //add by zhangwei 20150106 end


        ///// <summary>
        ///// ファームのBaseForm_SizeChangedイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BaseForm_SizeChanged(object sender, EventArgs e)
        //{
        //    //フォームの右上の「最小」ボタンをクリックする場合
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        CloseFrmReason = 2;
        //        this.MyHide();　　　　　　　　　　　　　　　　　　　　　//元フォームを隠す
        //        //NtfIcon.Visible = true;　　　　　　　　　　　　　　　 //通知区域を表す
        //    }

        //}

        ///// <summary>
        ///// NtfIcon_DoubleClickイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void NtfIcon_DoubleClick(object sender, EventArgs e)
        //{
        //    this.MyShow();                                            //元フォームを表す                                           
        //    WindowState = FormWindowState.Normal;                   //フォームのサイズをセット
        //    //NtfIcon.Visible = false;                                //通知区域を隠す
        //}

    }
}

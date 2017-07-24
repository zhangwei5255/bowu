using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMK.Commons.Messages;

namespace bowu
{
    static class Program
    {
        /// <summar
        ///CS実行開始ポイント
        /// </summary>
        //[STAThread]
        public static string userID;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //delete by zhangwei 201510106 通知地域メニュの改善「NotifyIconをbaseFormに張り付ける」 start
            ////  System.Resources.ResourceManager resources = new System.Resources.ResourceManager("myResource", System.Reflection.Assembly.GetExecutingAssembly());
            //NotifyIcon ni = new NotifyIcon();

            //  //ni.BalloonTipTitle = "";

            //  //ni.ContextMenuStrip = contextMenu;
            //  ni.Icon = new System.Drawing.Icon(Application.StartupPath + @"\JP.ico");
            //  ni.Text = "標準日本語";
            //  ni.Visible = true;
            //  ni.MouseClick += delegate(object sender, MouseEventArgs e)
            //  {
            //      // ni.ShowBalloonTip(0);
            //      //frm.Show();

            //      Form curForm = WinVar.curForm;
            //      //add by i.tyou 20130628 start
            //      //「データ管理プロセス」が起動された場合
            //      if (curForm.Tag == WinKeys.THREAD_WAITE_FOR_DATAMGN)
            //      {
            //          return;
            //      }
            //      //add by i.tyou 20130628 end
            //      curForm.Show();

            //      //ファームを使う時　最もフロントエンドに現す
            //      curForm.TopMost = true;
            //      curForm.TopMost = false;

            //      //curForm.Visible = true;
            //      if (curForm.WindowState == FormWindowState.Minimized)
            //      {
            //          curForm.WindowState = FormWindowState.Normal;
            //      }

            //  };
            //delete by zhangwei 201510106 通知地域メニュの改善「NotifyIconをbaseFormに張り付ける」 end

            //add by i.tyou 20130628 start
            //Application.Run(new FrmLogin());
            Msg msg = Msg.GetInstance();

            Application.Run(new FrmBowu());

            //// 同名のプロセスが起動していない時は起動する
            //if (!PrevInstance())
            //{
            //    Application.Run(new FrmBowu());
            //    //Application.Run(new Form1()); 
            //}
            //else
            //{

            //    //このプロジェクトが既に起動されています。
            //    msg.Information(msg.GetMsg("INFO_2301"));
            //}
            //add by i.tyou 20130628 end

            // //delete by zhangwei 201510106 start
            ////資源を釈放する
            //ni.Dispose();
            //ni = null;
            // //delete by zhangwei 201510106 end
        }

        /// <summary>
        ///CS実行Stopポイント
        /// </summary>
        //[STOPThread]
        public static void Exit()
        {
            Application.ExitThread();
        }

        //add by i.tyou 20130628 start
        /// ---------------------------------------------------------------------------
        /// <summary>
        ///    同名のプロセスが起動しているかどうかを示す値を返します。</summary>
        /// <returns>
        ///    同名のプロセスが起動中の場合は true。それ以外は false。</returns>
        /// ---------------------------------------------------------------------------
        private static bool PrevInstance()
        {
            // このアプリケーションのプロセス名を取得
            string stThisProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            // 同名のプロセスが他に存在した場合は、既に起動していると判断する
            if (System.Diagnostics.Process.GetProcessesByName(stThisProcess).Length > 1)
            {
                return true;
            }

            // 存在しない場合は False を返す
            return false;
        }
        //add by i.tyou 20130628 end
    }
}


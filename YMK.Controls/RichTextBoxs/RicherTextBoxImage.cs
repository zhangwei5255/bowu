using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Win.YMK.Controls.RichTextBoxs
{
    public class RicherTextBoxImage : System.Windows.Forms.RichTextBox
    {
        internal const int
    WM_USER = 0x0400,
    EM_FORMATRANGE = WM_USER + 57;

        // RTFを生成するために、RichEd20.dllのFORMATRANGEを使用します。
        internal struct FORMATRANGE
        {
            internal IntPtr hdc, hdcTarget;
            internal Rectangle rc, rcPage;
            internal int cpMin, cpMax;
        }

        // RTFをGraphicsオブジェクトとして生成します。
        public void RenderTo(Graphics g, Rectangle rc)
        {
            // 作業用のビットマップを生成します。
            Bitmap bmp = new Bitmap(rc.Width, rc.Height);

            // RTFをビットマップへ生成します。
            Rectangle rcSrc = new Rectangle(rc.Location.X, rc.Location.Y, rc.Width, rc.Height);
            Graphics gBmp = Graphics.FromImage(bmp);
            RenderToDirect(gBmp, rcSrc);

            // ビットマップをオリジナルのGraphicsオブジェクトに変換します。
            // （この時、ターゲットのGraphicsオブジェクト中で切り取るセットを考慮します。）
            g.DrawImage(bmp, rc, rcSrc, GraphicsUnit.Pixel);

            // クリーンアップ
            gBmp.Dispose();
            bmp.Dispose();
        }

        // コントロールを、与えられたGraphicsオブジェクト中に直接生成します。
        // （ この時、ターゲットのGraphicsオブジェクト中で切り取るセットは考慮されません。)
        public void RenderToDirect(Graphics g, Rectangle rc)
        {
            // 四角形をピクセルからtwipsに変換します。
            rc.X = (int)(rc.X * 1440 / g.DpiX);
            rc.Y = (int)(rc.Y * 1440 / g.DpiY);
            rc.Width = rc.X + (int)((rc.Width) * 1440 / g.DpiX);
            rc.Height = rc.Y + (int)((rc.Height) * 1440 / g.DpiY);

            // dcを取得します。
            IntPtr hdc = g.GetHdc();

            // FORMATRANGE構造体を設定します。
            FORMATRANGE fmt = new FORMATRANGE();
            fmt.hdc = fmt.hdcTarget = hdc;
            fmt.rc = fmt.rcPage = rc;
            fmt.cpMin = 0;
            fmt.cpMax = -1;

            // RTFを生成します（これをコンパイルするため、 
            // プロジェクトのプロパティは安全でないブロックを許可する必要があります）。
            int render = 1;
            unsafe
            {
                SendMessage(EM_FORMATRANGE, (IntPtr)render, (IntPtr)(&fmt));
            }

            // クリーンアップ
            SendMessage(EM_FORMATRANGE, IntPtr.Zero, IntPtr.Zero);

            // dcを用いて実行します。
            g.ReleaseHdc(hdc);
        }

        // FORMATRANGEを呼び出します。
        protected int SendMessage(int msg, IntPtr wParam, IntPtr lParam)
        {
            Message m = Message.Create(Handle, msg, wParam, lParam);
            WndProc(ref m);
            return (int)m.Result;
        }
    }
}

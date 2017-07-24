using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//******************************************************************************
//  クラス名 ：Rooter
//  作成者　 ：張威
//  作成日　 ：2007-05-16
//  処理内容 ：Rooterコントロール
//  更新履歴 ：
//******************************************************************************
namespace JPBook.YMK.UI.Base
{
    public partial class Rooter : UserControl
    {
        public Rooter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ヘッダのResizeイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">対応のイベント</param>
        private void Rooter_Resize(object sender, EventArgs e)
        {
            //ラベルがコントロールのセンターになるために位置をセット
            //this.lblRoot.Location = new Point((this.Width - this.lblRoot.Width) / 2,
            //this.lblRoot.Location = new Point(this.Location.X + (this.Width - this.lblRoot.Width),
           //                                this.lblRoot.Location.Y);
        }
    }
}

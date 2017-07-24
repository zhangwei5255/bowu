using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPBook.YMK.UI.Base
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 標準日本語の冊数名
        /// </summary>
        public String VolumeName
        {
            get
            {
                return LblVolumeName.Text;
            }
            set
            {
                LblVolumeName.Text = value;
            }

        }

        /// <summary>
        /// ヘッダのResizeイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">対応のイベント</param>
        private void Header_Resize(object sender, EventArgs e)
        {
            //標準日本語ラベルがコントロールのセンターになるために位置をセット
            this.LblTitle.Location = new Point((this.Width - this.LblTitle.Width) / 2,
                                           this.LblTitle.Location.Y);
        }
    }
}

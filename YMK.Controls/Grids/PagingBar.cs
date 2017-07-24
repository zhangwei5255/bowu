using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

//******************************************************************************
//  クラス名 ：PagingBar
//  作成者　 ：張威
//  作成日　 ：2009-03-09
//  処理内容 ：Grid分页用的工具栏
//  更新履歴 ：
//******************************************************************************
namespace Win.YMK.Controls.Grids
{
	public partial class PagingBar : UserControl
	{
		public event EventHandler PageChanging;
        private GridViewExt _grid;

		/// <summary>
		/// 构造函数
		/// </summary>
		public PagingBar()
		{
			InitializeComponent();
			initPagingBar();
		}

		/// <summary>
		/// 分页的Grid
		/// </summary>
        public GridViewExt Grid { get { return _grid; } set { _grid = value; } }

		/// <summary>
		/// Grid分页后的处理(设置各子控件的Enable)
		/// </summary>
		/// <param name="sender">触发事件的对象</param>
		/// <param name="e">事件</param>
		public void initPagingBar()
		{
			//初始化
			linkFirst.Enabled = linkPre.Enabled =
				linkNext.Enabled = linkLast.Enabled =
				txtPage.Enabled = btnGo.Enabled = false;
			txtPage.Value = string.Empty;
            //udpate by I.TYOU 20141031 start
			//lblPage.Text = "第0/0頁";
            lblPage.Text = "";
            //udpate by I.TYOU 20141031 end

			if (Grid != null)
			{
				int pageSize = Grid.PageSize;            //每页的记录数
				int pageIndex = Grid.PageIndex;          //当前页的Index
				int pageCount = Grid.PageCount;          //页面数
				int recordCount = Grid.RecordCount;      //总记录数

				if (pageCount > 0)
				{
					//当前页为非首页的场合
					if (pageIndex > 0)
						linkFirst.Enabled = linkPre.Enabled = true;
					//当前页为非末页的场合
					if (pageIndex < pageCount - 1)
						linkNext.Enabled = linkLast.Enabled = true;
					if (pageCount > 1)
						txtPage.Enabled = btnGo.Enabled = true;
					txtPage.Value = (Grid.PageIndex + 1) + "";
                    //udpate by I.TYOU 20141031 start
					//lblPage.Text = "第" + (Grid.PageIndex + 1) + "/" + Grid.PageCount + "页";
                    lblPage.Text = string.Format("第{0:#,##0}/{1:#,##0}頁",Grid.PageIndex + 1, Grid.PageCount);
                    //udpate by I.TYOU 20141031 start
				}
			}
		}
		/// <summary>
		/// 文本框的按键处理(只允许输入数字)
		/// </summary>
		/// <param name="sender">触发事件的对象</param>
		/// <param name="e">事件</param>
		private void txtPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			short c = (short)e.KeyChar;
			//回格键的场合
			if (c == 8) return;
			//数字键的场合
			if (c < 48 || c > 57)
			{
				e.Handled = true;
				return;
			}
		}
		private void linkFirst_Click(object sender, EventArgs e) 
        { 
            ChangePage(0); 
        }
		private void linkPre_Click(object sender, EventArgs e) 
        { 
            ChangePage(Grid.PageIndex - 1);
        }
		private void linkNext_Click(object sender, EventArgs e) 
        { 
            ChangePage(Grid.PageIndex + 1);
        }
		private void linkLast_Click(object sender, EventArgs e) 
        { 
            //update by I.TYOU 20141031 start
            //ChangePage(Grid.PageCount);
            ChangePage(Grid.PageCount - 1);
            //update by I.TYOU 20141031 end
        }
		private void btnGo_Click(object sender, EventArgs e)
		{
			if (txtPage.Value.Trim().Equals(""))
			{
				//CFL.Info("请输入页数。");
				txtPage.Focus();
				txtPage.SelectAll();
				return;
			}
			//int curPage = CFL.Toi(txtPage.Value.Trim());
            int curPage;
            Int32.TryParse(txtPage.Value.Trim(),out curPage);
			if (curPage <= 0)
			{
				//CFL.Info("请输入正整数。");
				txtPage.Focus();
				txtPage.SelectAll();
				return;
			}
			if (curPage > Grid.PageCount)
			{
				//CFL.Info("您输入页数超过了允许的最大页数。");
				txtPage.Focus();
				txtPage.SelectAll();
				return;
			}
			ChangePage(curPage - 1);
		}
		private void ChangePage(int page)
		{
			if (page >= 0 && page < Grid.PageCount)
			{
				Grid.PageIndex = page;
				if (PageChanging != null)
					PageChanging(null, null);
			}
		}
	}
}
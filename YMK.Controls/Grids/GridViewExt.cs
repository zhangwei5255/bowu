using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing;
using System.Collections;
using System.Windows.Forms.Design;

using Win.YMK.Controls.Grids.Behaviors;

//******************************************************************************
//  クラス名 ：DreamGrid
//  作成者　 ：張威
//  作成日　 ：2007-04-12
//  処理内容 ：グリッドコントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.Grids
{
    public partial class GridViewExt : DataGridView
    {
        private Behavior _gridBehavior;                 //グリッドの振舞いクラス

         /// <summary>
        /// コンストラクタ
        /// </summary>
         public GridViewExt()
        {
            InitializeComponent();
             this._gridBehavior = new Behavior(this);
        }

         public GridViewExt(Behavior behavior)
         {
             InitializeComponent();

             this._gridBehavior = new Behavior(behavior);
         }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="behavior">グリッドの振舞いクラス</param>
        public GridViewExt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this._gridBehavior = new Behavior(this);
        }

        /// <summary>
        /// グリッドの振舞いクラス
        /// </summary>
        [Category("Behavior")]
        [Browsable(false)]
        public Behavior GridBehavior
        {
            get
            {
                return _gridBehavior;
            }
        }

        /// <summary>
        /// グリッドの奇数行の色
        /// </summary>
        [Category("Behavior")]
        [Description("グリッドの奇数行の色")]
        public Color ColorOdd
        {
            get
            {
                return _gridBehavior.ColorOdd;
            }
            set
            {
                _gridBehavior.ColorOdd = value;
            }
        }

        /// <summary>
        /// グリッドの偶数行の色
        /// </summary>
        [Category("Behavior")]
        [Description("グリッドの偶数行の色")]
        public Color ColorEven
        {
            get
            {
                return _gridBehavior.ColorEven;
            }
            set
            {
                _gridBehavior.ColorEven = value;
            }
        }

        /// <summary>
        /// 選択のセルのフォント色
        /// </summary>
        [Category("Behavior")]
        [Description("選択のセルのフォント色")]
        public Color SelectionForeColor
        {
            get
            {
                return _gridBehavior.SelectionForeColor;
            }
            set
            {
                _gridBehavior.SelectionForeColor = value;
            }
        }

        /// <summary>
        /// 選択のセルのバックグラウンド色
        /// </summary>
        [Category("Behavior")]
        [Description("選択のセルのバックグラウンド色")]
        public Color SelectionBackColor
        {
            get
            {
                return _gridBehavior.SelectionBackColor;
            }
            set
            {
                _gridBehavior.SelectionBackColor = value;
            }
        }


        /// <summary>
        ///  グリッドでページを分かるかどうか
        /// </summary>
        [Category("Behavior")]
        [Description(" グリッドでページを分かるかどうか")]
        public bool AllowPaging
        {
            get
            {
                return _gridBehavior.AllowPaging;
            }
            set
            {
                _gridBehavior.AllowPaging = value;
            }
        }

        /// <summary>
        ///  ページ数
        /// </summary>
        [Browsable(false)]
        [Category("Behavior")]
        [Description("ページ数")]
        public int PageCount
        {
            get
            {
                return _gridBehavior.PageCount;
            }
        }

        //add by I.TYOU 20141030 start
        /// <summary>
        ///  ページ数
        /// </summary>
        [Browsable(false)]
        [Category("Behavior")]
        [Description("ページ数")]
        public int RecordCount
        {
            get
            {
                return _gridBehavior.RecordCount    ;
            }
        }
        //add by I.TYOU 20141030 end

        /// <summary>
        ///カレントページのインデックス
        /// </summary>
        [Category("Behavior")]
        [Description("カレントページのインデックス")]
        public int PageIndex
        {
            get
            {
                return _gridBehavior.PageIndex;
            }
            set
            {
                _gridBehavior.PageIndex = value;
            }
        }

        /// <summary>
        ///一ページにつきレコード数
        /// </summary>
        [Category("Behavior")]
        [Description("一ページにつきレコード数")]
        public int PageSize
        {
            get
            {
                return _gridBehavior.PageSize;
            }
            set
            {
                _gridBehavior.PageSize = value;
            }
        }


        /// <summary>
        ///全てレコードを格納する用のデータ元
        /// </summary>
        [Category("Behavior")]
        [Description("全てレコードを格納する用のデータ元")]
        public Object DreamDataSoure
        {
            get
            {
                return _gridBehavior.DreamDataSoure;
            }
            set
            {
                _gridBehavior.DreamDataSoure = value;
            }
        }

        /// <summary>
        ///１ページのレコードを格納する用のデータ元
        /// </summary>
        [Category("Behavior")]
        [Description("１ページのレコードを格納する用のデータ元")]
        public Object DataSourceOfPage
        {
            get
            {
                return _gridBehavior.DataSourceOfPage;
            }
            //delete by I.TYOU 2014103 start
            //set
            //{
            //    _gridBehavior.DataSourceOfPage = value;
            //}
            //delete by I.TYOU 2014103 end
        }

        /// <summary>
        /// 検索の文字列
        /// </summary>
        [Category("Behavior")]
        [Description("検索の文字列")]
        public string FindString
        {
            get
            {
                return _gridBehavior.Find;
            }
            set
            {
                _gridBehavior.Find = value;
            }
        }

        /// <summary>
        /// グリッドの検索コラム
        /// </summary>
        [Category("Behavior")]
        [Description("グリッドの検索コラム")]
        public int FindCol
        {
            get
            {
                return _gridBehavior.GridFindCol;
            }
            set
            {
                _gridBehavior.GridFindCol = value;
            }
        }

        /// <summary>
        /// グリッドの検索
        /// </summary>
        [Category("Behavior")]
        [Description("グリッドの検索")]
        public void Search()
        {
            _gridBehavior.Search();           
        }


        /// <summary>
        /// 列ヘッダーセル定義
        /// </summary>
        [Category("Behavior")]
        [Description("列ヘッダーセル定義")]
        public HeaderCell[] HeaderCells
        {
            get
            {
                return _gridBehavior.HeaderCells;
            }
            set
            {
                _gridBehavior.HeaderCells = value;
            }
        }

        /// <summary>
        /// 列ヘッダーの行数
        /// </summary>
        [Category("Behavior")]
        [Description("列ヘッダーの行数")]
        public int ColumnHeaderRowCount
        {
            get
            {
                return _gridBehavior.ColumnHeaderRowCount;
            }
            set
            {
                _gridBehavior.ColumnHeaderRowCount = value;
            }
        }

        //add by I.TYOU 20141030 start
        ///// <summary>
        ///// 分页栏
        ///// </summary>
        //[Category("DataGridViewEx")]
        //[Description("分页栏")]
        //public PagingBar GridPagingBar { get { return _gridBehavior.GridPagingBar; } set { _gridBehavior.GridPagingBar = value; } }

       
        //add by I.TYOU 20141030 end

    }
}


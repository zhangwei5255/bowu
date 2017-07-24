using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using Win.YMK.Controls.Grids;
using System.Linq;

//******************************************************************************
//  クラス名 ：Behavior
//  作成者　 ：張威
//  作成日　 ：2007-04-12
//  処理内容 ：振舞いのための基底クラス
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.Grids.Behaviors
{
    /// &lt;summary>
    /// 列ヘッダーセル定義構造体
    /// &lt;/summary>
    /// &lt;remarks>&lt;/remarks>
    public struct HeaderCell
    {
        public int Row; 
        public int Column; 
        public int RowSpan; 
        public int ColumnSpan; 
        public string Text; 
        /// &lt;summary> 
        /// 列ヘッダーセル定義 /// &lt;/summary> 
        /// &lt;param name="paramRow">行&lt;/param> 
        /// &lt;param name="paramColumn">列&lt;/param> 
        /// &lt;param name="paramRowSpan">結合する行数&lt;/param> 
        /// &lt;param name="paramColumnSpan">結合する列数&lt;/param> 
        /// &lt;param name="paramText">セルに関連付けられたテキスト&lt;/param> 
        /// &lt;remarks>&lt;/remarks> 
        public HeaderCell(int paramRow, int paramColumn, int paramRowSpan, int paramColumnSpan, string paramText) 
        {  // TODO: Complete member initialization   
            Row = paramRow;  
            Column = paramColumn;  
            RowSpan = paramRowSpan;  
            ColumnSpan = paramColumnSpan;  
            Text = paramText; 
        }
    }

    public class Behavior : IDisposable
    {
        private DataGridView _grid;           //グリッド
        private int _preRow;                  //前の行の順番
        private int _preCol;                  //前の列の順番
        private bool _isPerCell;              //前のセルかどうか
        private Color _colorOdd;              //グリッドの奇数行の色
        private Color _colorEven;             //グリッドの偶数行の色
        private Color _selectionBackColor;    //選択のセルのバックグラウンド色
        private Color _selectionForeColor;    //選択のセルのフォント色
        private bool _allowPaging;            //グリッドでページを分かるかどうか
        private int _pageIndex;               //カレントページのインデックス
        private int _pageSize;                //一ページにつきレコード数
        private int _pageCount;               //总页数
        private Object _dreamDataSoure;       //全てレコードを格納する用のデータ元
        private Object _dataSourceOfPage;     //１ページのレコードを格納する用のデータ元
        private string _Find;                 //検索の文字列
        private int _gridFindCol;             //グリッドの検索コラム
        private HeaderCell[] _headerCells;    //列ヘッダーセル定義
        private int _columnHeaderRowCount;    //列ヘッダーの行数

        private int mOffSetPreRow;
        private int mOffSetPreCol;
        private bool mIsTabKey;                //「Tab」キーを押すかどうか

        //private PagingBar _gridPagingBar;

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="grd">グリッド</param>
        public Behavior(DataGridView grd)
        {
            if (grd == null)
                throw new ArgumentNullException("DataGridView");

            this._grid = grd;

            InitVariable();
            InitGrid();
            AddEventHandles();
        }

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="behavior">振舞いクラス</param>
        public Behavior(Behavior behavior)
        {
            if (behavior == null)
                throw new ArgumentNullException("behavior");

            this.Grid = behavior.Grid;

            InitVariable();
            InitGrid();
            behavior.Dispose();
        }

        #region "Property"

        /// <summary>
        /// グリッド
        /// </summary>
        public DataGridView Grid
        {
            get
            {
                return _grid;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                RemoveEventHandlers();
                _grid = value;
                AddEventHandles();
            }
        }

        /// <summary>
        /// 前の行の順番
        /// </summary>
        public int PreRow
        {
            get
            {
                return _preRow;
            }
        }

        /// <summary>
        /// 前の列の順番
        /// </summary>
        public int PreCol
        {
            get
            {
                return _preCol;
            }
        }

        /// <summary>
        /// 前のセルかどうか
        /// </summary>
        public bool IsPerCell
        {
            get
            {
                return _isPerCell;
            }
        }

        /// <summary>
        /// グリッドの奇数行の色
        /// </summary>
        public Color ColorOdd
        {
            get
            {
                return _colorOdd;
            }
            set
            {
                _colorOdd = value;
            }
        }

        /// <summary>
        /// グリッドの偶数行の色
        /// </summary>
        public Color ColorEven
        {
            get
            {
                return _colorEven;
            }
            set
            {
                _colorEven = value;
            }
        }

        /// <summary>
        /// 選択のセルのバックグラウンド色
        /// </summary>
        public Color SelectionBackColor
        {
            get
            {
                return _selectionBackColor;
            }
            set
            {
                _selectionBackColor = value;
            }
        }

        /// <summary>
        /// 選択のセルのフォント色
        /// </summary>
        public Color SelectionForeColor
        {
            get
            {
                return _selectionForeColor;
            }
            set
            {
                _selectionForeColor = value;
            }
        }

        /// <summary>
        /// グリッドでページを分かるかどうか
        /// </summary>
        public bool AllowPaging
        {
            get
            {
                return _allowPaging;
            }
            set
            {
                _allowPaging = value;
            }
        }

        //update by I.TYOU 20141030 start
        /// <summary>
        /// ページ数
        /// </summary>
        //public int PageCount
        //{
        //    get
        //    {
        //        int pageCount;
        //        if (this.DreamDataSoure is DataTable)
        //        {
        //            pageCount = (this.DreamDataSoure as DataTable).Rows.Count;
        //        }
        //        else if (this.DreamDataSoure is List<Object>)
        //        {
        //            pageCount = (this.DreamDataSoure as List<Object>).Count;
        //        }
        //        else
        //        {
        //            throw new Exception("データ元がエラーです！");
        //        }
        //        return pageCount;
        //    }
        //}


        /// <summary>
        /// 总页数
        /// </summary>

        public int PageCount
        {
            get
            {
                //页数设置
                if (RecordCount % _pageSize > 0)
                    _pageCount = RecordCount / _pageSize + 1;
                else
                    _pageCount = RecordCount / _pageSize;

                return _pageCount;
            }
        }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount
        {
            get 
            {
                 int recordCount = 0;             //记录总数
                //update by I.TYOU 20141031 start
                //return _recordCount;
                 if (this.DreamDataSoure != null)
                 {
                     if (this.DreamDataSoure is DataTable)
                     {
                         recordCount = (this.DreamDataSoure as DataTable).Rows.Count;
                     }
                     else
                     {
                         recordCount = (this.DreamDataSoure as List<Object>).Count;
                     }
                 }

                 return recordCount;
                //update by I.TYOU 20141031 end
            }
            //delete by I.TYOU 20141031 start
            //set
            //{
            //    if (value == 0)
            //        _grid.Rows.Clear();
            //    _recordCount = value;
            //}
            //delete by I.TYOU 20141031 end
        }

        /// <summary>
        /// 分页栏
        /// </summary>
        //public PagingBar GridPagingBar { get { return _gridPagingBar; } set { _gridPagingBar = value; } }


        //public void Clear()
        //{
        //    _grid.Rows.Clear();
        //    this.RecordCount = _grid.AllowUserToAddRows ? 1 : 0;
        //    if (GridPagingBar != null)
        //        GridPagingBar.initPagingBar();
        //}
        //update by I.TYOU 20141030 end

       
        /// <summary>
        /// カレントページのインデックス
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        /// <summary>
        /// 一ページにつきレコード数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// 全てレコードを格納する用のデータ元
        /// </summary>
        public Object DreamDataSoure
        {
            get
            {
                return _dreamDataSoure;
            }
            set
            {
                _dreamDataSoure = value;
            }
        }

        /// <summary>
        /// １ページのレコードを格納する用のデータ元
        /// </summary>
        public Object DataSourceOfPage
        {
            get
            {
                
                if (this.DreamDataSoure is DataTable)
                {
                    _dataSourceOfPage = getDataTableOfPage();
                }
                else
                {
                    _dataSourceOfPage = getListOfPage();
                }

                return _dataSourceOfPage;
            }
            //delete by I.TYOU 20141031 start
            //set
            //{
            //    _dataSourceOfPage = value;
            //}
            //delete by I.TYOU 20141031 end
        }

        /// <summary>
        /// 検索の文字列
        /// </summary>
        public string Find
        {
            get
            {
                return _Find;
            }
            set
            {
                _Find = value;
            }
        }

        /// <summary>
        /// グリッドの検索コラム
        /// </summary>
        public int GridFindCol
        {
            get
            {
                return _gridFindCol;
            }
            set
            {
                _gridFindCol = value;
            }
        }

        /// <summary>
        /// 列ヘッダーセル定義
        /// </summary>
        public HeaderCell[] HeaderCells
        {
            get
            {
                return _headerCells;
            }
            set
            {
                _headerCells = value;
            }
        }

        /// <summary>
        /// 列ヘッダーの行数
        /// </summary>
        public int ColumnHeaderRowCount
        {
            get
            {
                return _columnHeaderRowCount;
            }
            set
            {
                _columnHeaderRowCount = value;
            }
        }
        #endregion

        /// <summary>
        /// ページを分かる(データ元がデータテーブルの場合）
        /// </summary>
        /// <returns>1ページのレコードを格納するデータテーブル</returns>
        private DataTable getDataTableOfPage()
        {
            //delete by I.TYOU 20141107 パフォーマンス改善 start
            //DataTable dt = this.DreamDataSoure as DataTable;
            //int rowStart = this.PageIndex * this.PageSize;
            ////update by I.TYOU 20141031 start
            ////int rowEnd = Math.Min((this.PageIndex + 1) * this.PageSize, this.PageCount);
            //int rowEnd = Math.Min((this.PageIndex + 1) * this.PageSize, this.RecordCount);
            ////update by I.TYOU 20141031 end

            //DataTable dtClone = dt.Clone();
            //object[] objItem = new object[dtClone.Columns.Count];
            //for (int i = rowStart; i < rowEnd; i++)
            //{
            //    dt.Rows[i].ItemArray.CopyTo(objItem, 0);
            //    dtClone.Rows.Add(objItem);
            //}

            //return dtClone;
            //delete by I.TYOU 20141107 パフォーマンス改善 end

            //add by I.TYOU 20141107 パフォーマンス改善「LINQで改ページ」 start
            DataTable dt = this.DreamDataSoure as DataTable;
            DataTable dtByPage = dt.Clone();
            var datasByPage = from A in dt.AsEnumerable()
                              select A;
            var rows = datasByPage.Skip(this.PageIndex * this.PageSize).Take(this.PageSize);
            if(rows.Count() > 0)
            {
                dtByPage = rows.CopyToDataTable();
            }

            return dtByPage;
            //add by I.TYOU 20141107 パフォーマンス改善「LINQで改ページ」 start
        }

        /// <summary>
        /// ページを分かる(データ元がリストの場合）
        /// </summary>
        /// <returns>1ページのレコードを格納するデータテーブル</returns>
        private List<Object> getListOfPage()
        {
            //delete by I.TYOU 20141107 パフォーマンス改善 start
            //List<Object> lst = this.DreamDataSoure as List<Object>;
            //Object[] objItem = new Object[this.PageSize];
            //int start = this.PageIndex * this.PageSize;

            //List<Object> lstOfPage = new List<Object>();
            //lst.CopyTo(start, objItem, 0, this.PageSize);

            //for (int i = 0; i < objItem.Length; i++)
            //{
            //    lstOfPage.Add(objItem[i]);
            //}

            //return lstOfPage;
            //delete by I.TYOU 20141107 パフォーマンス改善 end
            //add by I.TYOU 20141107 パフォーマンス改善「LINQで改ページ」 start
            List<Object> lst = this.DreamDataSoure as List<Object>;
            var datas = lst.Skip(this.PageIndex * this.PageSize).Take(this.PageSize);
            List<Object> lstByPage = new List<object>();
            if (datas.Count() > 0)
            {
                lstByPage = datas.ToList();
            }

            return lstByPage;
            //add by I.TYOU 20141107 パフォーマンス改善「LINQで改ページ」 end

        }

        /// <summary>
        /// 変数の初期化
        /// </summary>
        private void InitVariable()
        {
            this._isPerCell = true;
            this._colorOdd = Color.White;
            this._colorEven = Color.FromArgb(192, 192, 255);
            this._selectionBackColor = Color.FromArgb(255, 224, 192);
            this._selectionForeColor = Color.Black;
            this._allowPaging = false;
            this.PageIndex = 0;
            this.PageSize = 10;
            this._dreamDataSoure = new DataTable();
            this._dataSourceOfPage = new DataTable();
        }

        /// <summary>
        /// グリッド初期化
        /// </summary>
        public virtual void InitGrid()
        {
            //グリッドの様式をセット
            this.Grid.GridColor = Color.FromArgb(0, 192, 0);
            this.Grid.BorderStyle = BorderStyle.Fixed3D;
            this.Grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.Grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.Grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //グリッドの選択モードをセット
            this.Grid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            //選択のセルの色をセット
            this.Grid.DefaultCellStyle.SelectionBackColor = this._selectionBackColor;
            this.Grid.DefaultCellStyle.SelectionForeColor = this._selectionForeColor;

            //自動生成列を禁止する
            this.Grid.AutoGenerateColumns = false;

            this.Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //自動改行
            //this.Grid.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True; 
            //add by I.TYOU 20141022 列ヘッダーを合併するため start
            //ちらつき防止
            Type myType = typeof(DataGridView);
            System.Reflection.PropertyInfo myPropInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            myPropInfo.SetValue(this.Grid, true, null); 

            //列ヘッダーの高さの調整モード 
            //this.Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //列ヘッダーの高さを行数に合わせる 
            //this.Grid.ColumnHeadersHeight = this.Grid.ColumnHeadersHeight * ColumnHeaderRowCount;
            //add by I.TYOU 20141022 列ヘッダーを合併するため end
        }

        /// <summary>
        /// グリッドのバックグラウンド色をセット
        /// </summary>
        /// <param name="colorOdd">奇数行の色</param>
        /// <param name="colorEven">偶数行の色</param>
        private void SetRowBackColor(Color colorOdd, Color colorEven)
        {
            for (int i = 0; i < this.Grid.RowCount; i++)
            {
                if ((i + 1) % 2 == 1)
                {
                    this.Grid.Rows[i].DefaultCellStyle.BackColor = colorOdd;
                }
                else
                {
                    this.Grid.Rows[i].DefaultCellStyle.BackColor = colorEven;
                }
            }
        }

        /// <summary>
        /// グリッドにイベントを追加する
        /// </summary>
        private void AddEventHandles()
        {
            this._grid.CellLeave += new DataGridViewCellEventHandler(HandleCellLeave);
            this._grid.CurrentCellChanged += new EventHandler(HandleCurrentCellChanged);
            this._grid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(HandleRowPostPaint);
            this._grid.KeyDown += new KeyEventHandler(HandleKeyDown);
            this._grid.DataSourceChanged += new EventHandler(HandleDataSourceChanged);
            this._grid.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(HandleColumnHeaderClick);
            this._grid.DataError += new DataGridViewDataErrorEventHandler(HandleDataError);
            this._grid.KeyPress += new KeyPressEventHandler(HandleKeyPress);
            //add by I.TYOU 20141022 列ヘッダーを合併するため start
            this._grid.Paint += new PaintEventHandler(HandlePaint);
            this._grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(HandleColumnWidthChanged);
            this._grid.Scroll += new ScrollEventHandler(HandleScroll);
            this._grid.SizeChanged += new EventHandler(HandleSizeChanged);
            //add by I.TYOU 20141022 列ヘッダーを合併するため end
        }

        /// <summary>
        ///  グリッドにイベントを削除する
        /// </summary>
        private void RemoveEventHandlers()
        {
            this._grid.CellLeave -= new DataGridViewCellEventHandler(HandleCellLeave);
            this._grid.CurrentCellChanged -= new EventHandler(HandleCurrentCellChanged);
            this._grid.RowPostPaint -= new DataGridViewRowPostPaintEventHandler(HandleRowPostPaint);
            this._grid.KeyDown -= new KeyEventHandler(HandleKeyDown);
            this._grid.DataSourceChanged -= new EventHandler(HandleDataSourceChanged);
            this._grid.ColumnHeaderMouseClick -= new DataGridViewCellMouseEventHandler(HandleColumnHeaderClick);
            this._grid.KeyPress -= new KeyPressEventHandler(HandleKeyPress);
            //add by I.TYOU 20141022 列ヘッダーを合併するため start
            this._grid.Paint -= new PaintEventHandler(HandlePaint);
            this._grid.ColumnWidthChanged -= new DataGridViewColumnEventHandler(HandleColumnWidthChanged);
            this._grid.Scroll -= new ScrollEventHandler(HandleScroll);
            this._grid.SizeChanged -= new EventHandler(HandleSizeChanged);
            //add by I.TYOU 20141022 列ヘッダーを合併するため end
        }

        /// <summary>
        /// グリッドのCellLeaveイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleCellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.mOffSetPreRow = e.RowIndex;
            this.mOffSetPreCol = e.ColumnIndex;
        }

        /// <summary>
        /// グリッドのCellLeaveイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleCurrentCellChanged(object sender, EventArgs e)
        {
            if (this.Grid.CurrentCell == null)
            {
                return;
            }

            if ((this.Grid.CurrentCell is DataGridViewTextBoxCell) == false)
            {
                return;
            }

            //「Tab」キーを押すので、カレントセルの変換を起こる場合
            if (mIsTabKey == true)
            {
                //DataGridViewTextBoxColumn TxtCurCell = this.Grid.CurrentCell as DataGridViewTextBoxColumn;
                if (this.Grid.CurrentCell.ReadOnly == true)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    mIsTabKey = false;
                }
                return;
            }

            //マウスでセルをクリックするので、カレントセルの変換を起こる場合
            if (this.Grid.CurrentCell.ReadOnly == true &&
                this.Grid[this.PreCol, this.PreRow].ReadOnly == false)
            {
                if (this.IsPerCell)
                {
                    this._preRow = this.mOffSetPreRow;
                    this._preCol = this.mOffSetPreCol;
                    this._isPerCell = false;
                }
            }

            if (this.IsPerCell == false)
            {
                string strSendKeys = "";                              　　　//キーの名称
                int curRow = this.Grid.CurrentCell.RowIndex;                //カレントセルの行インデックス
                int curCol = this.Grid.CurrentCell.ColumnIndex;             //カレントセルの列インデックス

                //カレント行より前の行は大きい場合
                if (this.PreRow > curRow)
                {
                    strSendKeys = "{DOWN}";
                }

                //カレント行より前の行は小さい場合
                if (this.PreRow < curRow)
                {
                    strSendKeys = "{UP}";
                }

                //カレント列より前の列は大きい場合
                if (this.PreCol > curCol)
                {
                    strSendKeys = "{RIGHT}";
                }

                //カレント列より前の列は小さい場合
                if (this.PreCol < curCol)
                {
                    strSendKeys = "{LEFT}";
                }

                if (strSendKeys != "")
                {
                    SendKeys.Send(strSendKeys);
                }

                //前のセルを戻る場合
                if (this.PreRow == curRow && this.PreCol == curCol)
                {
                    this._isPerCell = true;
                }
            }

        }

        /// <summary>
        /// グリッドのRowPostPaintイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (this.Grid.RowHeadersVisible == true)
            {
                PointF drawPoint = new PointF(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4);

                using (SolidBrush brush = new SolidBrush(this.Grid.RowHeadersDefaultCellStyle.ForeColor))
                {
                    string strNo = (e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture);
                    e.Graphics.DrawString(strNo, this.Grid.DefaultCellStyle.Font, brush, drawPoint);
                }
            }


            //グリッドにバックグラウンド色をセット
            SetRowBackColor(this.ColorOdd, this.ColorEven);
        }

        /// <summary>
        /// グリッドのHandleKeyPressイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            //「Enter」キーを押す場合
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
                this.mIsTabKey = true;

                e.Handled = true;
            }

            //「Tab」キーを押す場合
            if (e.KeyCode == Keys.Tab)
            {
                this.mIsTabKey = true;
            }
        }

        /// <summary>
        /// グリッドのDataSourceChangedイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleDataSourceChanged(object sender, EventArgs e)
        {
            //列の内容より列の広さを直す
            this.Grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            //グリッドにバックグラウンド色をセット
            SetRowBackColor(this.ColorOdd, this.ColorEven);
        }

        // <summary>
        /// グリッドのColumnHeaderClickイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //グリッドにバックグラウンド色をセット
            SetRowBackColor(this.ColorOdd, this.ColorEven);
        }

        /// <summary>
        /// グリッドのDataErrorイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">イベント</param>
        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            //キーが「Ctrl + F」の場合
            if (e.KeyChar == 6)
            {
                this.Search();
            }
        }

        //add by I.TYOU 20141022 列ヘッダーを合併するため start
        private void HandlePaint(object sender, PaintEventArgs e)
        {
            //列が無い場合 
            if (this._grid.ColumnCount == 0)
            {
                return;
            }
            //行が無い場合 
            if (this._grid.RowCount == 0)
            {
                return;
            }

            //add by I.TYOU 20141023 start
            if (HeaderCells == null || HeaderCells.Length == 0)
            {
                return;
            }
            //add by I.TYOU 20141023 end

            //列ヘッダーの行の高さの取得 
            int rowHeight = this._grid.ColumnHeadersHeight / ColumnHeaderRowCount;
            int lineWidth = 1;
            //列ヘッダーを指定された行数にセル表示する 
            for (int columuns = 0; columuns <= this._grid.ColumnCount - 1; columuns++)
            {
                for (int rows = 0; rows <= ColumnHeaderRowCount - 1; rows++)
                {
                    //列ヘッダーの表示領域の取得   
                    Rectangle rect = this._grid.GetCellDisplayRectangle(columuns, -1, true);
                    //セルの枠線の描画   
                    rect.Height = rowHeight;
                    rect.X -= lineWidth;
                    rect.Y = rowHeight * rows + lineWidth;
                    //最下行の場合は描画領域の高さを調整する   
                    if (rows == this.ColumnHeaderRowCount - 1 && rect.Y + rect.Height != this._grid.ColumnHeadersHeight)
                    { rect.Height = this._grid.ColumnHeadersHeight - rect.Y; }
                    Pen gridPen = new Pen(this._grid.GridColor);
                    e.Graphics.DrawRectangle(gridPen, rect);
                    //セルの背景色の領域   
                    rect.Y += lineWidth;
                    rect.X += lineWidth;
                    rect.Height -= lineWidth;
                    rect.Width -= lineWidth;
                    //背景色   
                    SolidBrush backBrash = new SolidBrush(this._grid.BackColor);
                    e.Graphics.FillRectangle(backBrash, rect);
                    //見出しを最下列に表示   
                    if (rows == this.ColumnHeaderRowCount - 1)
                    {
                        string text = this._grid.Columns[columuns].HeaderText;
                        TextFormatFlags formatFlg = GetTextFormatFlags(this._grid.ColumnHeadersDefaultCellStyle.Alignment);
                        TextRenderer.DrawText(e.Graphics, text, this._grid.ColumnHeadersDefaultCellStyle.Font, rect, this._grid.ColumnHeadersDefaultCellStyle.ForeColor, formatFlg);
                    }
                    //リソースの解放   
                    gridPen.Dispose();
                    backBrash.Dispose();
                }
            }
            //列ヘッダーセル定義の処理 
            for (int i = 0; i <= this.HeaderCells.Length - 1; i++)
            {
                //セルの結合の開始行がヘッダーの行数より大きい場合は除外  
                if (HeaderCells[i].Row > this.ColumnHeaderRowCount - 1)
                {
                    continue;
                }
                //セルの結合の開始列の列インデックスが列数より大きい場合は除外  
                if (HeaderCells[i].Column > this._grid.ColumnCount - 1)
                {
                    continue;
                }
                //描画領域の設定  
                //Rectangle rect = null;
                Rectangle rect = new Rectangle();
                //結合する列中のソート状態  
                string sortText = string.Empty;
                //結合するセルの幅の取得  
                for (int j = this.HeaderCells[i].Column; j <= this.HeaderCells[i].Column + this.HeaderCells[i].ColumnSpan - 1; j++)
                {
                    if (this._grid.Columns[j].Displayed == false)
                    {
                        continue;
                    }
                    //if (rect == null)
                    if (rect.Width == 0)
                    {
                        rect = this._grid.GetCellDisplayRectangle(j, -1, true);
                    }
                    else
                    {
                        rect.Width += this._grid.GetCellDisplayRectangle(j, -1, true).Width;
                    }
                }
                //結合するセルが画面中に無い場合  
                //if (rect == null)
                if (rect.Width == 0)
                {
                    continue;
                }
                //結合する行がヘッダー行数より大きい場合  
                int rowSapn = this.HeaderCells[i].RowSpan;
                if (rowSapn > ColumnHeaderRowCount)
                {
                    rowSapn = ColumnHeaderRowCount;
                }
                //描画する行の設定  
                rect.Y = rowHeight * (this.HeaderCells[i].Row) + lineWidth;
                rect.X -= lineWidth;
                rect.Height = rowHeight * rowSapn;
                //最下行の場合は描画領域の高さを調整する  
                if (this.HeaderCells[i].Row + rowSapn == this.ColumnHeaderRowCount && rect.Y + rect.Height != this._grid.ColumnHeadersHeight)
                {
                    rect.Height = this._grid.ColumnHeadersHeight - rect.Y;
                }
                //グッリドの線  
                Pen gridPen = new Pen(this._grid.GridColor);
                //背景色の取得  
                System.Drawing.Color backgroundColor = this._grid.ColumnHeadersDefaultCellStyle.BackColor;
                //背景色  
                SolidBrush backBrash = new SolidBrush(backgroundColor);
                //くぼみ線 
                SolidBrush whiteBrash = new SolidBrush(Color.White);
                //枠線の描画  
                e.Graphics.DrawRectangle(gridPen, rect);
                //結合セルの背景色の描画領域の設定  
                rect.Y += lineWidth;
                rect.X += lineWidth;
                rect.Height -= lineWidth;
                rect.Width -= lineWidth;
                //背景色の描画  
                e.Graphics.FillRectangle(backBrash, rect);
                //テキストの描画  
                System.Drawing.Color foreColor = this._grid.ColumnHeadersDefaultCellStyle.ForeColor;
                TextFormatFlags formatFlg = GetTextFormatFlags(this._grid.ColumnHeadersDefaultCellStyle.Alignment);
                TextRenderer.DrawText(e.Graphics, this.HeaderCells[i].Text + sortText, this._grid.ColumnHeadersDefaultCellStyle.Font, rect, foreColor, formatFlg);
                //リソースの解放  
                gridPen.Dispose();
                backBrash.Dispose();
                whiteBrash.Dispose();
            }
        }

        private void HandleColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            InvalidateUnitColumns();
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            InvalidateUnitColumns();
        }

        private void HandleSizeChanged(object sender, EventArgs e)
        {
            InvalidateUnitColumns();
        }

        /// &lt;summary>
        /// 結合元のセルの文字位置から結合後の文字位置を取得する
        /// &lt;/summary>
        /// &lt;param name="alignment">テキストの配置&lt;/param>
        /// &lt;remarks>&lt;/remarks>
        private TextFormatFlags GetTextFormatFlags(DataGridViewContentAlignment alignment)
        { 
            try 
            {  
                //'文字の描画  
                TextFormatFlags formatFlg = TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;  
                //表示位置  
                switch (alignment) 
                {   
                    case DataGridViewContentAlignment.BottomCenter:    
                        formatFlg = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;    
                        break;   
                    case DataGridViewContentAlignment.BottomLeft:    
                        formatFlg = TextFormatFlags.Bottom | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;    
                        break;   
                    case DataGridViewContentAlignment.BottomRight:    
                        formatFlg = TextFormatFlags.Bottom | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;    
                        break;   
                    case DataGridViewContentAlignment.MiddleCenter:    
                        formatFlg = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;    
                        break;   
                    case DataGridViewContentAlignment.MiddleLeft:   
                        formatFlg = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;   
                        break;  
                    case DataGridViewContentAlignment.MiddleRight:    
                        formatFlg = TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;   
                        break;  
                    case DataGridViewContentAlignment.TopCenter:  
                        formatFlg = TextFormatFlags.Top | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;   
                        break;   
                    case DataGridViewContentAlignment.TopLeft:    
                        formatFlg = TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;    break;   
                    case DataGridViewContentAlignment.TopRight:    
                        formatFlg = TextFormatFlags.Top | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;    break;  
                }  return formatFlg; 
            } catch (Exception ex) 
            {  
                throw; 
            }
        }

        /// &lt;summary>
        /// 列ヘッダーの描画領域の無効化
        /// &lt;/summary>
        /// &lt;remarks>&lt;/remarks>
        private void InvalidateUnitColumns()
        { 
            try 
            {  
                if (this._grid.RowCount > 0) 
                {
                    Rectangle hRect = this._grid.DisplayRectangle;
                    hRect.Height = this._grid.ColumnHeadersHeight;
                    this._grid.Invalidate(hRect);  
                } 
            } 
            catch (Exception ex) 
            {  
                throw; 
            }
        }
        //add by I.TYOU 20141022 列ヘッダーを合併するため end

        // <summary>
        /// ごみ処理
        /// </summary>
        public virtual void Dispose()
        {
            RemoveEventHandlers();
        }

        public void Search()
        {

            FrmSearch frmSearch = new FrmSearch();
            DataTable dt = new DataTable();

            //add by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 start
            int cmbidx;
            int selColIdx = -1;
            if (_grid.SelectedCells.Count > 0)
            {
                selColIdx = _grid.SelectedCells[0].ColumnIndex;
            }

            cmbidx = selColIdx;
            //add by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 end

            dt.Columns.Add("name", typeof(System.String));
            dt.Columns.Add("value", typeof(System.Int32));

            //コンボボックスのデータ元を取得する
            foreach (DataGridViewColumn dc in _grid.Columns)
            {
                //コラムの種類はボタンの場合
                if (dc.CellType.Name.ToUpper().Equals("DATAGRIDVIEWBUTTONCELL") == true)
                {
                    continue;
                }

                //if (dc.ReadOnly == false && dc.Visible == true)
                if (dc.Visible == true)
                {
                    DataRow dr = dt.NewRow();

                    dr["name"] = dc.HeaderText;
                    dr["value"] = dc.Index;

                    dt.Rows.Add(dr);
                }
                //add by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 start
                else
                {
                    if (dc.Index <= selColIdx)
                    {
                        cmbidx--;
                    }
                }
                //add by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 end
            }

            //コンボボックスのデータ元をセットする
            frmSearch.CmbCol.DataSource = dt;
            frmSearch.CmbCol.DisplayMember = "name";
            frmSearch.CmbCol.ValueMember = "value";

            //update by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 start
            //frmSearch.CmbCol.SelectedIndex = 0;
            if (cmbidx < 0)
            {
                cmbidx = 0;
            }
            frmSearch.CmbCol.SelectedIndex = cmbidx;
            //update by I.TYOU 20140710 機能強化「グリッドの選択される列名称をコンボボックスデフォルト値にセットする」 end

            frmSearch.ShowDialog();

            //検索フォームのキャンセルがクリックされる場合
            if (frmSearch.IsClickCancel)
            {
                this._Find = "CANCEL";
                return;
            }
            else
            {
                this._Find = frmSearch.Find;
            }

            //グリッドの検索コラム
            this._gridFindCol = (int)frmSearch.CmbCol.SelectedValue;
        }
    }
}

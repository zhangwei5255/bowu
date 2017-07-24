using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Win.YMK.Controls.TreeViews.TreeEdits;
using Win.YMK.XmlSerialization.DAL;

//******************************************************************************
//  クラス名 ：DreamTreeView
//  作成者　 ：張威
//  作成日　 ：2007-04-21
//  処理内容 ：TreeViewコントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.TreeViews
{
    public partial class DreamTreeView : Control
    {
        //変数宣言
        //private TreeView tree;
        private TreeLabelEdit tree;

        //delete by I.TYOU 20131125 start
        //画面にクリックすると、親コントロールから最終子コントロールまで自動的にクリックイベントが起こる
        ////TreeViewのクリックイベント
        //public event EventHandler TreeClick;

        ////TreeViewのモウスアップイベント
        //public event MouseEventHandler TreeMouseUp;
        //delete by I.TYOU 20131125 end

        //TreeViewのAfterSelectのイベント
        public event TreeViewEventHandler TreeAfterSelect;

        public event NodeLabelEditEventHandler NodeAfterLabelEdit;

        public event EventHandler MenuAddClick;
        public event EventHandler MenuRenameClick;
        public event EventHandler MenuSaveClick;

        /// <summary>
        /// 構造関数
        /// </summary>
        public DreamTreeView()
        {
            InitializeComponent();

            this.AutoScrollOffset = new Point(this.Height * 100, this.Width * 10);
            //変数初期化
            InitTree();

            //コントロールを追加する
            this.Controls.Add(tree);

            //TreeViewのイベント処理を追加する
            addEventHandle();
        }

        /// <summary>
        /// DreamTreeプロパティ
        /// </summary>
        public TreeLabelEdit DreamTree
        {
            get
            {
                return tree;
            }
        }

        /// <summary>
        /// OnPaintイベント処理
        /// </summary>
        /// <param name="pe">PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        /// <summary>
        /// コントロールのサイズ変換イベント処理
        /// </summary>
        /// <param name="e">対応イベント引数</param>
        protected override void OnSizeChanged(EventArgs e)
        {
           this.tree.Height = this.Height;
           this.tree.Width = this.Width;

           base.OnSizeChanged(e);
        }

        /// <summary>
        /// 変数初期化
        /// </summary>
        private void InitTree()
        {
            ImageList imgLst = new ImageList();
            //TreeViewSerializer serializer = new TreeViewSerializer();
            //string myDir;

            //tree = new TreeView();
            tree = new TreeLabelEdit();

            //myDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //ピクチャーの目録を取得する
            //string strImgDir = myDir + @"\" + TreeKeys.PICTRUE_DIR + @"\";
           // string strImgDir = @".\" + TreeKeys.PICTRUE_DIR + @"\";

            //ピクチャーを追加する
            /*imgLst.Images.Add(global::Dream.Win.Properties.Resources._0);
            imgLst.Images.Add(global::Dream.Win.Properties.Resources._1);
            imgLst.Images.Add(global::Dream.Win.Properties.Resources._2);
            imgLst.Images.Add(global::Dream.Win.Properties.Resources._3);*/
            imgLst.Images.Add(imageList1.Images[0]);
            imgLst.Images.Add(imageList1.Images[1]);
            imgLst.Images.Add(imageList1.Images[2]);
            imgLst.Images.Add(imageList1.Images[3]);
            

            for (int i = 0; i < TreeKeys.PICTRUE_COUNT; i++)
            {
                //ピクチャーのキーをセット
                switch (i)
                {
                    case 0:
                        imgLst.Images.SetKeyName(i, TreeKeys.PICTRUE_BOOK_CLOSE);
                        break;
                    case 1:
                        imgLst.Images.SetKeyName(i, TreeKeys.PICTRUE_BOOK_OPEN);
                        break;
                    case 2:
                        imgLst.Images.SetKeyName(i, TreeKeys.FILE_NOT_SELECTED);
                        break;
                    case 3:
                        imgLst.Images.SetKeyName(i, TreeKeys.FILE_SELECTED);
                        break;
                }
            }

            //TreeViewを設定する
            //tree.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)
            //              | AnchorStyles.Right)));       //コントロールのサイズ変わるとTreeViewも変わる
            tree.ImageList = imgLst;
            tree.ImageKey = TreeKeys.PICTRUE_BOOK_CLOSE;
            tree.SelectedImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
            tree.ShowPlusMinus = false;
            tree.ShowRootLines = false;
            tree.HotTracking = true;


          /*  //現在実行しているAssemblyを取得する
            System.Reflection.Assembly asm;
            asm = System.Reflection.Assembly.GetExecutingAssembly();
            //または次のようにもできる
            //asm = this.GetType().Assembly;

            //リソースが埋め込まれたアセンブリが別のアセンブリで、
            //"ResourceAssembly"という名前の時は次のようにする
            //asm = System.Reflection.Assembly.Load("ResourceAssembly");

            //ResourceManagerオブジェクトの作成
            //リソースファイル名が"Resource1.resources"だとする
            System.Resources.ResourceManager rm =
                new System.Resources.ResourceManager(
                    asm.GetName().Name + ".Resource1", asm);

            asm.Location.Replace(asm.GetName().Name + ".dll", "DreamTreeView.xml")*/

            //update by I.TYOU 20131119 start
            //serializer.DeserializeTreeView(tree, myDir + @"\DreamTreeView.xml");
            //serializer.DeserializeTreeView(tree, @".\DreamTreeView.xml");
            TreeViewDataAccess.LoadTreeViewData(tree, @".\DreamTreeView.xml");

            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                AddContextMenuToTreeNode(tree.Nodes[i]);
            }
            //update by I.TYOU 20131119 end

        }

        private void AddContextMenuToTreeNode(TreeNode treeNode)
        { 
            ContextMenuStrip menuNode;
            ToolStripMenuItem menuItemAdd;
            ToolStripMenuItem menuItemRename;
            ToolStripMenuItem menuItemSave;
            menuNode = new ContextMenuStrip();
           
            switch (treeNode.Level)
            {
                case 0: //ルート
                    menuItemAdd = new ToolStripMenuItem("Add");
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemAdd.Click += new EventHandler(HandleMenuAddClick);
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuItemSave = new ToolStripMenuItem("Save");
                    menuItemSave.Click += new EventHandler(HandleMenuSaveClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemAdd, menuItemRename, menuItemSave });

                    break;
                case 1: //課ノード
                    menuItemAdd = new ToolStripMenuItem("Add");
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemAdd.Click += new EventHandler(HandleMenuAddClick);
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemAdd, menuItemRename });

                    break;
                default://最終ノード
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] {menuItemRename });
                    break;
            }
            
            treeNode.ContextMenuStrip = menuNode;

            foreach (TreeNode node in treeNode.Nodes)
            {
                AddContextMenuToTreeNode(node);
            }

        }

        public TreeNode CreateChildNode(TreeNode curNode)
        {
            TreeNode addNode = new TreeNode();
            TreeNode leafNode;

            ContextMenuStrip menuNode;
            ToolStripMenuItem menuItemAdd;
            ToolStripMenuItem menuItemRename;

            switch (curNode.Level)
            {
                case 0: //ルート
                    if (curNode.Nodes.Count == 0)
                    {
                        addNode.Text = "第N課";
                        addNode.ImageIndex = 0;
                        addNode.SelectedImageIndex = 0;
                        addNode.Checked = false;
                        addNode.Tag = curNode.Tag + "-01";
                    }
                    else
                    {
                        addNode.Text = "第N課";
                        addNode.ImageIndex = 0;
                        addNode.SelectedImageIndex = 0;
                        addNode.Checked = false;
                        string[] arrLession = (curNode.LastNode.Tag + "").Split('-');
                        int maxLession;
                        int.TryParse(arrLession[1], out maxLession);

                        addNode.Tag = arrLession[0] + "-" + (maxLession + 1).ToString().PadLeft(2, '0');
                    }

                    menuNode = new ContextMenuStrip();
                    menuItemAdd = new ToolStripMenuItem("Add");
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemAdd.Click += new EventHandler(HandleMenuAddClick);
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemAdd, menuItemRename });
                    addNode.ContextMenuStrip = menuNode; 

                    leafNode = new TreeNode();
                    leafNode.Text = "新規";
                    leafNode.ImageIndex = 2;
                    leafNode.SelectedImageIndex = 0;
                    leafNode.Checked = false;
                    leafNode.Tag = addNode.Tag;

                    menuNode = new ContextMenuStrip();
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemRename });
                    leafNode.ContextMenuStrip = menuNode;

                    addNode.Nodes.Add(leafNode);
                    addNode.Expand();

                    //curNode.Nodes.Add(addNode);
                    //curNode.Expand();

                    break;
                case 1: //課ノード
                    addNode.Text = "新規";
                    addNode.ImageIndex = 2;
                    addNode.SelectedImageIndex = 0;
                    addNode.Checked = false;
                    addNode.Tag = curNode.Tag;
                    //curNode.Nodes.Add(addNode);

                    menuNode = new ContextMenuStrip();
                    menuItemRename = new ToolStripMenuItem("Rename");
                    menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
                    menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemRename });
                    addNode.ContextMenuStrip = menuNode;

                    break;
                default:
                    break;
            }


            return addNode;
        }

        //add by I.TYOU 20170714 機能強化「本ルートを追加する」 start
        /// <summary>
        /// 本ルートを追加する
        /// </summary>
        /// <returns>追加したルート</returns>
        public TreeNode CreateBookRoot()
        {
            ContextMenuStrip menuNode;
            ToolStripMenuItem menuItemAdd;
            ToolStripMenuItem menuItemRename;
            ToolStripMenuItem menuItemSave;

            TreeNode bookNode = new TreeNode();
            bookNode.Text = "本の名称";
            bookNode.ImageIndex = 0;
            bookNode.SelectedImageIndex = 0;
            bookNode.Checked = false;
            bookNode.Tag = tree.Nodes.Count + 1;
            bookNode.Expand();

            menuNode = new ContextMenuStrip();
            menuItemAdd = new ToolStripMenuItem("Add");
            menuItemRename = new ToolStripMenuItem("Rename");
            menuItemSave = new ToolStripMenuItem("Save");
            menuItemAdd.Click += new EventHandler(HandleMenuAddClick);
            menuItemRename.Click += new EventHandler(HandleMenuRenameClick);
            menuItemSave.Click += new EventHandler(HandleMenuSaveClick);
            menuNode.Items.AddRange(new ToolStripMenuItem[] { menuItemAdd, menuItemRename, menuItemSave });
            bookNode.ContextMenuStrip = menuNode; 

            return bookNode;
        }
        //add by I.TYOU 20170714 機能強化「本ルートを追加する」 end
        private void HandleMenuSaveClick(object sender, EventArgs e)
        {
            if (this.MenuSaveClick == null)
            {
                return;
            }

            this.MenuSaveClick(sender, e);
        }

        /// <summary>
        /// ショートカットメニューのクリックイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">応じるイベント引数</param>
        private void HandleMenuAddClick(object sender, EventArgs e)
        {

            if (this.MenuAddClick == null)
            {
                return;
            }

            this.MenuAddClick(sender, e);
        }

        /// <summary>
        /// ショートカットメニューのクリックイベント処理
        /// </summary>
        /// <param name="sender">イベントを起こるオブジェクト</param>
        /// <param name="e">応じるイベント引数</param>
        private void HandleMenuRenameClick(object sender, EventArgs e)
        {
            if (this.MenuRenameClick == null)
            {
                return;
            }

            this.MenuRenameClick(sender, e);
        }

        /// <summary>
        /// TreeViewのイベント処理を追加する
        /// </summary>
        private void addEventHandle()
        {
            //tree.MouseUp += new MouseEventHandler(HandleTreeMouseUp);
            //tree.Click += new EventHandler(HandleClick);
            tree.AfterSelect += new TreeViewEventHandler(HandleAfterSelect);
            tree.AfterLabelEdit += new NodeLabelEditEventHandler(HandleNodeAfterLabelEdit);
            tree.AfterCollapse += new TreeViewEventHandler(tree_AfterCollapse);
            tree.AfterExpand += new TreeViewEventHandler(tree_AfterExpand);
        }

        public void HandleNodeAfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (this.NodeAfterLabelEdit == null)
            {
                return;
            }

            this.NodeAfterLabelEdit(sender, e);
        }

       // /// <summary>
       // /// TreeViewのモウスアップイベント処理
       // /// </summary>
       // /// <param name="sender">イベントを起こるオブジェクト</param>
       // /// <param name="e">応じるイベント引数</param>
       // private void HandleTreeMouseUp(object sender, MouseEventArgs e)
       // {
       //     //if (e.Button == MouseButtons.Right)
       //     //{
       //     //    ((TreeView)sender).Tag = "MouseButtons.Right";
       //     //}
       //     //else
       //     //{
       //     //    ((TreeView)sender).Tag = "";
       //     //}

       //     if (TreeMouseUp == null)
       //     {
       //         return;
       //     }

       //     this.TreeMouseUp(sender, e);
       // }

       // /// <summary>
       // /// TreeViewのクリックイベント処理
       // /// </summary>
       // /// <param name="sender">イベントを起こるオブジェクト</param>
       // /// <param name="e">応じるイベント引数</param>
       // private void HandleClick(object sender, EventArgs e)
       // {

       //     //Treeをクリックする時、いつもTreeViewのAfterSelectのイベントを行うために、選択したNodeをクリアーする
       //     tree.SelectedNode = null;

       //     if (this.TreeClick == null)
       //     {
       //         return;
       //     }

       //     this.TreeClick(sender, e);
       //}


        void tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //選択したNodeを取得する
            TreeNode mySelectedNode = e.Node;

            mySelectedNode.SelectedImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
            mySelectedNode.ImageKey = TreeKeys.PICTRUE_BOOK_OPEN;

            //親Nodeのピクチャーをセット
            while (mySelectedNode.Parent != null)
            {
                mySelectedNode = mySelectedNode.Parent;
                mySelectedNode.ImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
            }
        }

        void tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            //選択したNodeを取得する
            TreeNode mySelectedNode = e.Node;

            //選択したNodeのピクチャーをセット
            mySelectedNode.SelectedImageKey = TreeKeys.PICTRUE_BOOK_CLOSE;
            mySelectedNode.ImageKey = TreeKeys.PICTRUE_BOOK_CLOSE;
        }

       /// <summary>
       /// TreeViewのAfterSelectのイベント
       /// </summary>
       /// <param name="sender">イベントを起こるオブジェクト</param>
       /// <param name="e">応じるイベント引数</param>
       private void HandleAfterSelect(object sender, TreeViewEventArgs e)
       {
           //if (((TreeView)sender).Tag == "MouseButtons.Right")
           //{
           //    return;
           //}

           //選択したNodeを取得する
    /*       TreeNode mySelectedNode = e.Node;

           //選択したNodeが空の場合
           if (mySelectedNode == null)
           {
               return;
           }

           //tree.SelectedNodeがもうmySelectedNodeになった
           //tree.SelectedNode = mySelectedNode; 

           if (mySelectedNode.IsExpanded)　　　　　　　　　　　　　//選択したNodeが展開の場合
           {
               //選択したNodeのピクチャーをセット
               mySelectedNode.SelectedImageKey = TreeKeys.PICTRUE_BOOK_CLOSE;
               mySelectedNode.ImageKey = TreeKeys.PICTRUE_BOOK_CLOSE;

               //選択したNodeを折る
               mySelectedNode.Collapse();
           }
           else                                    　　　　　　　　 //選択したNodeが折の場合
           {
               if (mySelectedNode.Nodes.Count == 0)　　　　　　　　 //選択したNodeは子Nodeがない場合
               {
                   mySelectedNode.SelectedImageKey = TreeKeys.FILE_SELECTED;
               }
               else
               {
                   mySelectedNode.SelectedImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
               }

               //選択したNodeを展開する
               mySelectedNode.Expand();

               //TreeNode node = this.tree.GetNodeAt(e.X, e.Y);

               ////親Nodeのピクチャーをセット
               //while (node.Parent != null)
               //{
               //    node = node.Parent;
               //    node.ImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
               //}

               //親Nodeのピクチャーをセット
               while (mySelectedNode.Parent != null)
               {
                   mySelectedNode = mySelectedNode.Parent;
                   mySelectedNode.ImageKey = TreeKeys.PICTRUE_BOOK_OPEN;
               }
           } */

           
           //選択したNodeを取得する
          TreeNode mySelectedNode = e.Node;

           //選択したNodeが空の場合
           if (mySelectedNode == null)
           {
               return;
           }

           //最終ノードの場合
           if (mySelectedNode.Level == 2)
           {
               mySelectedNode.SelectedImageKey = TreeKeys.FILE_SELECTED;
           }

           if (TreeAfterSelect == null)
           {
               return;
           }

           this.TreeAfterSelect(sender, e);
       }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

//******************************************************************************
//  クラス名 ：DreamTree
//  作成者　 ：張威
//  作成日　 ：2007-04-21
//  処理内容 ：TreeViewコントロール用の定数
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.TreeViews
{
    class TreeKeys
    {
        /// <summary>
        /// ピクチャーの件数
        /// </summary>
        public const int PICTRUE_COUNT = 4;

        public const string PICTRUE_DIR = "bmp";

        /// <summary>
        /// ピクチャーの拡張子
        /// </summary>
        public const string PICTRUE_EXTENSION = "bmp";
        
        /// <summary>
        ///  ピクチャーの値
        /// </summary>
        public const string PICTRUE_BOOK_CLOSE = "BookClose";

        /// <summary>
        /// ピクチャーの値
        /// </summary>
        public const string PICTRUE_BOOK_OPEN = "BookOpen";

        /// <summary>
        /// ピクチャーの値
        /// </summary>
        public const string FILE_NOT_SELECTED = "FileNotSelected";

        /// <summary>
        /// ピクチャーの値
        /// </summary>
        public const string FILE_SELECTED = "FileSelected";

        /// <summary>
        /// XMLの主タイプ
        /// </summary>
        public const string XML_MAIN_TAG_TREEVIEW = "TreeView";

        /// <summary>
        ///node用の XML タイプ　例：<node></node>
        /// </summary>
        public const string XML_NODE_TAG = "node";

        /// <summary>
        /// node用のXML　Textフィールド 例：<node text="***"> </node>
        /// </summary>
        public const string XML_NODE_TEXT_ATT = "text";

        /// <summary>
        /// node用のXML　Tagフィールド 例：<node tag="***"> </node>
        /// </summary>
        public const string XML_NODE_TAG_ATT = "tag";

        /// <summary>
        /// node用のXML　imageindexフィールド 例：<node imageindex="***"> </node>
        /// </summary>
        public const string XML_NODE_IMAGEINDEX_ATT = "imageindex";
    }
}

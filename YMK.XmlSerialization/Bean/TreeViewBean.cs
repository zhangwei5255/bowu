using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Win.YMK.XmlSerialization.Bean
{
    [Serializable]
    [XmlRoot("TreeView")]
    public class TreeViewBean
    {
        [XmlArrayItem("node", typeof(TreeNodeInfo))]
        [XmlArray("items")]
        public TreeNodeInfo[] nodeInfos;

        //[XmlElement("node")]
        //public NodeInfo nodeInfo;

        public TreeViewBean()
        {
        }

        //TreeViewのデータをTreeViewBeanにコンバートする
        public TreeViewBean(TreeView treeview)
        {
            if (treeview.Nodes.Count == 0)
            {
                return;
            }

            nodeInfos = new TreeNodeInfo[treeview.Nodes.Count];
            for (int i = 0; i < treeview.Nodes.Count; i++)
            {
                nodeInfos[i] = new TreeNodeInfo(treeview.Nodes[i]);
            }
        }

        //TreeViewBeanのデータをTreeViewにコンバートする
        public void PopulateTree(TreeView treeview)
        {
             //Check to see if there are any root nodes in the TreeViewData
            if (this.nodeInfos == null || this.nodeInfos.Length == 0)
            {
                return;
            }

            //Populate the TreeView with child nodes
            treeview.BeginUpdate();
            for (int i = 0; i < this.nodeInfos.Length; i++)
            {
                treeview.Nodes.Add(this.nodeInfos[i].ToTreeNode());
            }
            treeview.EndUpdate();
        }
    }
}

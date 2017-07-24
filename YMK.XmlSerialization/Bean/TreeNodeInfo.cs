using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Win.YMK.XmlSerialization.Bean
{
    [Serializable]
    [XmlRoot("TreeNodeInfo")]
    public class TreeNodeInfo
    {
        //XML属性の名称(id)を指定しなければ、デフォルトはプロパティの名称をXML属性とする
        [XmlAttribute("text")]
		public string Text { get; set; }

        [XmlAttribute("imageindex")]
        public int ImageIndex { get; set; }

        [XmlAttribute("selectedimageindex")]
        public int SelectedImageIndex { get; set; }

        [XmlAttribute("checked")]
        public bool Checked { get; set; }

        [XmlAttribute("expanded")]
        public bool Expanded { get; set; }

        [XmlAttribute("tag")]
        public string Tag { get; set; }
        //public object Tag { get; set; }

        [XmlArrayItem("node", typeof(TreeNodeInfo))]
        [XmlArray("items")]
        public TreeNodeInfo[] Items;

        public TreeNodeInfo()
		{
		}

        public TreeNodeInfo(TreeNode node)
        {
            //Set the basic TreeNode properties
            this.Text = node.Text;
            this.ImageIndex = node.ImageIndex;
            this.SelectedImageIndex = node.SelectedImageIndex;
            this.Checked = node.Checked;
            this.Expanded = node.IsExpanded;

            //See if there is an object in the tag property and if it is serializable
            if (node.Tag != null && node.Tag.GetType().IsSerializable == true)
            {
                this.Tag = node.Tag + "";
            }

            //Check to see if there are any child nodes
            if (node.Nodes.Count == 0)
            {
                return;
            }

            //Recurse through child nodes and add to Nodes array
            Items = new TreeNodeInfo[node.Nodes.Count];
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                Items[i] = new TreeNodeInfo(node.Nodes[i]);
            }
        }


        public TreeNode ToTreeNode()
        {
            //Create TreeNode based on instance of TreeNodeData and set basic properties
            TreeNode treeNode = new TreeNode(this.Text, this.ImageIndex, this.SelectedImageIndex);
            treeNode.Checked = this.Checked;
            treeNode.Tag = this.Tag;
            if (this.Expanded)
            {
                treeNode.Expand();
            }

            //Recurse through child nodes adding to Nodes collection
            if (Items == null || Items.Length == 0)
            {
                return treeNode;
            }

            for (int i = 0; i < Items.Length; i++)
            {
                //再帰
                treeNode.Nodes.Add(this.Items[i].ToTreeNode());
            }

            return treeNode;
        }
    }
}

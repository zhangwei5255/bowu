using System;
using System.Xml;
using System.Windows.Forms;
using System.Text;

//******************************************************************************
//  クラス名 ：TreeViewSerializer
//  作成者　 ：張威
//  作成日　 ：2007-04-21
//  処理内容 ：「XML」ファイルからデータを読む/書く
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.TreeViews
{
    class TreeViewSerializer
    {
        /// <summary>
        /// TreeViewのNode情報を指定ファイル(.xml)に書く
        /// </summary>
        /// <param name="treeView">TreeView</param>
        /// <param name="fileName">ファイル名</param>
        public void SerializeTreeView(TreeView treeView, string fileName)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.ASCII);

            try
            {
                textWriter.WriteStartDocument();

                // 主タイプを書く
                textWriter.WriteStartElement(TreeKeys.XML_MAIN_TAG_TREEVIEW);

                // Nodeの情報を保存する
                SaveNodes(treeView.Nodes, textWriter);

                textWriter.WriteEndElement();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                textWriter.Close();
            }
 
        }

        /// <summary>
        ///  指定ファイル(.xml)の情報をTreeViewのNodeに読み込む
        /// </summary>
        /// <param name="treeView">TreeView</param>
        /// <param name="fileName">ファイル名</param>
        public void DeserializeTreeView(TreeView treeView, string fileName)
        {
            XmlTextReader reader = null;
            try
            {
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);

                TreeNode parentNode = null;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == TreeKeys.XML_NODE_TAG)
                            {
                                TreeNode newNode = new TreeNode();
                                bool isEmptyElement = reader.IsEmptyElement;

                                int attributeCount = reader.AttributeCount;

                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);

                                    SetAttributeValue(newNode, reader.Name, reader.Value);
                                }
                              

                                //Nodeを追加する
                                if (parentNode != null)
                                    parentNode.Nodes.Add(newNode);
                                else
                                    treeView.Nodes.Add(newNode);

                                // making current node 'ParentNode' if its not empty
                                if (!isEmptyElement)
                                {
                                    parentNode = newNode;
                                }

                            }

                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == TreeKeys.XML_NODE_TAG)
                            {
                                parentNode = parentNode.Parent;
                            }
                            break;

                        case XmlNodeType.XmlDeclaration:
                            break;

                        case XmlNodeType.None:
                            return;

                        case XmlNodeType.Text:
                            parentNode.Nodes.Add(reader.Value);

                            break;

                    }
                    
                }
            }
            finally
            {
                treeView.EndUpdate();
                reader.Close();
            }
        }

        /// <summary>
        /// node情報を保存する
        /// </summary>
        /// <param name="nodesCollection">TreeNodeCollection</param>
        /// <param name="textWriter">XmlTextWriter</param>
        private void SaveNodes(TreeNodeCollection nodesCollection,XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                textWriter.WriteStartElement(TreeKeys.XML_NODE_TAG);
                textWriter.WriteAttributeString(TreeKeys.XML_NODE_TEXT_ATT, node.Text);
                textWriter.WriteAttributeString(TreeKeys.XML_NODE_IMAGEINDEX_ATT, node.ImageIndex.ToString());
                if (node.Tag != null)
                    textWriter.WriteAttributeString(TreeKeys.XML_NODE_TAG_ATT, node.Tag.ToString());

                //他のNode情報を保存する
                if (node.Nodes.Count > 0)
                {

                    SaveNodes(node.Nodes, textWriter);

                }
                textWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Used by Deserialize method for setting properties of TreeNode from xml node attributes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        private void SetAttributeValue(TreeNode node, string propertyName, string value)
        {
            if (propertyName ==TreeKeys.XML_NODE_TEXT_ATT)
            {
                node.Text = value;
            }
            else if (propertyName == TreeKeys.XML_NODE_IMAGEINDEX_ATT)
            {
                node.ImageIndex = int.Parse(value);
            }
            else if (propertyName == TreeKeys.XML_NODE_TAG_ATT)
            {
                node.Tag = value;
            }
        }

    }
}

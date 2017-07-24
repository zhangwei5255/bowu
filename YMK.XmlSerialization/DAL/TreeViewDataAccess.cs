using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Win.YMK.XmlSerialization.Bean;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;

namespace Win.YMK.XmlSerialization.DAL
{
    public class TreeViewDataAccess
    {
        public static void LoadTreeViewData(TreeView treeview, string path)
        {
            TreeViewBean nodeBean = XmlSerializer<TreeViewBean>.DeserializeFromFile(path);
            //TreeViewBeanのデータをTreeViewにコンバートする
            nodeBean.PopulateTree(treeview);
        }

        public static void SaveTreeViewData(TreeView treeview, string path)
        {
            //TreeViewのデータをTreeViewBeanにコンバートする
            TreeViewBean treeviewBean = new TreeViewBean(treeview);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";

            XmlSerializer<TreeViewBean>.SerializeToFile(treeviewBean, path, namespaces, settings); 
        }
    }
}

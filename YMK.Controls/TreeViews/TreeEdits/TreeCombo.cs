using System;
using System.Windows.Forms;

namespace Win.YMK.Controls.TreeViews.TreeEdits
{
	/// <summary>
	/// This Class is made by Ahmed Mahmoud Mohammed in 21 - 2-2005
	/// Systems' Engineer, graduated from
	/// Ain Shams University, Fac. of Engineering
	/// Cairo - Egypt 
	/// </summary>
	public class TreeCombo: TreeView
	{
		public TreeCombo()
		{
			//
			// TODO: Add constructor logic here
			//
			this.Controls.Add(tcombo);
			tcombo.Hide();
			tcombo.SelectedIndexChanged+=new EventHandler(tcombo_SelectedIndexChanged);
		}

		
		private ComboBox tcombo = new ComboBox();

		private TreeNode current_tree_node;

		public ComboBox TreeComboBox
		{
			get
			{
				return tcombo;
			}
			set
			{
				tcombo = value;
			}
		}

		 
		protected override void OnBeforeLabelEdit
			(NodeLabelEditEventArgs e)
		{
			current_tree_node = e.Node;
			tcombo.Bounds =  e.Node.Bounds;
			tcombo.Show();
			
		}

		private void tcombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			current_tree_node.Text = tcombo.Text;
			tcombo.Hide();
		}
	}
}

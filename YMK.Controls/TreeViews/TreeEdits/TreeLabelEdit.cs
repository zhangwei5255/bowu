using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win.YMK.Controls.TreeViews.TreeEdits
{
    public partial class TreeLabelEdit : TreeView
    {
        private const int WM_TIMER = 0x0113;
        private bool _triggerLabelEdit = false;
        private string _viewedLabel;
        private string _editedLabel;
        private bool _wasDoubleClick = false;

        public TreeLabelEdit()
        {
            InitializeComponent();
            //初期化
            Init();
        }

        public TreeLabelEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //初期化
            Init();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = this.GetNodeAt(e.X, e.Y);
                if (tn != null)
                    this.SelectedNode = tn;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            TreeNode tn;
            if (e.Button == MouseButtons.Left)
            {
                tn = this.SelectedNode;
                if (tn == this.GetNodeAt(e.X, e.Y))
                {
                    if (_wasDoubleClick)
                        _wasDoubleClick = false;
                    else
                    {
                        _triggerLabelEdit = true;
                    }
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            // put node label to initial state
            // to ensure that in case of label editing cancelled
            // the initial state of label is preserved
            this.SelectedNode.Text = _viewedLabel;
            // base.OnBeforeLabelEdit is not called here
            // it is called only from StartLabelEdit
        }

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            this.LabelEdit = false;
            e.CancelEdit = true;
            if (e.Label == null)
            {
                return;
            }
            ValidateLabelEditEventArgs ea = new ValidateLabelEditEventArgs(e.Label);
            OnValidateLabelEdit(ea);
            if (ea.Cancel == true)
            {
                e.Node.Text = _editedLabel;
                this.LabelEdit = true;
                e.Node.BeginEdit();
            }
            else
                base.OnAfterLabelEdit(e);
        }

        public void BeginEdit()
        {
            StartLabelEdit();
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (_triggerLabelEdit)
                if (m.Msg == WM_TIMER)
                {
                    _triggerLabelEdit = false;
                    StartLabelEdit();
                }
            base.OnNotifyMessage(m);
        }

        public void StartLabelEdit()
        {
            TreeNode tn = this.SelectedNode;
            _viewedLabel = tn.Text;

            NodeLabelEditEventArgs e = new NodeLabelEditEventArgs(tn);
            base.OnBeforeLabelEdit(e);

            _editedLabel = tn.Text;

            this.LabelEdit = true;
            tn.BeginEdit();
        }


        protected override void OnClick(EventArgs e)
        {
            _triggerLabelEdit = false;
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            _wasDoubleClick = true;
            base.OnDoubleClick(e);
        }

        public event ValidateLabelEditEventHandler ValidateLabelEdit;

        protected virtual void OnValidateLabelEdit(ValidateLabelEditEventArgs e)
        {
            if (ValidateLabelEdit == null)
            {
                return;
            }
            ValidateLabelEdit(this, e);
        }

        public delegate void ValidateLabelEditEventHandler(object sender, ValidateLabelEditEventArgs e);

        /// <summary>
        /// 初期化
        /// </summary>
        private void Init()
        {
            this.HideSelection = false;
            this.LabelEdit = false;
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
    }

    public class ValidateLabelEditEventArgs : CancelEventArgs
    {

        public ValidateLabelEditEventArgs(string label)
        {
            this.label = label;
            this.Cancel = false;
        }

        private string label;
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

    }
}

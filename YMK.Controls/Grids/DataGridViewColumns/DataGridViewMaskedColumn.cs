using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using Win.YMK.Controls.Grids.DataGridViewCells;

//******************************************************************************
//  クラス脕E：DataGridViewMaskedColumn
//  作成者　 ：張威
//  作成日　 ：2009-03-14
//  処历嘹容 ：用于输葋E付ǜ袷降腉rid列
//  竵E侣臍s ：
//******************************************************************************
namespace Win.YMK.Controls.Grids.DataGridViewColumns
{
    public class DataGridViewMaskedColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewMaskedColumn()
        {
            DataGridViewMaskedCell cell = new DataGridViewMaskedCell();
            base.CellTemplate = cell;

            base.SortMode = DataGridViewColumnSortMode.Automatic;
            //base.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private DataGridViewMaskedCell EditCellTemplate
        {
            get
            {
                DataGridViewMaskedCell cell = this.CellTemplate as DataGridViewMaskedCell;
                if (cell == null)
                {
                    throw new InvalidOperationException("TNumEditDataGridViewColumn does not have a CellTemplate.");
                }
                return cell;
            }
        }

        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                DataGridViewMaskedCell cell = value as DataGridViewMaskedCell;
                if (value != null && cell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type TEditNumDataGridViewCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(100);
            sb.Append("TNumEditDataGridViewColumn { Name=");
            sb.Append(this.Name);
            sb.Append(", Index=");
            sb.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
    }
}

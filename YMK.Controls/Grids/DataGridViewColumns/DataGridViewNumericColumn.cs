using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using Win.YMK.Controls.Grids.DataGridViewCells;

//******************************************************************************
//  ���饹ÁE��DataGridViewNumericColumn
//  �����ߡ� ������
//  �����ա� ��2009-03-14
//  �I������ ��������ȁE�ֵ��Grid��
//  ��E��Ěs ��
//******************************************************************************
namespace Win.YMK.Controls.Grids.DataGridViewColumns
{
    public class DataGridViewNumericColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewNumericColumn()
        {
            DataGridViewNumericCell cell = new DataGridViewNumericCell();
            base.CellTemplate = cell;

            base.SortMode = DataGridViewColumnSortMode.Automatic;
            //base.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private DataGridViewNumericCell EditCellTemplate
        {
            get
            {
                DataGridViewNumericCell cell = this.CellTemplate as DataGridViewNumericCell;
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
                DataGridViewNumericCell cell = value as DataGridViewNumericCell;
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

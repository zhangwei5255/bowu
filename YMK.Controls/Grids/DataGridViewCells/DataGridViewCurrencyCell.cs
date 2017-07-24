using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.ComponentModel;
using System.Globalization;
using Win.YMK.Controls.InputMan.TextBoxs;
using Win.YMK.Controls.Grids.DataGridViewEditingCtrols;

//******************************************************************************
//  クラス脕E：DataGridViewCurrencyCell
//  作成者　 ：張威
//  作成日　 ：2009-03-14
//  処历嘹容 ：用于输葋E醣业腉rid单元竵E
//  竵E侣臍s ：
//******************************************************************************
namespace Win.YMK.Controls.Grids.DataGridViewCells
{
    public class DataGridViewCurrencyCell : DataGridViewTextBoxCellEx
    {
        private static Type defaultEditType = typeof(DataGridViewCurrencyEditingCotrol);
        private static Type defaultValueType = typeof(System.String);

        private DataGridViewCurrencyEditingCotrol EditingTextBox
        {
            get
            {
                return this.DataGridView.EditingControl as DataGridViewCurrencyEditingCotrol;
            }
        }

        public override Type EditType
        {
            get { return defaultEditType; }
        }

        public override Type ValueType
        {
            get
            {
                Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }
                return defaultValueType;
            }
        }

        public override object Clone()
        {
            DataGridViewCurrencyCell dataGridViewCell = base.Clone() as DataGridViewCurrencyCell;
            return dataGridViewCell;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CurrencyTextBox editBox = this.DataGridView.EditingControl as CurrencyTextBox;
            if (editBox != null)
            {
                editBox.BorderStyle = BorderStyle.None;

                string initialFormattedValueStr = initialFormattedValue as string;

                if (string.IsNullOrEmpty(initialFormattedValueStr))
                {
                    editBox.Text = "";
                }
                else
                {
                    editBox.Text = initialFormattedValueStr;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
            System.Windows.Forms.DataGridView dataGridView = this.DataGridView;
            if (dataGridView == null || dataGridView.EditingControl == null)
            {
                throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
            }

            CurrencyTextBox editBox = dataGridView.EditingControl as CurrencyTextBox;
            if (editBox != null)
            {
                editBox.ClearUndo();  // avoid interferences between the editing sessions
            }

            base.DetachEditingControl();
        }

        /// <summary>
        /// Consider the decimal in the formatted representation of the cell value.
        /// </summary>
        protected override object GetFormattedValue(object value,
                                                    int rowIndex,
                                                    ref DataGridViewCellStyle cellStyle,
                                                    TypeConverter valueTypeConverter,
                                                    TypeConverter formattedValueTypeConverter,
                                                    DataGridViewDataErrorContexts context)
        {
            object baseFormattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            string formattedText = baseFormattedValue as string;

            if (value == null || string.IsNullOrEmpty(formattedText))
            {
                return baseFormattedValue;
            }

            return formattedText;
        }

        private void OnCommonChange()
        {
            if (this.DataGridView != null && !this.DataGridView.IsDisposed && !this.DataGridView.Disposing)
            {
                if (this.RowIndex == -1)
                {
                    this.DataGridView.InvalidateColumn(this.ColumnIndex);
                }
                else
                {
                    this.DataGridView.UpdateCellValue(this.ColumnIndex, this.RowIndex);
                }
            }
        }

        private bool OwnsEditingControl(int rowIndex)
        {
            if (rowIndex == -1 || this.DataGridView == null)
            {
                return false;
            }
            DataGridViewCurrencyEditingCotrol editingControl = this.DataGridView.EditingControl as DataGridViewCurrencyEditingCotrol;
            return editingControl != null && rowIndex == ((IDataGridViewEditingControl)editingControl).EditingControlRowIndex;
        }

        public override string ToString()
        {
            return "DataGridViewCell { ColIndex=" + ColumnIndex.ToString(CultureInfo.CurrentCulture) +
                ", RowIndex=" + RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
        }


    }
}

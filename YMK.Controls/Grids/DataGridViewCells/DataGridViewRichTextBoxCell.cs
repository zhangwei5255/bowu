using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Win.YMK.Controls.Grids.DataGridViewEditingCtrols;

namespace Win.YMK.Controls.Grids.DataGridViewCells
{
    public class DataGridViewRichTextBoxCell : DataGridViewImageCell
    {
        //private static readonly RichTextBox _editingControl = new RichTextBox();
        //private readonly RichTextBox _editingControl = new RichTextBox();

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewRichTextBoxEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
            set
            {
                base.ValueType = value;
            }
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(string);
            }
        }

      //  private static void SetRichTextBoxText(RichTextBox ctl, string text)
        private void SetRichTextBoxText(RichTextBox ctl, string text)
        {
            try
            {
                ctl.Rtf = text;
            }
            catch (ArgumentException)
            {
                ctl.Text = text;
            }
        }

        private Image GetRtfImage(int rowIndex, object value, bool selected)
        {
            Size cellSize = GetSize(rowIndex);

            if (cellSize.Width < 1 || cellSize.Height < 1)
                return null;

            RichTextBox ctl = null;

            if (ctl == null)
            {
                //ctl = _editingControl;
                ctl = new RichTextBox();
                ctl.Size = GetSize(rowIndex);
                SetRichTextBoxText(ctl, Convert.ToString(value));
            }

            if (ctl != null)
            {
                // Print the content of RichTextBox to an image.
                Size imgSize = new Size(cellSize.Width - 1, cellSize.Height - 1);
                Image rtfImg = null;

                if (selected)
                {
                    // Selected cell state
                    ctl.BackColor = DataGridView.DefaultCellStyle.SelectionBackColor;
                    ctl.ForeColor = DataGridView.DefaultCellStyle.SelectionForeColor;

                    // Print image
                    rtfImg = RichTextBoxPrinter.Print(ctl, imgSize.Width, imgSize.Height);

                    // Restore RichTextBox
                    ctl.BackColor = DataGridView.DefaultCellStyle.BackColor;
                    ctl.ForeColor = DataGridView.DefaultCellStyle.ForeColor;
                }
                else
                {
                    //add by 20131219 start コントロールの背景色がグリッド行に合せるため
                    ctl.BackColor = DataGridView.Rows[this.RowIndex].DefaultCellStyle.BackColor;
                    ctl.ForeColor = DataGridView.Rows[this.RowIndex].DefaultCellStyle.ForeColor;
                    //add by 20131219 end

                    rtfImg = RichTextBoxPrinter.Print(ctl, imgSize.Width, imgSize.Height);

                    //add by 20131219 start コントロールの背景色がグリッド行に合せるため
                    // Restore RichTextBox
                    ctl.BackColor = DataGridView.Rows[this.RowIndex].DefaultCellStyle.BackColor;
                    ctl.ForeColor = DataGridView.Rows[this.RowIndex].DefaultCellStyle.ForeColor;
                    //add by 20131219 end
                }

                return rtfImg;
            }

            return null;
        }
       

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            RichTextBox ctl = DataGridView.EditingControl as RichTextBox;

            if (ctl != null)
            {
                SetRichTextBoxText(ctl, Convert.ToString(initialFormattedValue));
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return value;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, null, null, errorText, cellStyle, advancedBorderStyle, paintParts);

            //addd by I.TYOU 20131127 start
            //背景の描画
            if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
            {
                //update by I.TYOU 20131219 start セルの背景色を透明にする
                //SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                SolidBrush cellBackground = new SolidBrush(System.Drawing.Color.Transparent);
                //update by I.TYOU 20131219 start
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }

            //境界線の描画
            if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
            {

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }

            //描画エリアを計算
            Rectangle drawArea = cellBounds;
            Rectangle drawAdjustment = this.BorderWidths(advancedBorderStyle);
            drawArea.X += drawAdjustment.X;
            drawArea.Y += drawAdjustment.Y;
            drawArea.Height -= drawAdjustment.Height;
            drawArea.Width -= drawAdjustment.Width;
            //addd by I.TYOU 20131127 end

            Image img = GetRtfImage(rowIndex, value, base.Selected);

            if (img != null)
                graphics.DrawImage(img, cellBounds.Left, cellBounds.Top);
        }

        #region Handlers of edit events, copyied from DataGridViewTextBoxCell

        private byte flagsState;

        protected override void OnEnter(int rowIndex, bool throughMouseClick)
        {
            base.OnEnter(rowIndex, throughMouseClick);

            if ((base.DataGridView != null) && throughMouseClick)
            {
                this.flagsState = (byte)(this.flagsState | 1);
            }
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            base.OnLeave(rowIndex, throughMouseClick);

            if (base.DataGridView != null)
            {
                this.flagsState = (byte)(this.flagsState & -2);
            }
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (base.DataGridView != null)
            {
                Point currentCellAddress = base.DataGridView.CurrentCellAddress;

                if (((currentCellAddress.X == e.ColumnIndex) && (currentCellAddress.Y == e.RowIndex)) && (e.Button == MouseButtons.Left))
                {
                    if ((this.flagsState & 1) != 0)
                    {
                        this.flagsState = (byte)(this.flagsState & -2);
                    }
                    else if (base.DataGridView.EditMode != DataGridViewEditMode.EditProgrammatically)
                    {
                        base.DataGridView.BeginEdit(false);
                    }
                }
            }
        }

        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return (((((char.IsLetterOrDigit((char)((ushort)e.KeyCode)) && ((e.KeyCode < Keys.F1) || (e.KeyCode > Keys.F24))) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.Divide))) || (((e.KeyCode >= Keys.OemSemicolon) && (e.KeyCode <= Keys.OemBackslash)) || ((e.KeyCode == Keys.Space) && !e.Shift))) && (!e.Alt && !e.Control)) || base.KeyEntersEditMode(e));
        }

        #endregion
    }
}

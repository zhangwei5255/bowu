using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Win.YMK.Controls.Grids.DataGridViewCells;

namespace Win.YMK.Controls.Grids.DataGridViewColumns
{
    public class DataGridViewImageColumnEx : DataGridViewColumn
    {
        #region Fields
        static Bitmap errorBmp;
        static Icon errorIco;
        #endregion

        #region Properties
        static Bitmap ErrorBitmap
        {
            get
            {
                if (errorBmp == null)
                {
                    errorBmp = new Bitmap(typeof(DataGridView), "ImageInError.bmp");
                }
                return errorBmp;
            }
        }
        static Icon ErrorIcon
        {
            get
            {
                if (errorIco == null)
                {
                    errorIco = new Icon(typeof(DataGridView), "IconInError.ico");
                }
                return errorIco;
            }
        }

        private DataGridViewImageCellEx ImageCellTemplate
        {
            get
            {
                return (DataGridViewImageCellEx)this.CellTemplate;
            }
        }

        [DefaultValue(1)]
        public DataGridViewImageCellLayout ImageLayout
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException();
                }
                DataGridViewImageCellLayout imageLayout = this.ImageCellTemplate.ImageLayout;
                if (imageLayout == DataGridViewImageCellLayout.NotSet)
                {
                    imageLayout = DataGridViewImageCellLayout.Normal;
                }
                return imageLayout;
            }
            set
            {
                if (this.ImageLayout != value)
                {
                    this.ImageCellTemplate.ImageLayout = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            DataGridViewImageCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridViewImageCell;
                            if (cell != null)
                            {
                                cell.ImageLayout = value;
                            }
                        }
                    }
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ValuesAreIcons
        {
            get
            {
                if (this.ImageCellTemplate == null)
                {
                    throw new InvalidOperationException();
                }
                return this.ImageCellTemplate.ValueIsIcon;
            }
            set
            {
                if (this.ValuesAreIcons != value)
                {
                    this.ImageCellTemplate.ValueIsIcon = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            DataGridViewImageCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridViewImageCell;
                            if (cell != null)
                            {
                                cell.ValueIsIcon = value;
                            }
                        }
                    }
                    if ((value && (this.DefaultCellStyle.NullValue is Bitmap)) && (((Bitmap)this.DefaultCellStyle.NullValue) == ErrorBitmap))
                    {
                        this.DefaultCellStyle.NullValue = ErrorIcon;
                    }
                    else if ((!value && (this.DefaultCellStyle.NullValue is System.Drawing.Icon)) && (((System.Drawing.Icon)this.DefaultCellStyle.NullValue) == ErrorIcon))
                    {
                        this.DefaultCellStyle.NullValue = ErrorBitmap;
                    }
                }
            }
        }
        #endregion

        #region ctor
        public DataGridViewImageColumnEx()
            : this(false)
        {
        }

        public DataGridViewImageColumnEx(bool valuesAreIcons)
            : base(new DataGridViewImageCellEx(valuesAreIcons))
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (valuesAreIcons)
            {
                style.NullValue = ErrorIcon;
            }
            else
            {
                style.NullValue = ErrorBitmap;
            }
            this.DefaultCellStyle = style;
        }
        #endregion
    }
}

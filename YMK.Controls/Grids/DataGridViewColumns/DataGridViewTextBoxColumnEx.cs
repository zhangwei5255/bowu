using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Win.YMK.Controls.Grids.DataGridViewCells;

namespace Win.YMK.Controls.Grids.DataGridViewColumns
{
    public class DataGridViewTextBoxColumnEx : DataGridViewColumn
    {
        #region ctor
        public DataGridViewTextBoxColumnEx()
            : base(new DataGridViewTextBoxCellEx())
        {
        }
        #endregion
    }
}

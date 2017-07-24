using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Win.YMK.Controls.Grids.DataGridViewCells;

namespace Win.YMK.Controls.Grids.DataGridViewColumns
{
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell()) 
        { }
        public override DataGridViewCell CellTemplate
        {
            get 
            {
                return base.CellTemplate; 
            }
            set
            {                  // Ensure that the cell used for the template is a CalendarCell.                
                if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell"); 
                }
                base.CellTemplate = value;
            }
        }
    }
}

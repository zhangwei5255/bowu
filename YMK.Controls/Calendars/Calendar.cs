using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Win.YMK.Controls.Calendars
{
    public partial class Calendar : DateTimePicker
    {
        //add by I.TYOU 20131218 start
        public enum CalendarFormat
        {
            YYYYMMDD = 0,
            YYYYMM
        };

        private CalendarFormat _outPutFormat = CalendarFormat.YYYYMMDD;
        //add by I.TYOU 20131218 end


        public override string Text
        {
            get { return base.Value.ToString("yyyyMMdd"); }
            set
            {
                if (value.Length == 8)
                {
                    int year = 0;
                    int month = 0;
                    int day = 0;
                    int.TryParse(value.Substring(0, 4), out year);
                    int.TryParse(value.Substring(4, 2), out month);
                    int.TryParse(value.Substring(6, 2), out day);
                    base.Value = new DateTime(year, month, day);
                }
            }
        }
        public new string Value
        {
            get 
            {
                return base.Value.ToString("yyyy年MM月dd日");
            }
            set
            {
                if (value.Length == 8)
                {
                    int year = 0;
                    int month = 0;
                    int day = 0;
                    int.TryParse(value.Substring(0, 4), out year);
                    int.TryParse(value.Substring(4, 2), out month);
                    int.TryParse(value.Substring(6, 2), out day);
                    base.Value = new DateTime(year, month, day);
                }
            }
        }

        //add by I.TYOU 20131218 start
        //[Category("Calendar")]
        //[Description("OutPutFormat")]
        //public CalendarFormat OutPutFormat
        //{
        //    get
        //    {
        //        return _outPutFormat;
        //    }
        //    set
        //    {
        //        _outPutFormat = value;
        //    }
        //}
        //add by I.TYOU 20131218 end
    }
}
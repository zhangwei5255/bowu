using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：DateTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：日付（形式：YYYY/MM/DD)コントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    public class DateTextBox : TextBox
    {
        /// <summary>
        ///   Initializes a new instance of the DateTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="DateBehavior" />. </summary>
        public DateTextBox()
        {
            m_behavior = new DateBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the DateTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="DateBehavior" /> object to associate the textbox with. </param>
        public DateTextBox(DateBehavior behavior)
            :
            base(behavior)
        {
        }

        /// <summary>
        ///   Gets the Behavior object associated with this class. </summary>
        [Browsable(false)]
        public DateBehavior Behavior
        {
            get
            {
                return (DateBehavior)m_behavior;
            }
        }

        /// <summary>
        ///   Gets or sets the month on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid month. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.Month">DateBehavior.Month</see>. </remarks>
        /// <seealso cref="Day" />
        /// <seealso cref="Year" />
        [Browsable(false)]
        public int Month
        {
            get
            {
                return Behavior.Month;
            }
            set
            {
                Behavior.Month = value;
            }
        }

        /// <summary>
        ///   Gets or sets the day on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid day. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.Day">DateBehavior.Day</see>. </remarks>
        /// <seealso cref="Month" />
        /// <seealso cref="Year" />
        [Browsable(false)]
        public int Day
        {
            get
            {
                return Behavior.Day;
            }
            set
            {
                Behavior.Day = value;
            }
        }

        /// <summary>
        ///   Gets or sets the year on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid year. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.Year">DateBehavior.Year</see>. </remarks>
        /// <seealso cref="Month" />
        /// <seealso cref="Day" />
        [Browsable(false)]
        public int Year
        {
            get
            {
                return Behavior.Year;
            }
            set
            {
                Behavior.Year = value;
            }
        }

        /// <summary>
        ///   Gets or sets the month, day, and year on the textbox using a <see cref="DateTime" /> object. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.Value">DateBehavior.Value</see>. </remarks>
        /// <seealso cref="Month" />
        /// <seealso cref="Day" />
        /// <seealso cref="Year" />
        [Browsable(false)]
        public object Value
        {
            get
            {
                return Behavior.Value;
            }
            set
            {
                Behavior.Value = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minimum value allowed. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.RangeMin">DateBehavior.RangeMin</see>. </remarks>
        /// <seealso cref="RangeMax" />
        //[Category("Behavior")]
        //[Description("The minimum value allowed.")]
        public DateTime RangeMin
        {
            get
            {
                return Behavior.RangeMin;
            }
            set
            {
                Behavior.RangeMin = value;
            }
        }

        /// <summary>
        ///   Gets or sets the maximum value allowed. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.RangeMax">DateBehavior.RangeMax</see>. </remarks>
        /// <seealso cref="RangeMin" />
        [Category("Behavior")]
        [Description("The maximum value allowed.")]
        public DateTime RangeMax
        {
            get
            {
                return Behavior.RangeMax;
            }
            set
            {
                Behavior.RangeMax = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character used to separate the month, day, and year values of the date. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.Separator">DateBehavior.Separator</see>. </remarks>
        [Browsable(true)]
        public char Separator
        {
            get
            {
                return Behavior.Separator;
            }
            set
            {
                Behavior.Separator = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the day should be shown before the month or after it. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="DateBehavior.ShowDayBeforeMonth">DateBehavior.ShowDayBeforeMonth</see>. </remarks>
        /// <seealso cref="DateBehavior.Flag.DayBeforeMonth" />
        [Browsable(false)]
        public bool ShowDayBeforeMonth
        {
            get
            {
                return Behavior.ShowDayBeforeMonth;
            }
            set
            {
                Behavior.ShowDayBeforeMonth = value;
            }
        }
        [Browsable(true)]
        public bool ShowYearMonthDay
        {
            get
            {
                return Behavior.ShowYearMonthDay;
            }
            set
            {
                Behavior.ShowYearMonthDay = value;
            }
        }

        /// <summary>
        ///   Sets the month, day, and year on the textbox. </summary>
        /// <param name="year">
        ///   The year to set. </param>
        /// <param name="month">
        ///   The month to set. </param>
        /// <param name="day">
        ///   The day to set. </param>
        /// <remarks>
        ///   This method delegates to <see cref="DateBehavior.SetDate">DateBehavior.SetDate</see>. </remarks>
        public void SetDate(int year, int month, int day)
        {
            Behavior.SetDate(year, month, day);
        }

        ///// <summary>
        /////   Designer class used to prevent the Text property from being set to
        /////   some default value (ie. textBox1) and to remove properties the designer 
        /////   should not generate code for. </summary>
        //internal new class Designer : TextBox.Designer
        //{
        //    /// <summary>
        //    ///   Removes properties that the form designer should not generate code for
        //    ///   when the DateTextBox control is added to a form. </summary>
        //    /// <param name="properties">
        //    ///   The dictionary of properties to be manipulated. </param>
        //    protected override void PostFilterProperties(IDictionary properties)
        //    {
        //        properties.Remove("Month");
        //        properties.Remove("Day");
        //        properties.Remove("Year");
        //        properties.Remove("Value");
        //        //properties.Remove("Separator");
        //        properties.Remove("ShowDayBeforeMonth");

        //        base.PostFilterProperties(properties);
        //    }
        //}
    }
}

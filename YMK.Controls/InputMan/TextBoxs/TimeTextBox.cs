using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：TimeTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：時間コントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports the Time behavior.")]
    //[Designer(typeof(TimeTextBox.Designer))]
    public class TimeTextBox : TextBox
    {
        /// <summary>
        ///   Initializes a new instance of the TimeTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="TimeBehavior" />. </summary>
        public TimeTextBox()
        {
            m_behavior = new TimeBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the TimeTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="TimeBehavior" /> object to associate the textbox with. </param>
        public TimeTextBox(TimeBehavior behavior)
            :
            base(behavior)
        {
        }

        /// <summary>
        ///   Gets the Behavior object associated with this class. </summary>
        [Browsable(false)]
        public TimeBehavior Behavior
        {
            get
            {
                return (TimeBehavior)m_behavior;
            }
        }

        /// <summary>
        ///   Gets or sets the hour on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid hour. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Hour">TimeBehavior.Hour</see>. </remarks>
        /// <seealso cref="Minute" />
        /// <seealso cref="Second" />
        [Browsable(false)]
        public int Hour
        {
            get
            {
                return Behavior.Hour;
            }
            set
            {
                Behavior.Hour = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minute on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid minute. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Minute">TimeBehavior.Minute</see>. </remarks>
        /// <seealso cref="Hour" />
        /// <seealso cref="Second" />
        [Browsable(false)]
        public int Minute
        {
            get
            {
                return Behavior.Minute;
            }
            set
            {
                Behavior.Minute = value;
            }
        }

        /// <summary>
        ///   Gets or sets the second on the textbox. </summary>
        /// <exception cref="ArgumentOutOfRangeException">Setting this property with an invalid second. </exception>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Second">TimeBehavior.Second</see>. </remarks>
        /// <seealso cref="Hour" />
        /// <seealso cref="Minute" />
        [Browsable(false)]
        public int Second
        {
            get
            {
                return Behavior.Second;
            }
            set
            {
                Behavior.Second = value;
            }
        }

        /// <summary>
        ///   Gets AM/PM symbol on the textbox. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.AMPM">TimeBehavior.AMPM</see>. </remarks>
        /// <seealso cref="Hour" />
        /// <seealso cref="Minute" />
        /// <seealso cref="Second" />
        [Browsable(false)]
        public string AMPM
        {
            get
            {
                return Behavior.AMPM;
            }
        }

        /// <summary>
        ///   Gets or sets the hour, minute, and second on the textbox using a <see cref="DateTime" /> object. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Value">TimeBehavior.Value</see>. </remarks>
        /// <seealso cref="Hour" />
        /// <seealso cref="Minute" />
        /// <seealso cref="Second" />
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
        ///   This property delegates to <see cref="TimeBehavior.RangeMin">TimeBehavior.RangeMin</see>. </remarks>
        /// <seealso cref="RangeMax" />
        [Category("Behavior")]
        [Description("The minimum value allowed.")]
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
        ///   This property delegates to <see cref="TimeBehavior.RangeMax">TimeBehavior.RangeMax</see>. </remarks>
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
        ///   Gets or sets the character used to separate the hour, minute, and second values of the time. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Separator">TimeBehavior.Separator</see>. </remarks>
        [Browsable(false)]
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
        ///   Gets or sets whether the hour should be shown in 24-hour format. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.Show24HourFormat">TimeBehavior.Show24HourFormat</see>. </remarks>
        /// <seealso cref="TimeBehavior.Flag.TwentyFourHourFormat" />
        [Browsable(false)]
        public bool Show24HourFormat
        {
            get
            {
                return Behavior.Show24HourFormat;
            }
            set
            {
                Behavior.Show24HourFormat = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the seconds should be shown (after the minutes). </summary>
        /// <remarks>
        ///   This property delegates to <see cref="TimeBehavior.ShowSeconds">TimeBehavior.ShowSeconds</see>. </remarks>
        /// <seealso cref="TimeBehavior.Flag.WithSeconds" />
        [Category("Behavior")]
        [Description("Determines whether the seconds should be shown (after the minutes).")]
        public bool ShowSeconds
        {
            get
            {
                return Behavior.ShowSeconds;
            }
            set
            {
                Behavior.ShowSeconds = value;
            }
        }

        /// <summary>
        ///   Sets the hour, minute, and second on the textbox. </summary>
        /// <param name="hour">
        ///   The hour to set, between 0 and 23. </param>
        /// <param name="minute">
        ///   The minute to set, between 0 and 59. </param>
        /// <param name="second">
        ///   The second to set, between 0 and 59. </param>
        /// <remarks>
        ///   This method delegates to <see cref="TimeBehavior.SetTime">TimeBehavior.SetTime</see>. </remarks>
        public void SetTime(int hour, int minute, int second)
        {
            Behavior.SetTime(hour, minute, second);
        }

        /// <summary>
        ///   Sets the hour and minute on the textbox. </summary>
        /// <param name="hour">
        ///   The hour to set, between 0 and 23. </param>
        /// <param name="minute">
        ///   The minute to set, between 0 and 59. </param>
        /// <remarks>
        ///   This method delegates to <see cref="TimeBehavior.SetTime">TimeBehavior.SetTime</see>. </remarks>
        public void SetTime(int hour, int minute)
        {
            Behavior.SetTime(hour, minute);
        }

        ///// <summary>
        /////   Designer class used to prevent the Text property from being set to
        /////   some default value (ie. textBox1) and to remove properties the designer 
        /////   should not generate code for. </summary>
        //internal new class Designer : TextBox.Designer
        //{
        //    /// <summary>
        //    ///   Removes properties that the form designer should not generate code for
        //    ///   when the TimeTextBox control is added to a form. </summary>
        //    /// <param name="properties">
        //    ///   The dictionary of properties to be manipulated. </param>
        //    protected override void PostFilterProperties(IDictionary properties)
        //    {
        //        properties.Remove("Hour");
        //        properties.Remove("Minute");
        //        properties.Remove("Second");
        //        properties.Remove("Value");
        //        properties.Remove("Separator");
        //        properties.Remove("Show24HourFormat");

        //        base.PostFilterProperties(properties);
        //    }
        //}
    }
}

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：NumericTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：数字コントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports the Numeric behavior.")]
    //[Designer(typeof(NumericTextBox.Designer))]
    public class NumericTextBox : TextBox
    {
        /// <summary>
        ///   Initializes a new instance of the NumericTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="NumericBehavior" />. </summary>
        public NumericTextBox()
        {
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;    //add by I.TYOU 20141020
            m_behavior = new NumericBehavior(this);
            //add by I.TYOU 20140114 フォーカスが出るとTextをフォーマットする
            this.Validating += new CancelEventHandler(NumericTextBox_Validating);
        }

        /// <summary>
        ///   Initializes a new instance of the NumericTextBox class by assigning its Behavior field 
        ///   to an instance of <see cref="NumericBehavior" /> and setting the maximum number of digits 
        ///   allowed left and right of the decimal point. </summary>
        /// <param name="maxWholeDigits">
        ///   The maximum number of digits allowed left of the decimal point.
        ///   If it is less than 1, it is set to 1. </param>
        /// <param name="maxDecimalPlaces">
        ///   The maximum number of digits allowed right of the decimal point.
        ///   If it is less than 0, it is set to 0. </param>
        public NumericTextBox(int maxWholeDigits, int maxDecimalPlaces)
        {
            m_behavior = new NumericBehavior(this, maxWholeDigits, maxDecimalPlaces);
            //add by I.TYOU 20140114 フォーカスが出るとTextをフォーマットする
            this.Validating += new CancelEventHandler(NumericTextBox_Validating);
        }

        /// <summary>
        ///   Initializes a new instance of the NumericTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="NumericBehavior" /> object to associate the textbox with. </param>
        public NumericTextBox(NumericBehavior behavior)
            :
            base(behavior)
        {
            //add by I.TYOU 20140114 フォーカスが出るとTextをフォーマットする
            this.Validating += new CancelEventHandler(NumericTextBox_Validating);
        }

        //add by I.TYOU 20140114 start フォーカスが出るとTextをフォーマットする
        void NumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (_outPutFormat != "" && Value != "")
            {
                base.Text = string.Format("{0:" + _outPutFormat + "}", Double.Parse(Value));
            }
        }
        //add by I.TYOU 20140114 end フォーカスが出るとTextをフォーマットする

        /// <summary>
        ///   Gets the Behavior object associated with this class. </summary>
        [Browsable(false)]
        public NumericBehavior Behavior
        {
            get
            {
                return (NumericBehavior)m_behavior;
            }
        }

        /// <summary>
        ///   Gets or sets the textbox's Text as a double. </summary>
        /// <remarks>
        ///   If the text is empty or cannot be converted to a double, a 0 is returned. </remarks>
        /// <seealso cref="Long" />
        /// <seealso cref="Int" />
        [Browsable(false)]
        public double Double
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Behavior.NumericText);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Text = value.ToString();
            }
        }

        /// <summary>
        ///   Gets or sets the textbox's Text as an int. </summary>
        /// <remarks>
        ///   If the text empty or cannot be converted to an int, a 0 is returned. </remarks>
        /// <seealso cref="Long" />
        /// <seealso cref="Double" />
        [Browsable(false)]
        public int Int
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Behavior.NumericText);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Text = value.ToString();
            }
        }

        /// <summary>
        ///   Gets or sets the textbox's Text as a long. </summary>
        /// <remarks>
        ///   If the text empty or cannot be converted to an long, a 0 is returned. </remarks>
        /// <seealso cref="Int" />
        /// <seealso cref="Double" />
        [Browsable(false)]
        public long Long
        {
            get
            {
                try
                {
                    return Convert.ToInt64(Behavior.NumericText);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Text = value.ToString();
            }
        }

        /// <summary>
        ///   Retrieves the textbox's value without any non-numeric characters. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.NumericText">NumericBehavior.NumericText</see>. </remarks>
        [Browsable(false)]
        public string NumericText
        {
            get
            {
                return Behavior.NumericText;
            }
        }

        /// <summary>
        ///   Retrieves the textbox's value without any non-numeric characters,
        ///   and with a period for the decimal point and a minus for the negative sign. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.RealNumericText">NumericBehavior.RealNumericText</see>. </remarks>
        [Browsable(false)]
        public string RealNumericText
        {
            get
            {
                return Behavior.RealNumericText;
            }
        }

        /// <summary>
        ///   Gets or sets the maximum number of digits allowed left of the decimal point. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.MaxWholeDigits">NumericBehavior.MaxWholeDigits</see>. </remarks>
        /// <seealso cref="NumericBehavior.MaxWholeDigits" />
        [Category("Behavior")]
        [Description("The maximum number of digits allowed left of the decimal point.")]
        public int MaxWholeDigits
        {
            get
            {
                return Behavior.MaxWholeDigits;
            }
            set
            {
                Behavior.MaxWholeDigits = value;
            }
        }

        /// <summary>
        ///   Gets or sets the maximum number of digits allowed right of the decimal point. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.MaxDecimalPlaces">NumericBehavior.MaxDecimalPlaces</see>. </remarks>
        /// <seealso cref="NumericBehavior.MaxDecimalPlaces" />
        [Category("Behavior")]
        [Description("The maximum number of digits allowed right of the decimal point.")]
        public int MaxDecimalPlaces
        {
            get
            {
                return Behavior.MaxDecimalPlaces;
            }
            set
            {
                Behavior.MaxDecimalPlaces = value;
            }
        }

        /// <summary>
        ///   Gets or sets whether the value is allowed to be negative or not. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.AllowNegative">NumericBehavior.AllowNegative</see>. </remarks>
        /// <seealso cref="NumericBehavior.AllowNegative" />
        [Category("Behavior")]
        [Description("Determines whether the value is allowed to be negative or not.")]
        public bool AllowNegative
        {
            get
            {
                return Behavior.AllowNegative;
            }
            set
            {
                Behavior.AllowNegative = value;
            }
        }

        /// <summary>
        ///   Gets or sets the number of digits to place in each group to the left of the decimal point. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.DigitsInGroup">NumericBehavior.DigitsInGroup</see>. </remarks>
        /// <seealso cref="NumericBehavior.DigitsInGroup" />
        [Category("Behavior")]
        [Description("The number of digits to place in each group to the left of the decimal point.")]
        public int DigitsInGroup
        {
            get
            {
                return Behavior.DigitsInGroup;
            }
            set
            {
                Behavior.DigitsInGroup = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character to use for the decimal point. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.DecimalPoint">NumericBehavior.DecimalPoint</see>. </remarks>
        /// <seealso cref="NumericBehavior.DecimalPoint" />
        [Browsable(false)]
        public char DecimalPoint
        {
            get
            {
                return Behavior.DecimalPoint;
            }
            set
            {
                Behavior.DecimalPoint = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character to use for the group separator. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.GroupSeparator">NumericBehavior.GroupSeparator</see>. </remarks>
        /// <seealso cref="NumericBehavior.GroupSeparator" />
        [Browsable(false)]
        public char GroupSeparator
        {
            get
            {
                return Behavior.GroupSeparator;
            }
            set
            {
                Behavior.GroupSeparator = value;
            }
        }

        /// <summary>
        ///   Gets or sets the character to use for the negative sign. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.NegativeSign">NumericBehavior.NegativeSign</see>. </remarks>
        /// <seealso cref="NumericBehavior.NegativeSign" />
        [Browsable(false)]
        public char NegativeSign
        {
            get
            {
                return Behavior.NegativeSign;
            }
            set
            {
                Behavior.NegativeSign = value;
            }
        }

        /// <summary>
        ///   Gets or sets the text to automatically insert in front of the number, such as a currency symbol. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.Prefix">NumericBehavior.Prefix</see>. </remarks>
        /// <seealso cref="NumericBehavior.Prefix" />
        [Category("Behavior")]
        [Description("The text to automatically insert in front of the number, such as a currency symbol.")]
        public String Prefix
        {
            get
            {
                return Behavior.Prefix;
            }
            set
            {
                Behavior.Prefix = value;
            }
        }

        /// <summary>
        ///   Gets or sets the minimum value allowed. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="NumericBehavior.RangeMin">NumericBehavior.RangeMin</see>. </remarks>
        /// <seealso cref="NumericBehavior.RangeMin" />
        [Category("Behavior")]
        [Description("The minimum value allowed.")]
        public double RangeMin
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
        ///   This property delegates to <see cref="NumericBehavior.RangeMax">NumericBehavior.RangeMax</see>. </remarks>
        /// <seealso cref="NumericBehavior.RangeMax" />
        [Category("Behavior")]
        [Description("The maximum value allowed.")]
        public double RangeMax
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



        //private string _text = "";
        private string _value = "";
        private string _outPutFormat = "";

        [Category("TextBoxExt")]
        [Description("text")]
        //[Browsable(false)]
        public override string Text
        {
            get
            {
                //return _text;
                return base.Text;

            }
            set
            {
                //if (_outPutFormat == "")
                //{
                //    base.Text = value;
                //}
                //else
                //{
                //    base.Text = string.Format("{0:" + _outPutFormat + "}", int.Parse(value));
                //}

            }
        }

        //add by I.TYOU 20131218 start
        [Category("TextBoxExt")]
        [Description("value")]
        public string Value
        {
            get
            {
                _value = this.Text.Replace(",", "");     //add by I.TYOU 20140114 Textに従ってValueも変わる
                return _value;
            }
            set
            {
                if (_outPutFormat == "")
                {
                    base.Text = value;
                }
                else
                {
                    if (value != "")
                    {
                        base.Text = string.Format("{0:" + _outPutFormat + "}", Double.Parse(value));
                    }
                    else
                    {
                        base.Text = "";
                    }
                    
                }

                _value = value;
            }
        }

        [Category("TextBoxExt")]
        [Description("OutPutFormat")]
        public string OutPutFormat
        {
            get
            {
                return _outPutFormat;
            }
            set
            {
                _outPutFormat = value;
            }
        }
        //add by I.TYOU 20131218 end

        ///// <summary>
        /////   Designer class used to prevent the Text property from being set to
        /////   some default value (ie. textBox1) and to remove properties the designer 
        /////   should not generate code for. </summary>
        //internal new class Designer : TextBox.Designer
        //{
        //    /// <summary>
        //    ///   Removes properties that the form designer should not generate code for
        //    ///   when the NumericTextBox control is added to a form. </summary>
        //    /// <param name="properties">
        //    ///   The dictionary of properties to be manipulated. </param>
        //    protected override void PostFilterProperties(IDictionary properties)
        //    {
        //        properties.Remove("DecimalPoint");
        //        properties.Remove("GroupSeparator");
        //        properties.Remove("NegativeSign");
        //        properties.Remove("Double");
        //        properties.Remove("Int");
        //        properties.Remove("Long");

        //        base.PostFilterProperties(properties);
        //    }
        //}
    }
}

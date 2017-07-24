using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Globalization;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：MultiMaskedTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：MultiMaskedTextBoxコントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports multiple behaviors, based on a mask string.")]
    public class MultiMaskedTextBox : TextBox
    {
        // Fields
        private string m_mask = "";

        /// <summary>
        ///   Initializes a new instance of the MultiMaskedTextBox class by setting its mask to an
        ///   empty string and setting its Behavior field to <see cref="AlphanumericBehavior">Alphanumeric</see>. </summary>
        public MultiMaskedTextBox()
            :
            this("")
        {
        }

        /// <summary>
        ///   Initializes a new instance of the MultiMaskedTextBox class by setting its mask field and 
        ///   corresponding Behavior. </summary>
        /// <param name="mask">
        ///   The mask string to use for determining what behavior to associate with this textbox. </param>
        /// <seealso cref="Mask" />
        public MultiMaskedTextBox(string mask)
        {
            Mask = mask;
        }

        /// <summary>
        ///   Gets the Behavior object currently associated with this class. </summary>
        /// <remarks>
        ///   The actual Behavior class is dependent on the <see cref="Mask" /> assigned to this class. </remarks>
        /// <seealso cref="Mask" />
        [Browsable(false)]
        public Behavior Behavior
        {
            get
            {
                return m_behavior;
            }
        }

        /// <summary>
        ///   Gets or sets the mask string used to determine which Behavior object to associate with this class. </summary>
        /// <remarks>
        ///   The mask string is interpreted as follows:
        ///   <list type="bullet">
        ///   <item><description>
        ///     ##/##/#### ##:##:## = Date and time (with seconds). 
        ///     The location of the month and the hour format are retrieved from the user's system. </description></item>
        ///   <item><description>
        ///     ##/##/#### ##:## = Date and time (without seconds). 
        ///     The location of the month and the hour format are retrieved from the user's system. </description></item>
        ///   <item><description>
        ///     ##/##/#### = Date.  
        ///     The location of the month is retrieved from the user's system. </description></item>
        ///   <item><description>
        ///     ##:##:## = Time (with seconds). 
        ///     The location of hour format is retrieved from the user's system. </description></item>
        ///   <item><description>
        ///     ##:## = Time (without seconds). 
        ///     The location of hour format is retrieved from the user's system. </description></item>
        ///   <item><description>
        ///     If it looks like a numeric value, such as ### or #,###.### (without foreign characters after the first #) 
        ///     then it's treated as a number; otherwise it's treated as a masked value (e.g., ###-####). </description></item>
        ///   </list></remarks>
        [Category("Behavior")]
        [Description("The string used to determine which Behavior object to associate with this textbox.")]
        public string Mask
        {
            get
            {
                return m_mask;
            }
            set
            {
                if (m_mask == value && m_behavior != null)
                    return;

                if (m_behavior != null)
                    m_behavior.Dispose();
                Text = "";

                m_mask = value;
                int length = value.Length;

                // If it doesn't have numeric place holders then it's alphanumeric
                int position = value.IndexOf('#');
                if (position < 0)
                {
                    m_behavior = new AlphanumericBehavior(this, "");
                    return;
                }

                // If it's exactly like the date mask, then it's a date
                if (value == "##/##/#### ##:##:##")
                {
                    m_behavior = new DateTimeBehavior(this);
                    ((DateTimeBehavior)m_behavior).ShowSeconds = true;
                    return;
                }

                // If it's exactly like the date mask, then it's a date
                else if (value == "##/##/#### ##:##")
                {
                    m_behavior = new DateTimeBehavior(this);
                    return;
                }

                // If it's exactly like the date mask, then it's a date
                else if (value == "##/##/####")
                {
                    m_behavior = new DateBehavior(this);
                    return;
                }

                // If it's exactly like the time mask with seconds, then it's a time
                else if (value == "##:##:##")
                {
                    m_behavior = new TimeBehavior(this);
                    ((TimeBehavior)m_behavior).ShowSeconds = true;
                    return;
                }

                // If it's exactly like the time mask, then it's a time
                else if (value == "##:##")
                {
                    m_behavior = new TimeBehavior(this);
                    return;
                }

                // If after the first numeric placeholder, we don't find any foreign characters,
                // then it's numeric, otherwise it's masked numeric.
                string smallMask = value.Substring(position + 1);
                int smallLength = smallMask.Length;

                char decimalPoint = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0];
                char groupSeparator = NumberFormatInfo.CurrentInfo.NumberGroupSeparator[0];

                for (int iPos = 0; iPos < smallLength; iPos++)
                {
                    char c = smallMask[iPos];
                    if (c != '#' && c != decimalPoint && c != groupSeparator)
                    {
                        m_behavior = new MaskedBehavior(this, value);
                        return;
                    }
                }

                // Verify that it ends in a number; otherwise it's a masked numeric
                if (smallLength > 0 && smallMask[smallLength - 1] != '#')
                    m_behavior = new MaskedBehavior(this, value);
                else
                    m_behavior = new NumericBehavior(this, value);
            }
        }
    }
}

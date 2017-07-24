using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：DateTimeTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：整数コントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports the Integer behavior.")]
    public class IntegerTextBox : NumericTextBox
    {
        /// <summary>
        ///   Initializes a new instance of the IntegerTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="IntegerBehavior" />. </summary>
        public IntegerTextBox()
            :
            base(null)
        {
            m_behavior = new IntegerBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the IntegerTextBox class by assigning its Behavior field 
        ///   to an instance of <see cref="IntegerBehavior" /> and setting the maximum number of digits 
        ///   allowed left of the decimal point. </summary>
        /// <param name="maxWholeDigits">
        ///   The maximum number of digits allowed left of the decimal point.
        ///   If it is less than 1, it is set to 1. </param>
        public IntegerTextBox(int maxWholeDigits)
            :
            base(null)
        {
            m_behavior = new IntegerBehavior(this, maxWholeDigits);
        }

        /// <summary>
        ///   Initializes a new instance of the IntegerTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="IntegerBehavior" /> object to associate the textbox with. </param>
        public IntegerTextBox(IntegerBehavior behavior)
            :
            base(behavior)
        {
        }
    }
}

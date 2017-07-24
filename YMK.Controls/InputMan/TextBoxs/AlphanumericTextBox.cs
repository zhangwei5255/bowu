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
    public class AlphanumericTextBox : TextBox
    {
        /// <summary>
        ///   Initializes a new instance of the DateTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="DateBehavior" />. </summary>
        public AlphanumericTextBox()
        {
            m_behavior = new AlphanumericBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the DateTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="DateBehavior" /> object to associate the textbox with. </param>
        public AlphanumericTextBox(AlphanumericBehavior behavior)
            :
            base(behavior)
        {
        }

        /// <summary>
        ///   Gets the Behavior object associated with this class. </summary>
        [Browsable(false)]
        public AlphanumericBehavior Behavior
        {
            get
            {
                return (AlphanumericBehavior)m_behavior;
            }
        }
    }
}

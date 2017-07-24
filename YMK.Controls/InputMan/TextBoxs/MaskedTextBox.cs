using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：MaskedTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：マスクコントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports the Masked behavior.")]
    public class MaskedTextBox : TextBox
    {
        /// <summary>
        ///   Initializes a new instance of the MaskedTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="MaskedBehavior" />. </summary>
        public MaskedTextBox()
        {
            m_behavior = new MaskedBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the MaskedTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="MaskedBehavior" /> and setting its mask. </summary>
        /// <param name="mask">
        ///   The mask string to use for validating and/or formatting the characters entered by the user. 
        ///   By default, the <c>#</c> symbol is configured to represent a digit placeholder on the mask. </param>
        public MaskedTextBox(string mask)
        {
            m_behavior = new MaskedBehavior(this, mask);
        }

        /// <summary>
        ///   Initializes a new instance of the MaskedTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="MaskedBehavior" /> object to associate the textbox with. </param>
        public MaskedTextBox(MaskedBehavior behavior)
            :
            base(behavior)
        {
        }

        /// <summary>
        ///   Gets the Behavior object associated with this class. </summary>
        [Browsable(false)]
        public MaskedBehavior Behavior
        {
            get
            {
                return (MaskedBehavior)m_behavior;
            }
        }

        /// <summary>
        ///   Gets or sets the mask -- the string used for validating and/or formatting 
        ///   the characters entered by the user.. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="MaskedBehavior.Mask">MaskedBehavior.Mask</see>. </remarks>
        /// <seealso cref="MaskedBehavior.Mask" />
        [Category("Behavior")]
        [Description("The string used for formatting the characters entered into the textbox. (# = digit)")]
        public string Mask
        {
            get
            {
                return Behavior.Mask;
            }
            set
            {
                Behavior.Mask = value;
            }
        }

        /// <summary>
        ///   Gets the ArrayList of Symbol objects. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="MaskedBehavior.Symbols">MaskedBehavior.Symbols</see>. </remarks>
        /// <seealso cref="Mask" />
        /// <seealso cref="MaskedBehavior.Symbol" />
        [Browsable(false)]
        public ArrayList Symbols
        {
            get
            {
                return Behavior.Symbols;
            }
        }

        /// <summary>
        ///   Retrieves the textbox's value without any non-numeric characters. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="MaskedBehavior.NumericText">MaskedBehavior.NumericText</see>. </remarks>
        [Browsable(false)]
        public string NumericText
        {
            get
            {
                return Behavior.NumericText;
            }
        }
    }
}

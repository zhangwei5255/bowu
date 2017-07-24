using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：CurrencyTextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：貨幣コントロール
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Description("TextBox control which supports the Currency behavior.")]
    //[Designer(typeof(CurrencyTextBox.Designer))]
    public class CurrencyTextBox : NumericTextBox
    {
        /// <summary>
        ///   Initializes a new instance of the CurrencyTextBox class by assigning its Behavior field
        ///   to an instance of <see cref="CurrencyBehavior" />. </summary>
        public CurrencyTextBox()
            :
            base(null)
        {
            m_behavior = new CurrencyBehavior(this);
        }

        /// <summary>
        ///   Initializes a new instance of the CurrencyTextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="CurrencyBehavior" /> object to associate the textbox with. </param>
        public CurrencyTextBox(CurrencyBehavior behavior)
            :
            base(behavior)
        {
        }

        ///// <summary>
        /////   Designer class used to prevent the Text property from being set to
        /////   some default value (ie. textBox1) and to remove properties the designer 
        /////   should not generate code for. </summary>
        //internal new class Designer : NumericTextBox.Designer
        //{
        //    /// <summary>
        //    ///   Removes properties that the form designer should not generate code for
        //    ///   when the CurrencyTextBox control is added to a form. </summary>
        //    /// <param name="properties">
        //    ///   The dictionary of properties to be manipulated. </param>
        //    protected override void PostFilterProperties(IDictionary properties)
        //    {
        //        properties.Remove("DigitsInGroup");
        //        properties.Remove("Prefix");
        //        properties.Remove("MaxDecimalPlaces");

        //        base.PostFilterProperties(properties);
        //    }
        //}
    }
}

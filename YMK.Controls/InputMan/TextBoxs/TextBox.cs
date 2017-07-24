using System;
using System.Globalization;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms.Design;

using Win.YMK.Controls.InputMan.Behaviors;

//******************************************************************************
//  クラス名 ：TextBox
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：InputManコントロールの基底クラス
//  更新履歴 ：
//******************************************************************************

[assembly: CLSCompliant(true)] 
namespace Win.YMK.Controls.InputMan.TextBoxs
{
    [Browsable(false)]
   // [Designer(typeof(TextBox.Designer))]
    public abstract class TextBox : System.Windows.Forms.TextBox
    {


        /// <summary> The Behavior object associated with this TextBox. </summary>
        protected Behavior m_behavior = null; 	// must be initialized by derived classes

        /// <summary>
        ///   Initializes a new instance of the TextBox class. </summary>
        /// <remarks>
        ///   This constructor is just for convenience for derived classes.  It does nothing. </remarks>
        protected TextBox()
        {
           
        }

        /// <summary>
        ///   Initializes a new instance of the TextBox class by explicitly assigning its Behavior field. </summary>
        /// <param name="behavior">
        ///   The <see cref="Behavior" /> object to associate the textbox with. </param>
        /// <remarks>
        ///   This constructor provides a way for derived classes to set the internal Behavior object
        ///   to something other than the default value (such as <c>null</c>). </remarks>
        protected TextBox(Behavior behavior)
        {
            m_behavior = behavior;
        }

        /// <summary>
        ///   Checks if the textbox's text is valid and if not updates it with a valid value. </summary>
        /// <returns>
        ///   If the textbox's text is updated (because it wasn't valid), the return value is true; otherwise it is false. </returns>
        /// <remarks>
        ///   This method delegates to <see cref="Behavior.UpdateText">Behavior.UpdateText</see>. </remarks>
        public bool UpdateText()
        {
            return m_behavior.UpdateText();
        }

        /// <summary>
        ///   Gets or sets the flags associated with self's Behavior. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="Behavior.Flags">Behavior.Flags</see>. </remarks>
        /// <seealso cref="ModifyFlags" />
        [Category("Behavior")]
        [Description("The flags (on/off attributes) associated with the Behavior.")]
        public int Flags
        {
            get
            {
                return m_behavior.Flags;
            }
            set
            {
                m_behavior.Flags = value;
            }
        }

        /// <summary>
        ///   Adds or removes flags from self's Behavior. </summary>
        /// <param name="flags">
        ///   The bits to be turned on (ORed) or turned off in the internal flags member. </param>
        /// <param name="addOrRemove">
        ///   If true the flags are added, otherwise they're removed. </param>
        /// <remarks>
        ///   This method delegates to <see cref="Behavior.ModifyFlags">Behavior.ModifyFlags</see>. </remarks>
        /// <seealso cref="Flags" />
        public void ModifyFlags(int flags, bool addOrRemove)
        {
            m_behavior.ModifyFlags(flags, addOrRemove);
        }

        /// <summary>
        ///   Checks if the textbox's value is valid and if not proceeds according to the behavior's <see cref="Flags" />. </summary>
        /// <returns>
        ///   If the validation succeeds, the return value is true; otherwise it is false. </returns>
        /// <remarks>
        ///   This method delegates to <see cref="Behavior.Validate">Behavior.Validate</see>. </remarks>
        /// <seealso cref="IsValid" />
        public bool Validate()
        {
            return m_behavior.Validate();
        }

        /// <summary>
        ///   Checks if the textbox contains a valid value. </summary>
        /// <returns>
        ///   If the value is valid, the return value is true; otherwise it is false. </returns>
        /// <remarks>
        ///   This method delegates to <see cref="Behavior.IsValid">Behavior.IsValid</see>. </remarks>
        /// <seealso cref="Validate" />
        public bool IsValid()
        {
            return m_behavior.IsValid();
        }

        /// <summary>
        ///   Show an error message box. </summary>
        /// <param name="message">
        ///   The message to show. </param>
        /// <remarks>
        ///   This property delegates to <see cref="Behavior.ShowErrorMessageBox">Behavior.ShowErrorMessageBox</see>. </remarks>
        /// <seealso cref="ShowErrorIcon" />
        /// <seealso cref="ErrorMessage" />
        public void ShowErrorMessageBox(string message)
        {
            m_behavior.ShowErrorMessageBox(message);
        }

        /// <summary>
        ///   Show a blinking icon next to the textbox with an error message. </summary>
        /// <param name="message">
        ///   The message to show when the cursor is placed over the icon. </param>
        /// <remarks>
        ///   This property delegates to <see cref="Behavior.ShowErrorIcon">Behavior.ShowErrorIcon</see>. </remarks>
        /// <seealso cref="ShowErrorMessageBox" />
        /// <seealso cref="ErrorMessage" />
        public void ShowErrorIcon(string message)
        {
            m_behavior.ShowErrorIcon(message);
        }

        /// <summary>
        ///   Gets the error message used to notify the user to enter a valid value. </summary>
        /// <remarks>
        ///   This property delegates to <see cref="Behavior.ErrorMessage">Behavior.ErrorMessage</see>. </remarks>
        /// <seealso cref="Validate" />
        /// <seealso cref="IsValid" />
        [Browsable(false)]
        public string ErrorMessage
        {
            get
            {
                return m_behavior.ErrorMessage;
            }
        }
        ///// <summary>
        /////   Designer class used to prevent the Text property from being set to
        /////   some default value (ie. textBox1) and to remove any properties the designer 
        /////   should not generate code for. </summary>
        //internal class Designer :ControlDesigner
        //{
        //    /// <summary>
        //    ///   This typically sets the control's Text property.  
        //    ///   Here it does nothing so the Text is left blank. </summary>
        //    public override void OnSetComponentDefaults()
        //    {
        //    }
        //}
    }
}

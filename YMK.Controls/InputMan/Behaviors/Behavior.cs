using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

//******************************************************************************
//  クラス名 ：Behavior
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：振舞いのための基底クラス
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.Behaviors
{
    public abstract class Behavior : IDisposable
    {
        protected TextBoxBase m_textBox;
        protected int m_flags;
        protected bool m_noTextChanged;
        protected Selection m_selection;
        protected ErrorProvider m_errorProvider;
        private static string m_errorCaption;

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">TextBoxBase</param>
        /// <param name="addEventHandlers">イベントを追加するかどうか</param>
        protected Behavior(TextBoxBase textBox, bool addEventHandlers)
        {
            if (textBox == null)
                throw new ArgumentNullException("textBox");

            m_textBox = textBox;
            m_selection = new Selection(m_textBox);
            m_selection.TextChanging += new EventHandler(HandleTextChangingBySelection);

            if (addEventHandlers)
                AddEventHandlers();
        }

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="behavior"></param>
        protected Behavior(Behavior behavior)
        {
            if (behavior == null)
                throw new ArgumentNullException("behavior");

            TextBox = behavior.TextBox;
            m_flags = behavior.m_flags;

            behavior.Dispose();
        }

        /// <summary>
        /// HandleTextChangingBySelectionイベント
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void HandleTextChangingBySelection(object sender, EventArgs e)
        {
            m_noTextChanged = true;
        }

        /// <summary>
        /// テキストボックスの内容を取得する
        /// </summary>
        /// <returns></returns>
        protected virtual string GetValidText()
        {
            return m_textBox.Text;
        }

        /// <summary>
        /// テキストボックスの内容を更新する
        /// </summary>
        /// <returns>true:更新される、false:更新しない</returns>
        public virtual bool UpdateText()
        {
            string validText = GetValidText();
            if (validText != m_textBox.Text)
            {
                m_textBox.Text = validText;
                return true;
            }
            return false;
        }

        /// <summary>
        /// TextBoxBase
        /// </summary>
        public TextBoxBase TextBox
        {
            get
            {
                return m_textBox;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                RemoveEventHandlers();

                m_textBox = value;
                m_selection = new Selection(m_textBox);
                m_selection.TextChanging += new EventHandler(HandleTextChangingBySelection);

                AddEventHandlers();
            }
        }

    
        /// <summary>
        /// 指定の文字列に先頭数字部をINT型にする（例：999ZZZ999-->999)
        /// </summary>
        /// <param name="text">文字列</param>
        /// <returns>INT型</returns>
        protected int ToInt(String text)
        {
            try
            {
                for (int i = 0, length = text.Length; i < length; i++)
                {
                    if (!Char.IsDigit(text[i]))
                        return Convert.ToInt32(text.Substring(0, i));
                }

                return Convert.ToInt32(text);
            }
            catch
            {
                return 0;
            }
        }

	    /// <summary>
	    /// 指定の文字列をDOUBLE型にする
	    /// </summary>
	    /// <param name="text">文字列</param>
        /// <returns>DOUBLE型</returns>
        protected double ToDouble(String text)
        {
            try
            {
                return Convert.ToDouble(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// フラグ
        /// </summary>
        public virtual int Flags
        {
            get
            {
                return m_flags;
            }
            set
            {
                if (m_flags == value)
                    return;

                m_flags = value;
                UpdateText();
            }
        }

        /// <summary>
        /// フラグを修正する
        /// </summary>
        /// <param name="flags">flags</param>
        /// <param name="addOrRemove">addOrRemove</param>
        public void ModifyFlags(int flags, bool addOrRemove)
        {
            if (addOrRemove)
                Flags = m_flags | flags;
            else
                Flags = m_flags & ~flags;
        }

    
        /// <summary>
        /// フラグをチェック
        /// </summary>
        /// <param name="flag">テスト用のフラグ</param>
        /// <returns>フラグを設置される成否</returns>
        public bool HasFlag(int flag)
        {
            return (m_flags & flag) != 0;
        }

       /// <summary>
       /// メッセージを出力する
       /// </summary>
        /// <param name="message">メッセージ</param>
        public virtual void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(m_textBox, message, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// エラーアイコンを出力する
        /// </summary>
        /// <param name="message">メッセージ</param>
        public virtual void ShowErrorIcon(string message)
        {
            if (m_errorProvider == null)
            {
                if (message == "")
                    return;
                m_errorProvider = new ErrorProvider();
            }
            m_errorProvider.SetError(m_textBox, message);
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public virtual string ErrorMessage
        {
            get
            {
                return "Please specify a valid value.";
            }
        }

     
        /// <summary>
        /// エラー内容
        /// </summary>
        public static string ErrorCaption
        {
            get
            {
                if (m_errorCaption == null)
                    return Application.ProductName;
                return m_errorCaption;
            }
            set
            {
                m_errorCaption = value;
            }
        }

        /// <summary>
        /// メッセージ情報をTraceに格納する
        /// </summary>
        /// <param name="message">メッセージ</param>
        [Conditional("TRACE_DREAM_FW")]
        public void TraceLine(string message)
        {
            Trace.WriteLine(message);
        }

        /// <summary>
        /// 有効な値をチェック
        /// </summary>
        /// <returns>有効成否</returns>
        public bool Validate()
        {
            return Validate(Flags, false);
        }

        /// <summary>
        /// 有効な値をチェック
        /// </summary>
        /// <param name="flags">flags</param>
        /// <param name="setFocusIfNotValid">setFocusIfNotValid</param>
        /// <returns>有効成否</returns>
        public virtual bool Validate(int flags, bool setFocusIfNotValid)
        {
            ShowErrorIcon("");  // エラーアイコンをクリア

            if ((flags & (int)ValidatingFlag.Max) == 0)
                return true;

            if ((flags & (int)ValidatingFlag.Max_IfEmpty) != 0 && m_textBox.Text == "")
            {
                if ((flags & (int)ValidatingFlag.Beep_IfEmpty) != 0)
                    MessageBeep(MessageBoxIcon.Exclamation);

                if ((flags & (int)ValidatingFlag.SetValid_IfEmpty) != 0)
                {
                    UpdateText();
                    return true;
                }

                if ((flags & (int)ValidatingFlag.ShowIcon_IfEmpty) != 0)
                    ShowErrorIcon(ErrorMessage);

                if ((flags & (int)ValidatingFlag.ShowMessage_IfEmpty) != 0)
                    ShowErrorMessageBox(ErrorMessage);

                if (setFocusIfNotValid)
                    m_textBox.Focus();

                return false;
            }

            if ((flags & (int)ValidatingFlag.Max_IfInvalid) != 0 && m_textBox.Text != "" && !IsValid())
            {
                if ((flags & (int)ValidatingFlag.Beep_IfInvalid) != 0)
                    MessageBeep(MessageBoxIcon.Exclamation);

                if ((flags & (int)ValidatingFlag.SetValid_IfInvalid) != 0)
                {
                    UpdateText();
                    return true;
                }

                if ((flags & (int)ValidatingFlag.ShowIcon_IfInvalid) != 0)
                    ShowErrorIcon(ErrorMessage);

                if ((flags & (int)ValidatingFlag.ShowMessage_IfInvalid) != 0)
                    ShowErrorMessageBox(ErrorMessage);

                if (setFocusIfNotValid)
                    m_textBox.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// テキストボックスの内容をチェック
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid()
        {
            return true;
        }


        /// <summary>
        /// テキストボックスのイベントを追加する
        /// </summary>
        protected virtual void AddEventHandlers()
        {
            m_textBox.KeyDown += new KeyEventHandler(HandleKeyDown);
            m_textBox.KeyPress += new KeyPressEventHandler(HandleKeyPress);
            m_textBox.TextChanged += new EventHandler(HandleTextChanged);
            m_textBox.Validating += new CancelEventHandler(HandleValidating);
            m_textBox.LostFocus += new EventHandler(HandleLostFocus);
            m_textBox.DataBindings.CollectionChanged += new CollectionChangeEventHandler(HandleBindingChanges);
        }

        /// <summary>
        /// テキストボックスのイベントを削除する
        /// </summary>
        protected virtual void RemoveEventHandlers()
        {
            if (m_textBox == null)
                return;

            m_textBox.KeyDown -= new KeyEventHandler(HandleKeyDown);
            m_textBox.KeyPress -= new KeyPressEventHandler(HandleKeyPress);
            m_textBox.TextChanged -= new EventHandler(HandleTextChanged);
            m_textBox.Validating -= new CancelEventHandler(HandleValidating);
            m_textBox.LostFocus -= new EventHandler(HandleLostFocus);
            m_textBox.DataBindings.CollectionChanged -= new CollectionChangeEventHandler(HandleBindingChanges);
        }

        /// <summary>
        /// ごみ処理
        /// </summary>
        public virtual void Dispose()
        {
            RemoveEventHandlers();
            m_textBox = null;
        }

        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        protected virtual void HandleKeyDown(object sender, KeyEventArgs e)
        {
            TraceLine("Behavior.HandleKeyDown " + e.KeyCode);

            e.Handled = false;
        }

        /// <summary>
        /// KeyPressイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        protected virtual void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLine("Behavior.HandleKeyPress " + e.KeyChar);

            e.Handled = false;
        }

    
        /// <summary>
        /// TextChangedイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        protected virtual void HandleTextChanged(object sender, EventArgs e)
        {
            TraceLine("Behavior.HandleTextChanged " + m_noTextChanged);

            if (!m_noTextChanged)
                UpdateText();

            m_noTextChanged = false;
        }

        /// <summary>
        /// Validatingイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">CancelEventArgs</param>
        protected virtual void HandleValidating(object sender, CancelEventArgs e)
        {
            TraceLine("Behavior.HandleValidating");

            e.Cancel = !Validate();
        }

        /// <summary>
        /// LostFocusイベント
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected virtual void HandleLostFocus(object sender, EventArgs e)
        {
            TraceLine("Behavior.HandleLostFocus");
        }

        /// <summary>
        /// BindingChangesイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void HandleBindingChanges(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                Binding binding = (Binding)e.Element;
                binding.Format += new ConvertEventHandler(HandleBindingFormat);
                binding.Parse += new ConvertEventHandler(HandleBindingParse);
            }
        }

        /// <summary>
        /// BindingFormatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void HandleBindingFormat(object sender, ConvertEventArgs e)
        {
        }

        /// <summary>
        /// BindingParseイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void HandleBindingParse(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "")
                e.Value = DBNull.Value;
        }

        [DllImport("user32.dll")]
        protected static extern bool MessageBeep(MessageBoxIcon mbi);
    }

    /// <summary>
    ///   Values that may be added/removed to the <see cref="Behavior.Flags" /> property related 
    ///   to validating the textbox. </summary>
    /// <seealso cref="Behavior.ModifyFlags" />
    /// <seealso cref="Behavior.HasFlag" />
    /// <seealso cref="Behavior.Validate" />
    /// <seealso cref="Behavior.HandleValidating" />
    [Flags]
    public enum ValidatingFlag
    {
        /// <summary> If the value is not valid, make beeping sound. </summary>
        Beep_IfInvalid = 0x00000001,

        /// <summary> If the value is empty, make beeping sound. </summary>
        Beep_IfEmpty = 0x00000002,

        /// <summary> If the value is empty or not valid, make beeping sound. </summary>
        Beep = Beep_IfInvalid | Beep_IfEmpty,

        /// <summary> If the value is not valid, change its value to something valid. </summary>
        SetValid_IfInvalid = 0x00000004,

        /// <summary> If the value is empty, change its value to something valid. </summary>
        SetValid_IfEmpty = 0x00000008,

        /// <summary> If the value is empty or not valid, change its value to something valid. </summary>
        SetValid = SetValid_IfInvalid | SetValid_IfEmpty,

        /// <summary> If the value is not valid, show an error message box. </summary>
        ShowMessage_IfInvalid = 0x00000010,

        /// <summary> If the value is empty, show an error message box. </summary>
        ShowMessage_IfEmpty = 0x00000020,

        /// <summary> If the value is empty or not valid, show an error message box. </summary>
        ShowMessage = ShowMessage_IfInvalid | ShowMessage_IfEmpty,

        /// <summary> If the value is not valid, show a blinking icon next to it. </summary>
        ShowIcon_IfInvalid = 0x00000040,

        /// <summary> If the value is empty, show a blinking icon next to it. </summary>
        ShowIcon_IfEmpty = 0x00000080,

        /// <summary> If the value is empty or not valid, show a blinking icon next to it. </summary>
        ShowIcon = ShowIcon_IfInvalid | ShowIcon_IfEmpty,

        /// <summary> Combination of all IfInvalid flags (above); used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max_IfInvalid = Beep_IfInvalid | SetValid_IfInvalid | ShowMessage_IfInvalid | ShowIcon_IfInvalid,

        /// <summary> Combination of all IfEmpty flags (above); used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max_IfEmpty = Beep_IfEmpty | SetValid_IfEmpty | ShowMessage_IfEmpty | ShowIcon_IfEmpty,

        /// <summary> Combination of all flags; used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max = Max_IfInvalid + Max_IfEmpty
    };
}


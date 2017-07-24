using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//******************************************************************************
//  クラス名 ：AlphanumericBehavior
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：英数字の振舞いのためのクラス
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan.Behaviors
{
    public class AlphanumericBehavior : Behavior
    {
        // フィールド
        private char[] m_invalidChars = { '%', '\'', '*', '"', '+', '?', '>', '<', ':', '\\' };

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">テキストボックス</param>
        public AlphanumericBehavior(TextBoxBase textBox)
            :
            base(textBox, true)
        {
        }

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">テキストボックス</param>
        /// <param name="invalidChars">不法の文字</param>
        public AlphanumericBehavior(TextBoxBase textBox, char[] invalidChars)
            :
            base(textBox, true)
        {
            m_invalidChars = invalidChars;
        }

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">テキストボックス</param>
        /// <param name="invalidChars">不法の文字列</param>
        public AlphanumericBehavior(TextBoxBase textBox, string invalidChars)
            :
            base(textBox, true)
        {
            m_invalidChars = invalidChars.ToCharArray();
        }

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="behavior">英数字の振舞いのためのクラス</param>
        public AlphanumericBehavior(AlphanumericBehavior behavior)
            :
            base(behavior)
        {
            m_invalidChars = behavior.m_invalidChars;
        }

        /// <summary>
        /// 不法の文字
        /// </summary>
        public char[] InvalidChars
        {
            get
            {
                return m_invalidChars;
            }
            set
            {
                if (m_invalidChars == value)
                    return;

                m_invalidChars = value;
                UpdateText();
            }
        }

        /// <summary>
        /// テキストボックスの内容を取得する
        /// </summary>
        /// <returns></returns>
        protected override string GetValidText()
        {
            string text = m_textBox.Text;

            // Check if there are any invalid characters and if so, remove them
            if (m_invalidChars != null && text.IndexOfAny(m_invalidChars) >= 0)
            {
                // There are invalid characters -- remove them
                foreach (char c in m_invalidChars)
                {
                    if (text.IndexOf(c) >= 0)
                        text = text.Replace(c.ToString(), "");
                }
            }

            // Check the max length
            if (text.Length > m_textBox.MaxLength)
                text = text.Remove(m_textBox.MaxLength, text.Length - m_textBox.MaxLength);

            return text;
        }

        /// <summary>
        /// KeyPressイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        protected override void HandleKeyPress(object sender, KeyPressEventArgs e)
         {
            TraceLine("AlphanumericBehavior.HandleKeyPress " + e.KeyChar);

            // Check to see if it's read only
            if (m_textBox.ReadOnly || m_invalidChars == null)
                return;

            char c = e.KeyChar;
            e.Handled = true;

            if (!Char.IsControl(c) && !Char.IsDigit(c) && !((c >= 'a' && c <= 'z') 
                || (c >= 'A' && c <= 'Z')))
            {
                return;
            }

            // Check if the character is invalid				
            if (Array.IndexOf(m_invalidChars, c) >= 0)
            {
                MessageBeep(MessageBoxIcon.Exclamation);
                return;
            }

            // If the number of characters is already at Max, overwrite
            string text = m_textBox.Text;
            if (text.Length == m_textBox.MaxLength && m_textBox.MaxLength > 0 && !Char.IsControl(c))
            {
                int start, end;
                m_selection.Get(out start, out end);

                if (start < m_textBox.MaxLength)
                    m_selection.SetAndReplace(start, start + 1, c.ToString());

                return;
            }

            base.HandleKeyPress(sender, e);
        }
    }
}


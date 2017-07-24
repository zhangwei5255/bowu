using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Win.YMK.Controls.InputMan.TextBoxs
{
    public class StringTextBox : System.Windows.Forms.TextBox
    {
        //add by I.TYOU 20131218 start
        //複数行の場合、単語の折り返しモード
        public enum WordBreak
        {
            WORD_MODE, // 単語を単位とする
            CHAR_MODE //charを単位とする
        };

        private WordBreak _wordMode = WordBreak.WORD_MODE;
        private const Int32 EM_SETWORDBREAKPROC = 0xD0;
        private const Int32 EM_GETWORDBREAKPROC = 0xD1;
        private delegate Int32 EditWordBreakProc(IntPtr lpch, Int32 ichCurrent, Int32 cch, Int32 code);

        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SendMessageW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr SendMessageSet(IntPtr hWndControl, Int32 msgId, IntPtr wParam, EditWordBreakProc lParam);

        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SendMessageW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern EditWordBreakProc SendMessageGet(IntPtr hWndControl, Int32 msgId, IntPtr wParam, IntPtr lParam);

        public Int32 MyEditWordBreakProc(IntPtr lpch, Int32 ichCurrent, Int32 cch, Int32 code)
        {

            return ichCurrent;
        }

      
        private EditWordBreakProc m_PrevProc;
        private EditWordBreakProc m_CurrentProc;

        [Description("複数行の場合、単語の折り返しモード")]
        public WordBreak WordMode
        {
            get
            {
                return _wordMode;
            }
            set
            {
                if (value == WordBreak.CHAR_MODE)
                {
                    setCharWrapProc();
                }
                _wordMode = value;
            }
        }

        // 改行制御処理セット
        private void setCharWrapProc()
        {
            m_CurrentProc = MyEditWordBreakProc;
            m_PrevProc = SendMessageGet(this.Handle, EM_GETWORDBREAKPROC, IntPtr.Zero, IntPtr.Zero);
            SendMessageSet(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, m_CurrentProc);
        }

        private void unSetCharWrapProc()
        {
            SendMessageSet(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, m_PrevProc);
        }

        // プロパティの上書き
        public override bool Multiline
        {
            set
            {
                base.Multiline = value;
                //if (this.WordMode == WordBreak.CHAR_MODE)
                //{
                //    setCharWrap();
                //}
            }
            get
            {

                return base.Multiline;

            }
        }
        //add by I.TYOU 20131218 end

         ~StringTextBox() 
        {
            unSetCharWrapProc();
        }
    }
}

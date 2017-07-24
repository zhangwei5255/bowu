using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

//******************************************************************************
//  クラス名 ：Selection
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：テキストボックスで選択する内容
//  更新履歴 ：
//******************************************************************************

namespace Win.YMK.Controls.InputMan
{
    public class Selection
    {
        // フィールド
		private TextBoxBase m_textBox;

		/// <summary>
		///  テキストの内容が変換時　イベントが発生する 
        /// </summary>
		public event EventHandler TextChanging;
		
        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">TextBoxBase</param>
		public Selection(TextBoxBase textBox)
		{
			m_textBox = textBox;
		}

        /// <summary>
        /// 構造関数
        /// </summary>
        /// <param name="textBox">TextBoxBase</param>
        /// <param name="start">選択内容の開始インデックス</param>
        /// <param name="end">選択内容の終了インデックス</param>
		public Selection(TextBoxBase textBox, int start, int end)
		{
			m_textBox = textBox;
			Set(start, end);
		}

        /// <summary>
        /// 選択内容をセット
        /// </summary>
        /// <param name="start">選択内容の開始インデックス</param>
        /// <param name="end">選択内容の終了インデックス</param>
		public void Set(int start, int end)
		{
			m_textBox.SelectionStart = start;
			m_textBox.SelectionLength = end - start;
		}		
		
        /// <summary>
        /// 選択内容の開始インデックスと終了インデックスを取得する
        /// </summary>
        /// <param name="start">選択内容の開始インデックス</param>
        /// <param name="end">選択内容の終了インデックス</param>
		public void Get(out int start, out int end)
		{
			start = m_textBox.SelectionStart;
			end = start + m_textBox.SelectionLength;
			
			if (start < 0)
				start = 0;
			if (end < start)
				end = start;
		}
				
        /// <summary>
        /// 選択内容を切替
        /// </summary>
        /// <param name="text">切替の内容</param>
		public void Replace(string text)
		{
			if (TextChanging != null)
				TextChanging(this, null);

			m_textBox.SelectedText = text;
		}

		/// <summary>
        /// 選択内容を設置して切替える
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="text"></param>
		public void SetAndReplace(int start, int end, string text)
		{
			Set(start, end);
			Replace(text);
		}		

		/// <summary>
        /// 選択内容の開始インデックスと終了インデックスを移す
		/// </summary>
        /// <param name="start">開始インデックスが移す相対位置</param>
        /// <param name="end">終了インデックスが移す相対位置</param>
		public void MoveBy(int start, int end)
		{
			End += end;
			Start += start;
		}
			
        /// <summary>
        /// 選択内容を移す
        /// </summary>
        /// <param name="pos">相対位置</param>
		public void MoveBy(int pos)
		{
			MoveBy(pos, pos);
		}

	    /// <summary>
        /// Selectionを生成する
	    /// </summary>
        /// <param name="selection">selection</param>
        /// <param name="pos">相対位置</param>
        /// <returns>生成するSelection</returns>
		public static Selection operator +(Selection selection, int pos)
		{
			return new Selection(selection.m_textBox, selection.Start + pos, selection.End + pos);
		}			
		
        /// <summary>
        /// m_textBoxを取得する
        /// </summary>
		public TextBoxBase TextBox
		{
			get 
			{ 
				return m_textBox; 
			}
		}
		
		/// <summary>
		/// 選択内容の開始インデックス
		/// </summary>
		public int Start
		{
			get 
			{ 
				return m_textBox.SelectionStart; 
			}
			set
			{
				m_textBox.SelectionStart = value;
			}
		}
		
	　　
	    /// <summary>
        /// 選択内容の終了インデックス
	    /// </summary>
		public int End
		{
			get 
			{ 
				return m_textBox.SelectionStart + m_textBox.SelectionLength; 
			}
			set
			{
				m_textBox.SelectionLength = value - m_textBox.SelectionStart;
			}
		}

        /// <summary>
        /// 選択内容の長さ
        /// </summary>
		public int Length
		{
			get 
			{ 
				return m_textBox.SelectionLength; 
			}
			set
			{
				m_textBox.SelectionLength = value;
			}
		}

        /// <summary>
        /// カレント選択内容の開始位置と終了位置を保存する
        /// </summary>
        public class Saver : IDisposable
        {
            // フィールド
            private TextBoxBase m_textBox;
            private Selection m_selection;
            private int m_start, m_end;

            /// <summary>
            /// 構造関数
            /// </summary>
            /// <param name="textBox">TextBoxBase</param>
            public Saver(TextBoxBase textBox)
            {
                m_textBox = textBox;
                m_selection = new Selection(textBox);
                m_selection.Get(out m_start, out m_end);
            }

	        /// <summary>
	        /// 構造関数
	        /// </summary>
            /// <param name="textBox">TextBoxBase</param>
	        /// <param name="start">開始位置</param>
	        /// <param name="end">終了位置</param>
            public Saver(TextBoxBase textBox, int start, int end)
            {
                m_textBox = textBox;
                m_selection = new Selection(textBox);
                Debug.Assert(start <= end);

                m_start = start;
                m_end = end;
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置を保存する
            /// </summary>
            public void Restore()
            {
                if (m_textBox == null)
                    return;

                m_selection.Set(m_start, m_end);
                m_textBox = null;
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置を保存する
            /// </summary>
            public void Dispose()
            {
                Restore();
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置をセット
            /// </summary>
            /// <param name="start">開始位置</param>
            /// <param name="end">開始位置</param>
            public void MoveTo(int start, int end)
            {
                Debug.Assert(start <= end);

                m_start = start;
                m_end = end;
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置をセット
            /// </summary>
            /// <param name="start">開始相対位置</param>
            /// <param name="end">開始相対位置</param>
            public void MoveBy(int start, int end)
            {
                m_start += start;
                m_end += end;

                Debug.Assert(m_start <= m_end);
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置をセット
            /// </summary>
            /// <param name="pos">移す相対位置</param>
            public void MoveBy(int pos)
            {
                m_start += pos;
                m_end += pos;
            }

	        /// <summary>
	        /// 新しいSaverを取得する
	        /// </summary>
	        /// <param name="saver">古いSaver</param>
            /// <param name="pos">移す相対位置</param>
            /// <returns>新しいSaver</returns>
            public static Saver operator +(Saver saver, int pos)
            {
                return new Saver(saver.m_textBox, saver.m_start + pos, saver.m_end + pos);
            }

            /// <summary>
            /// m_textBoxを取得する
            /// </summary>
            public TextBoxBase TextBox
            {
                get
                {
                    return m_textBox;
                }
            }

          	/// <summary>
          	/// 選択内容の開始位置
          	/// </summary>
            public int Start
            {
                get
                {
                    return m_start;
                }
                set
                {
                    m_start = value;
                }
            }

	        /// <summary>
	        /// 選択内容の終了位置
	        /// </summary>
            public int End
            {
                get
                {
                    return m_end;
                }
                set
                {
                    m_end = value;
                }
            }

            /// <summary>
            /// 選択内容の開始位置と終了位置を更新する
            /// </summary>
            public void Update()
            {
                if (m_textBox != null)
                    m_selection.Get(out m_start, out m_end);
            }

	        /// <summary>
            /// m_textBoxをNULLにセット
	        /// </summary>
            public void Disable()
            {
                m_textBox = null;
            }
        }
    }
}


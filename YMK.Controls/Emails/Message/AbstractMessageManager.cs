using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Win.YMK.Controls.Emails.Message
{


    public abstract class AbstractMessageManager : MessageManager
    {
        protected internal const string REPLACE_BASE_CHAR = "%";
        protected internal const string MESSAGE_DELIMITER = "　";
        protected internal const string CATEGORY_DELIMITER = "-";
        protected internal const string INITIAL_INNER_MSG = "CMN-10";
        protected internal const string CMN_1001E = "CMN-1001E : メッセージIDが指定されていません。";
        protected internal const string CMN_1002E = "CMN-1002E : 指定されたIDに該当するメッセージが存在しません。 : ";
        protected internal const string CMN_1003E = "CMN-1003E : 置換文字列がnullです。";
        protected internal const string CMN_1004E = "CMN-1004E : メッセージ中の置換対象と置換文字列数が一致しません。";
        protected internal const string CMN_1005E = "CMN-1005E : 置換文字列はString型でなければなりません。";
        protected internal const string CMN_1006E = "CMN-1006E : 置換処理時に予期せぬ例外が発生しました。 : ";
        protected internal const string CMN_1007W = "CMN-1007W : メッセージIDが重複しています。メッセージID : ";
        protected internal const string CMN_1008E = "CMN-1008E : XMLファイル読み込み処理時に予期せぬ例外が発生しました。 : ";

        public abstract string getMessage(MessageInformation paramMessageInformation);

        public abstract string getMessage(string paramString);

        public abstract string getMessage(string paramString1, string paramString2);

        public abstract string getMessage(string paramString, IList<string> paramList);

        public abstract string getMessage(string paramString1, string paramString2, string paramString3);

        public abstract string getMessage(string paramString1, string paramString2, string paramString3, string paramString4);

        public abstract string getMessage(string paramString1, string paramString2, string paramString3, IList<string> paramList);

        public abstract string getMessageWithoutId(MessageInformation paramMessageInformation);

        public abstract string getMessageWithoutId(string paramString);

        public abstract string getMessageWithoutId(string paramString1, string paramString2);

        public abstract string getMessageWithoutId(string paramString, IList<string> paramList);

        public abstract string getMessageWithoutId(string paramString1, string paramString2, string paramString3);

        public abstract string getMessageWithoutId(string paramString1, string paramString2, string paramString3, string paramString4);

        public abstract string getMessageWithoutId(string paramString1, string paramString2, string paramString3, IList<string> paramList);

        protected internal static string addMessageId(string msgId, string category, string message)
        {
            string resultMessage = null;
            if (!message.StartsWith("CMN-10", StringComparison.Ordinal))
            {
                resultMessage = msgId + "　" + message;
                if (category != null)
                {
                    resultMessage = category + "-" + resultMessage;
                }
            }
            else
            {
                resultMessage = message;
            }
            return resultMessage;
        }

        protected internal static string replaceToken(string message, string token)
        {
            //IList<string> tokens = new List<string>();
            //if (token != null)
            //{
            //    tokens.Add(token);
            //}
            //return replaceToken(message, tokens);

            return "";
        }

        


        public static string replaceToken(string message, IList<string> tokens)
        {
            //if (message.StartsWith("CMN-10"))
            //{
            //    return message;
            //}
            //if (tokens == null)
            //{
            //    return "CMN-1003E : 置換文字列がnullです。";
            //}
            //String kk;
           
            //String[] messageElement = message.Split('%');
            //if (messageElement.Length - 1 != tokens.Count)
            //{
            //    return "CMN-1004E : メッセージ中の置換対象と置換文字列数が一致しません。";
            //}
            //StringBuilder statementBuffer = new StringBuilder(message);
            //String changeTargetCode = null;
            //String changeToken = null;
            //int changeTokenLength = 0;
            //int changeTargetCodeLength = 0;
            //int location = 0;
            //int startPosition = 0;
            //int index = 0;

            //foreach (string item in tokens)
            //{
            //    changeToken = item;
            //     changeTokenLength = changeToken.Length;
            //    changeTargetCode = "%" + index;
            //    changeTargetCodeLength = changeTargetCode.Length;


            //    location = statementBuffer.IndexOf(changeTargetCode, startPosition);
            //    if (location != -1)
            //    {
            //        statementBuffer.Replace(location, location + changeTargetCodeLength, changeToken);
            //        startPosition = location + changeTokenLength;
            //    }
            //    index++;
            //}
           
            //return statementBuffer.ToString();

            return "";
        }
    }
}
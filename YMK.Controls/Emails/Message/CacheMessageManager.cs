

using System.Collections;
using System.Collections.Generic;
using System;

namespace Win.YMK.Controls.Emails.Message
{

    

    public abstract class CacheMessageManager : AbstractMessageManager
    {
        protected internal static IDictionary<string, string> messageMap = new Dictionary<string,string>();

        public override string getMessage(MessageInformation info)
        {
            MessageInformation key = info;
            if (key == null)
            {
                key = new MessageInformation();
            }
            return addMessageId(key.MsgId, key.MsgCategory, getMessageWithoutId(key));
        }

        public override string getMessage(string msgId)
        {
            return addMessageId(msgId, null, getMessageWithoutId(msgId));
        }

        public override string getMessage(string msgId, string token)
        {
            return addMessageId(msgId, null, getMessageWithoutId(msgId, token));
        }

        public override string getMessage(string msgId, IList<string> tokens)
        {
            return addMessageId(msgId, null, getMessageWithoutId(msgId, tokens));
        }

        public override string getMessage(string msgId, string category, string lang)
        {
            return addMessageId(msgId, category, getMessageWithoutId(msgId, category, lang));
        }

        public override string getMessage(string msgId, string category, string lang, string token)
        {
            return addMessageId(msgId, category, getMessageWithoutId(msgId, category, lang, token));
        }

        public override string getMessage(string msgId, string category, string lang, IList<string> tokens)
        {
            return addMessageId(msgId, category, getMessageWithoutId(msgId, category, lang, tokens));
        }

        public override string getMessageWithoutId(MessageInformation info)
        {
            MessageInformation key = info;
            if (key == null)
            {
                key = new MessageInformation();
            }
            return getMessageWithoutId(key.MsgId, key.MsgCategory, key.MsgLang, key.MsgTokens);
        }

        public override string getMessageWithoutId(string msgId)
        {
            return getMessageWithoutId(msgId, null, null);
        }

        public override string getMessageWithoutId(string msgId, string token)
        {
            return getMessageWithoutId(msgId, null, null, token);
        }

        public override string getMessageWithoutId(string msgId, IList<string> tokens)
        {
            return getMessageWithoutId(msgId, null, null, tokens);
        }


        public override string getMessageWithoutId(string msgId, string category, string lang)
        {
            if ((msgId == null) || ("".Equals(msgId)))
            {
                return "CMN-1001E : メッセージIDが指定されていません。";
            }
            if ((messageMap == null) || (messageMap.Count == 0))
            {
                return "CMN-1002E : 指定されたIDに該当するメッセージが存在しません。 : " + msgId;
            }
            MessageInformation info = new MessageInformation();
            info.MsgId = msgId;
            info.MsgCategory = category;
            info.MsgLang = lang;

            string message = (string)messageMap[info.ToString()];
            if (message == null)
            {
                return "CMN-1002E : 指定されたIDに該当するメッセージが存在しません。 : " + msgId;
            }
            return message;
        }

        public override string getMessageWithoutId(string msgId, string category, string lang, string token)
        {
            string message = getMessageWithoutId(msgId, category, lang);
            if (!message.StartsWith("CMN-10", StringComparison.Ordinal))
            {
                message = replaceToken(message, token);
            }
            return message;
        }

        public override string getMessageWithoutId(string msgId, string category, string lang, IList<string> tokens)
        {
            string message = getMessageWithoutId(msgId, category, lang);
            if (!message.StartsWith("CMN-10", StringComparison.Ordinal))
            {
                message = replaceToken(message, tokens);
            }
            return message;
        }

        public static void addMessage(MessageInformation info, string message)
        {
            if ((info != null) && (info.MsgId != null) && (!"".Equals(info.MsgId)))
            {
                if (messageMap.ContainsKey(info.ToString()))
                {
                    //ComponentLogger.info(typeof(CacheMessageManager), "CMN-1007W : メッセージIDが重複しています。メッセージID : " + info.MsgId);
                }
                messageMap[info.ToString()] = message;
            }
        }

        public static void addMessage(string msgId, string category, string lang, string message)
        {
            MessageInformation info = new MessageInformation();
            info.MsgId = msgId;
            info.MsgCategory = category;
            info.MsgLang = lang;

            addMessage(info, message);
        }

        public static void addMessage(string msgId, string message)
        {
            addMessage(msgId, null, null, message);
        }
    }
}

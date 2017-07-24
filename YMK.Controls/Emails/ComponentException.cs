


using System;
using System.Collections.Generic;
using Win.YMK.Controls.Emails.Message;

namespace Win.YMK.Controls.Emails
{
    public class ComponentException : Exception
    {
        private const long serialVersionUID = 1L;
        private string errorId = null;

        public ComponentException()
        {
            //ComponentLogger.error(this, null, this);
        }

        public ComponentException(Exception cause)
            
        {
            //ComponentLogger.error(this, null, this);
        }

        public ComponentException(object obj, MessageManager messenger, MessageInformation msgInfo)
            : base(messenger.getMessage(msgInfo))
        {
            this.errorId = msgInfo.MsgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgInfo), this);
        }

        public ComponentException(object obj, string logCategory, MessageManager messenger, MessageInformation msgInfo)
            : base(messenger.getMessage(msgInfo))
        {
            this.errorId = msgInfo.MsgId;
            //ComponentLogger.error(obj, logCategory, messenger.getMessage(msgInfo), this);
        }

        public ComponentException(object obj, MessageManager messenger, string msgId)
            : base(messenger.getMessage(msgId))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId), this);
        }

        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId)
            : base(messenger.getMessage(msgId))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, logCategory, messenger.getMessage(msgId), this);
        }

        public ComponentException(object obj, MessageManager messenger, string msgId, Exception cause)
            : base(messenger.getMessage(msgId), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId), cause);
        }

        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, Exception cause)
            : base(messenger.getMessage(msgId), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, logCategory, messenger.getMessage(msgId), cause);
        }

        public ComponentException(object obj, MessageManager messenger, string msgId, string msgToken)
            : base(messenger.getMessage(msgId, msgToken))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), this);
        }

        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, string msgToken)
            : base(messenger.getMessage(msgId, msgToken))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), logCategory, this);
        }

        public ComponentException(object obj, MessageManager messenger, string msgId, IList<string> msgTokens)
            : base(messenger.getMessage(msgId, msgTokens))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgTokens), this);
        }

        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, IList<string> msgTokens)
            : base(messenger.getMessage(msgId, msgTokens))
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgTokens), logCategory, this);
        }

        public ComponentException(object obj, MessageManager messenger, string msgId, string msgToken, Exception cause)
            : base(messenger.getMessage(msgId, msgToken), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), cause);
        }



        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, String logCategory, MessageManager messenger, String msgId, String msgToken, Throwable cause)
        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, string msgToken, Exception cause)
            : base(messenger.getMessage(msgId, msgToken), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), logCategory, cause);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, MessageManager messenger, String msgId, String msgToken, String msgCategory, String lang, Throwable cause)
        public ComponentException(object obj, MessageManager messenger, string msgId, string msgToken, string msgCategory, string lang, Exception cause)
            : base(messenger.getMessage(msgId, msgCategory, lang, msgToken), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), cause);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, String logCategory, MessageManager messenger, String msgId, String msgToken, String msgCategory, String lang, Throwable cause)
        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, string msgToken, string msgCategory, string lang, Exception cause)
            : base(messenger.getMessage(msgId, msgCategory, lang, msgToken), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgToken), logCategory, cause);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, MessageManager messenger, String msgId, List<String> msgTokens, Throwable cause)
        public ComponentException(object obj, MessageManager messenger, string msgId, IList<string> msgTokens, Exception cause)
            : base(messenger.getMessage(msgId, msgTokens), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgTokens), cause);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, String logCategory, MessageManager messenger, String msgId, List<String> msgTokens, Throwable cause)
        public ComponentException(object obj, string logCategory, MessageManager messenger, string msgId, IList<string> msgTokens, Exception cause)
            : base(messenger.getMessage(msgId, msgTokens), cause)
        {
            this.errorId = msgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgId, msgTokens), logCategory, cause);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, MessageManager messenger, MessageInformation msgInfo, Throwable cause)
        public ComponentException(object obj, MessageManager messenger, MessageInformation msgInfo, Exception cause)
            : base(messenger.getMessage(msgInfo), cause)
        {
            this.errorId = msgInfo.MsgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgInfo), this);
        }

        //JAVA TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
        //ORIGINAL LINE: public ComponentException(Object obj, String logCategory, MessageManager messenger, MessageInformation msgInfo, Throwable cause)
        public ComponentException(object obj, string logCategory, MessageManager messenger, MessageInformation msgInfo, Exception cause)
            : base(messenger.getMessage(msgInfo), cause)
        {
            this.errorId = msgInfo.MsgId;
            //ComponentLogger.error(obj, messenger.getMessage(msgInfo), logCategory, this);
        }

        public virtual string ErrorId
        {
            get
            {
                return this.errorId;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Win.YMK.Controls.Emails
{


    internal class MailInformation
    {
        //private static readonly string NATIVE_RETURN_CODE = "\n\t";
        private const int DEFAULT_CONTIMEOUT = 60000;
        private const int DEFAULT_SENDTIMEOUT = 60000;
        private const int DEFAULT_SMTP_PORT = 25;
        private const bool DEFAULT_DEBUGMODE = false;
        private IList<string> toAddressList;
        private IList<string> ccAddressList;
        private IList<string> bccAddressList;
        private string fromAddress;
        private string fromName;
        private string subject;
        private string message;
        private string messageHeader;
        private string messageFooter;
        private IList<string> attachFileList;
        private string smtpHost;
        private int smtpPort;
        private string smtpUser;
        private string smtpPassword;
        private int conTimeOut;
        private int sendTimeOut;
        private bool debugMode;
        private string mailEncoding;

        protected internal MailInformation()
        {
            this.toAddressList = new List<string>();
            this.ccAddressList = new List<string>();
            this.bccAddressList = new List<string>();
            this.attachFileList = new List<string>();


            this.conTimeOut = 60000;
            this.sendTimeOut = 60000;
            this.debugMode = false;
            this.smtpPort = 25;
        }

        public virtual IList<string> AttachFileList
        {
            get
            {
                return this.attachFileList;
            }
        }

        public virtual void addAttachFiles(string attachFile)
        {
            this.attachFileList.Add(attachFile);
        }

        public virtual string MailEncoding
        {
            get
            {
                return this.mailEncoding;
            }
            set
            {
                this.mailEncoding = value;
            }
        }


        public virtual string FromAddress
        {
            get
            {
                return this.fromAddress;
            }
            set
            {
                this.fromAddress = value;
            }
        }


        public virtual string FromName
        {
            get
            {
                return this.fromName;
            }
            set
            {
                this.fromName = value;
            }
        }


        public virtual string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public virtual string MessageFooter
        {
            set
            {
                this.messageFooter = value;
            }
        }

        public virtual string MessageHeader
        {
            get
            {
                return this.messageHeader;
            }
            set
            {
                this.messageHeader = value;
            }
        }


        public virtual string SmtpHost
        {
            get
            {
                return this.smtpHost;
            }
            set
            {
                this.smtpHost = value;
            }
        }


        public virtual int SmtpPort
        {
            get
            {
                return this.smtpPort;
            }
            set
            {
                this.smtpPort = value;
            }
        }


        public virtual string SmtpUser
        {
            get
            {
                return this.smtpUser;
            }
            set
            {
                this.smtpUser = value;
            }
        }


        public virtual string SmtpPassword
        {
            get
            {
                return this.smtpPassword;
            }
            set
            {
                this.smtpPassword = value;
            }
        }


        public virtual string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }


        public virtual IList<string> ToAddressList
        {
            get
            {
                return this.toAddressList;
            }
            set
            {
                this.toAddressList = value;
            }
        }


        public virtual void addToAddress(string toAddress)
        {
            this.toAddressList.Add(toAddress);
        }

        public virtual IList<string> CcAddressList
        {
            get
            {
                return this.ccAddressList;
            }
            set
            {
                this.ccAddressList = value;
            }
        }


        public virtual void addCcAddress(string ccAddress)
        {
            this.ccAddressList.Add(ccAddress);
        }

        public virtual IList<string> BccAddressList
        {
            set
            {
                this.bccAddressList = value;
            }
        }

        public virtual void addBccAddress(string bccAddress)
        {
            this.bccAddressList.Add(bccAddress);
        }

        public virtual int ConTimeOut
        {
            get
            {
                return this.conTimeOut;
            }
            set
            {
                this.conTimeOut = value;
            }
        }


        public virtual bool DebugMode
        {
            get
            {
                return this.debugMode;
            }
            set
            {
                this.debugMode = value;
            }
        }


        public virtual int SendTimeOut
        {
            get
            {
                return this.sendTimeOut;
            }
            set
            {
                this.sendTimeOut = value;
            }
        }


        public override string ToString()
        {
            StringBuilder mailInfo = new StringBuilder();

            mailInfo.AppendLine().Append("-----------[MailInformation]-----------").AppendLine();



            IEnumerator<string> it = this.toAddressList.GetEnumerator();
            while (it.MoveNext())
            {
                mailInfo.Append("[TO-ADDRESS]:").Append((string)it.Current).AppendLine();
            }
            it = this.ccAddressList.GetEnumerator();
            while (it.MoveNext())
            {
                mailInfo.Append("[CC-ADDRESS]:").Append((string)it.Current).AppendLine();
            }
            it = this.bccAddressList.GetEnumerator();
            while (it.MoveNext())
            {
                mailInfo.Append("[BCC-ADDRESS]:").Append((string)it.Current).AppendLine();
            }
            mailInfo.Append("[FROM-ADDRESS]:").Append(this.fromAddress).AppendLine().Append("[FROM-NAME]:").Append(this.fromName).AppendLine().Append("[SUBJECT]:").Append(this.subject).AppendLine();









            it = this.attachFileList.GetEnumerator();
            while (it.MoveNext())
            {
                mailInfo.Append("[ATTACH-FILE]:").Append((string)it.Current).AppendLine();
            }
            mailInfo.Append("[SMTP-HOST]:").Append(this.smtpHost).AppendLine().Append("-----------[MailInformation]-----------");




            return mailInfo.ToString();
        }
    }
}

  
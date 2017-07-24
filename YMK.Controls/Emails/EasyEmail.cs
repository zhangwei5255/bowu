using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

//******************************************************************************
//  •Ø•È•π√ÅE£∫EasyEmail
//  ◊˜≥…’ﬂ°° £∫èàÕ˛
//  ◊˜≥…»’°° £∫2007-04-21
//  ÑI¿˙‡⁄»› £∫∫ÅEg§ •·©`•ÅEÚÀÕ§ÅE
//  ∏ÅE¬¬ƒös £∫
//******************************************************************************

namespace Win.YMK.Controls.Emails
{
    public partial class EasyEmail : Component
    {
        private MailMessage MailObject;                                   //•·©`•ÅEŒ«ÈàÛ§Ú∏Òº{§π§ÅE

        private string _MailFrom;                                        //≤˚œˆ»À§Œ•·©`•ÅE¢•…•ÅE?
        private string _MailTo;                                          // ‹»°»À•·©`•ÅE¢•…•ÅE?
        private string _MailSubject;                                     //•·©`•ÅEŒ÷˜Ó}
        private string _MailBody;                                        //•·©`•ÅEŒ•‹•«•£≤ø∑?
        private string _SMTPServer;                                      //•µ©`•”•π°°¿˝§®§ÅE∫smtp.gmail.com
        private int _SMTPPort;                                           //•µ©`•”•π§Œ•›©`•»
        private string _SMTPUsername;                                    //≤˚œˆ»À§Œ√˚«∞
        private string _SMTPPassword;                                    //≤˚œˆ»À§Œ•·©`•ÅEŒ•—•π•ÅE`•…
        private bool _SMTPSSL;                                           //•·©`•ÅEÚΩ”æA§π§ÅEr°°∞µ∫≈ªØ§π§ÅE´§…§¶§?
        private bool _sendAsync;                                         //true:•·©`•ÅEÚÀÕ§ÅErSendAsync•·•Ω•√•…§Ú•≥©`•ÅEπ§ÅE¢false:•·©`•ÅEÚÀÕ§ÅErSend•·•Ω•√•…§Ú•≥©`•ÅEπ§ÅE
        private bool _tryAgianOnFailure;                                 //•·©`•ÅEÚÀÕ§ÅEŒ§œ ßî°§´§…§¶§?
        private int _tryAgainDelayTime;                                  //¥˝§ƒïrÈg
        private string _attachmentsName;                                 //Ã˙‘∂§Œ√˚≥∆
        private string _randomPassword;                                  //–¬§∑§§•Ê©`•∂§Ú…ÅEà§π§ÅEr•È•Û•¿•‡§ •—•π•ÅE`•…§Ú…˙≥…§π§ÅE

        public EasyEmail()
        {
            InitializeComponent();

            //≥ı∆⁄ªØ
            init();
        }

        public EasyEmail(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //≥ı∆⁄ªØ
            init();
        }

        #region "•◊•˙¡—•«•£"
        /// <summary>
        /// ≤˚œˆ»À§Œ•·©`•ÅE¢•…•ÅE?
        /// </summary>
        public string MailFrom
        {
            get
            {
                return _MailFrom;
            }
            set
            {
                _MailFrom = value;
            }
        }

        /// <summary>
        ///  ‹»°»À•·©`•ÅE¢•…•ÅE?
        /// </summary>
        public string MailTo
        {
            get
            {
                return _MailTo;
            }
            set
            {
                _MailTo = value;
            }
        }

        /// <summary>
        /// •·©`•ÅEŒ÷˜Ó}
        /// </summary>
        public string MailSubject
        {
            get
            {
                return _MailSubject;
            }
            set
            {
                _MailSubject = value;
            }
        }

        /// <summary>
        /// •·©`•ÅEŒ•‹•«•£≤ø∑?
        /// </summary>
        public string MailBody
        {
            get
            {
                return _MailBody;
            }
            set
            {
                _MailBody = value;
            }
        }

        /// <summary>
        /// •µ©`•”•π°°¿˝§®§ÅE∫smtp.gmail.com
        /// </summary>
        public string SMTPServer
        {
            get
            {
                return _SMTPServer;
            }
            set
            {
                _SMTPServer = value;
            }
        }

        /// <summary>
        /// •µ©`•”•π§Œ•›©`•»
        /// </summary>
        public int SMTPPort
        {
            get
            {
                return _SMTPPort;
            }
            set
            {
                _SMTPPort = value;
            }
        }

        /// <summary>
        /// ≤˚œˆ»À§Œ√˚«∞
        /// </summary>
        public string SMTPUsername
        {
            get
            {
                return _SMTPUsername;
            }
            set
            {
                _SMTPUsername = value;
            }
        }

        /// <summary>
        /// ≤˚œˆ»À§Œ•·©`•ÅEŒ•—•π•ÅE`•…
        /// </summary>
        public string SMTPPassword
        {
            get
            {
                return _SMTPPassword;
            }
            set
            {
                _SMTPPassword = value;
            }
        }

        /// <summary>
        /// •·©`•ÅEÚΩ”æA§π§ÅEr°°∞µ∫≈ªØ§π§ÅE´§…§¶§?
        /// </summary>
        public bool SMTPSSL
        {
            get
            {
                return _SMTPSSL;
            }
            set
            {
                _SMTPSSL = value;
            }
        }

        /// <summary>
        /// true:•·©`•ÅEÚÀÕ§ÅErSendAsync•·•Ω•√•…§Ú•≥©`•ÅEπ§ÅE¢false:•·©`•ÅEÚÀÕ§ÅErSend•·•Ω•√•…§Ú•≥©`•ÅEπ§ÅE
        /// </summary>
        public bool SendAsync
        {
            get
            {
                return _sendAsync;
            }
            set
            {
                _sendAsync = value;
            }
        }

        /// <summary>
        /// •·©`•ÅEÚÀÕ§ÅEŒ§œ ßî°§´§…§¶§?
        /// </summary>
        public bool TryAgianOnFailure
        {
            get
            {
                return _tryAgianOnFailure;
            }
            set
            {
                _tryAgianOnFailure = value;
            }
        }

        /// <summary>
        /// ¥˝§ƒïrÈg
        /// </summary>
        public int TryAgainDelayTime
        {
            get
            {
                return _tryAgainDelayTime;
            }
            set
            {
                _tryAgainDelayTime = value;
            }
        }

        /// <summary>
        /// Ã˙‘∂§Œ√˚≥∆
        /// </summary>
        public string AttachmentsName
        {
            get
            {
                return _attachmentsName;
            }
            set
            {
                _attachmentsName = value;
            }
        }

        /// <summary>
        /// –¬§∑§§•Ê©`•∂§Ú…ÅEà§π§ÅEr•È•Û•¿•‡§ •—•π•ÅE`•…§Ú…˙≥…§π§ÅE
        /// </summary>
        public string RandomPassword
        {
            get
            {
                return _randomPassword;
            }
            set
            {
                _randomPassword = value;
            }
        }

#endregion 

        /// <summary>
        /// •·©`•ÅEÚÀÕ§ÅE
        /// </summary>
        /// <returns>•·©`•ÅEÚÀÕ§ÅEŒ§œ≥…π¶§´§…§¶§?/returns>
        public bool Send()
        {
            MailMessage Email = new MailMessage();
            Email.To.Add(MailTo);                                                                            // ‹»°»À•·©`•ÅE¢•…•ÅEπ§Ú◊∑º”§π§ÅE
            MailAddress mailAddFrom = new MailAddress(MailFrom, MailFrom, System.Text.Encoding.UTF8);
            Email.From = mailAddFrom;                                                                           //≤˚œˆ»À•·©`•ÅE¢•…•ÅEπ§Ú•ª•√•»§π§ÅE
            
            //•·©`•ÅEŒ÷˜Ó}§Ú•ª•√•»
            Email.Subject = MailSubject;
            Email.SubjectEncoding = System.Text.Encoding.UTF8;

            //•·©`•ÅEŒ•‹•«•£§Ú•ª•√•?
            SetMailBody();
          
            //•·©`•ÅEŒ•‹•«•£§Ú•ª•√•?
            Email.Body = MailBody;
            Email.BodyEncoding = System.Text.Encoding.UTF8;

            Email.IsBodyHtml = false;
            Email.Priority = System.Net.Mail.MailPriority.High;

            if (AttachmentsName != "" && AttachmentsName != null)
            {
                //•·©`•ÅEÀÃ˙‘∂§Ú◊∑º”§π§ÅE
                Attachment data = new Attachment(AttachmentsName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(AttachmentsName);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(AttachmentsName);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(AttachmentsName);
                Email.Attachments.Add(data);
            }
      
            SmtpClient SmtpMail = new SmtpClient();

            //•µ©`•”•π§Ú•ª•√•»
            SmtpMail.Host = SMTPServer;
            SmtpMail.Port = SMTPPort;
            SmtpMail.EnableSsl = SMTPSSL;
            SmtpMail.UseDefaultCredentials = false;
            SmtpMail.Credentials = new NetworkCredential(SMTPUsername, SMTPPassword);

            Boolean bTemp = true;

            try
            {
                string sTemp = "";
                if (SendAsync)
                {
                    //•·©`•ÅEÚÀÕ§ÅE
                    SmtpMail.SendAsync(Email, sTemp);
                }
                else
                {
                    //•·©`•ÅEÚÀÕ§ÅE
                    SmtpMail.Send(Email);
                }
                    
            }
            catch
            {
                bTemp = false;
            }

            return bTemp;
        }

        /// <summary>
        /// ≥ı∆⁄ªØ
        /// </summary>
        private void init()
        {
            MailObject = new MailMessage();

            MailFrom = "zhangweisendmail@gmail.com";                     //≤˚œˆ»À§Œ•·©`•ÅE¢•…•ÅE?
            MailTo = "";                                                 // ‹»°»À§Œ•·©`•ÅE¢•…•ÅE?
            MailSubject = "òÀú »’±æ’Z√„èä•∑•π•∆•ÅE";                     //•·©`•ÅEŒ÷˜Ó}
            MailBody = "";                                               //•·©`•ÅEŒ•‹•«•?
            SMTPServer = "smtp.gmail.com";  //•µ©`•”•π
            SMTPPort = 587;                                              //•µ©`•”•π§Œ•›©`•»
            SMTPUsername = "pmaikej";                                    //•·©`•ÅEÊ©`•∂£…£ƒ
            SMTPPassword = "0728-5255900";                               //•·©`•ÅE—•π•ÅE`•…
            SMTPSSL = true;                                              //•·©`•ÅEÚÀÕ§ÅEr∞µ∫≈ªØ§π§ÅE
            SendAsync = false;
            TryAgianOnFailure = true;
            TryAgainDelayTime = 10000;
            RandomPassword = "000000";                                   //•È•Û•¿•‡§ •—•π•ÅE`•…
        }

        /// <summary>
        /// •·©`•ÅEŒ•‹•«•£§Ú•ª•√•?
        /// </summary>
        /// <param name="random"></param>
        private void SetMailBody()
        {
            MailBody += "§™∆£§ÅEî§«§π°?" + "\n";
            MailBody += "°°§Ω§Œ•·©`•ÅE¨•∑•π•∆•‡§À◊‘ÅE§ÀÀÕ§È§ÅEÅEŒ§«°¢∑µ ¬§∑§ﬁ§ª§Û°?" + "\n";
            MailBody += "  òÀú »’±æ’Z√„èä•∑•π•∆•‡§Ú π§¶§≥§»§ÚöZ”≠§∑§ﬁ§π°£" + "\n";
            MailBody += "  æ˝§œ•—•π•ÅE`•…§¨" + RandomPassword + "§«§π°£òÀú »’±æ’Z√„èä•∑•π•∆•‡§Ú•˙¡∞•§•Û§∑§∆°¢•—•π•ÅE`•…§Ú–ﬁ’˝§∑§ø§€§¶§¨§§§§§«§π§Ë°£" + "\n";
            MailBody += "“‘…œ§«§π°£§Ë§˙¿∑§Ø§™˚¶§§§∑§ﬁ§π°£" +"\n";
            MailBody += "òÀú »’±æ’Z√„èä•∑•π•∆•‡È_∞k•¡©`•ÅE";
        }
        
    }
}

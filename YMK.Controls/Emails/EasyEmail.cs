using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

//******************************************************************************
//  ���饹ÁE��EasyEmail
//  �����ߡ� ������
//  �����ա� ��2007-04-21
//  �I������ ����Eg�ʥ�`��E��ͤ�E
//  ��E��Ěs ��
//******************************************************************************

namespace Win.YMK.Controls.Emails
{
    public partial class EasyEmail : Component
    {
        private MailMessage MailObject;                                   //��`��E������{����E

        private string _MailFrom;                                        //�����ˤΥ�`��E��ɥ�E?
        private string _MailTo;                                          //��ȡ�˥�`��E��ɥ�E?
        private string _MailSubject;                                     //��`��E����}
        private string _MailBody;                                        //��`��EΥܥǥ����?
        private string _SMTPServer;                                      //���`�ӥ���������E�smtp.gmail.com
        private int _SMTPPort;                                           //���`�ӥ��Υݩ`��
        private string _SMTPUsername;                                    //�����ˤ���ǰ
        private string _SMTPPassword;                                    //�����ˤΥ�`��EΥѥ���E`��
        private bool _SMTPSSL;                                           //��`��E�ӾA����Er�����Ż�����E��ɤ��?
        private bool _sendAsync;                                         //true:��`��E��ͤ�ErSendAsync�᥽�åɤ򥳩`��E���E�false:��`��E��ͤ�ErSend�᥽�åɤ򥳩`��E���E
        private bool _tryAgianOnFailure;                                 //��`��E��ͤ�EΤ�ʧ�����ɤ��?
        private int _tryAgainDelayTime;                                  //���ĕr�g
        private string _attachmentsName;                                 //��Զ������
        private string _randomPassword;                                  //�¤�����`����ɁE�����Er������ʥѥ���E`�ɤ����ɤ���E

        public EasyEmail()
        {
            InitializeComponent();

            //���ڻ�
            init();
        }

        public EasyEmail(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //���ڻ�
            init();
        }

        #region "�ץ��ѥǥ�"
        /// <summary>
        /// �����ˤΥ�`��E��ɥ�E?
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
        /// ��ȡ�˥�`��E��ɥ�E?
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
        /// ��`��E����}
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
        /// ��`��EΥܥǥ����?
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
        /// ���`�ӥ���������E�smtp.gmail.com
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
        /// ���`�ӥ��Υݩ`��
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
        /// �����ˤ���ǰ
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
        /// �����ˤΥ�`��EΥѥ���E`��
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
        /// ��`��E�ӾA����Er�����Ż�����E��ɤ��?
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
        /// true:��`��E��ͤ�ErSendAsync�᥽�åɤ򥳩`��E���E�false:��`��E��ͤ�ErSend�᥽�åɤ򥳩`��E���E
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
        /// ��`��E��ͤ�EΤ�ʧ�����ɤ��?
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
        /// ���ĕr�g
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
        /// ��Զ������
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
        /// �¤�����`����ɁE�����Er������ʥѥ���E`�ɤ����ɤ���E
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
        /// ��`��E��ͤ�E
        /// </summary>
        /// <returns>��`��E��ͤ�EΤϳɹ����ɤ��?/returns>
        public bool Send()
        {
            MailMessage Email = new MailMessage();
            Email.To.Add(MailTo);                                                                            //��ȡ�˥�`��E��ɥ�E���׷�Ӥ���E
            MailAddress mailAddFrom = new MailAddress(MailFrom, MailFrom, System.Text.Encoding.UTF8);
            Email.From = mailAddFrom;                                                                           //�����˥�`��E��ɥ�E��򥻥åȤ���E
            
            //��`��E����}�򥻥å�
            Email.Subject = MailSubject;
            Email.SubjectEncoding = System.Text.Encoding.UTF8;

            //��`��EΥܥǥ��򥻥å?
            SetMailBody();
          
            //��`��EΥܥǥ��򥻥å?
            Email.Body = MailBody;
            Email.BodyEncoding = System.Text.Encoding.UTF8;

            Email.IsBodyHtml = false;
            Email.Priority = System.Net.Mail.MailPriority.High;

            if (AttachmentsName != "" && AttachmentsName != null)
            {
                //��`��E���Զ��׷�Ӥ���E
                Attachment data = new Attachment(AttachmentsName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(AttachmentsName);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(AttachmentsName);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(AttachmentsName);
                Email.Attachments.Add(data);
            }
      
            SmtpClient SmtpMail = new SmtpClient();

            //���`�ӥ��򥻥å�
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
                    //��`��E��ͤ�E
                    SmtpMail.SendAsync(Email, sTemp);
                }
                else
                {
                    //��`��E��ͤ�E
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
        /// ���ڻ�
        /// </summary>
        private void init()
        {
            MailObject = new MailMessage();

            MailFrom = "zhangweisendmail@gmail.com";                     //�����ˤΥ�`��E��ɥ�E?
            MailTo = "";                                                 //��ȡ�ˤΥ�`��E��ɥ�E?
            MailSubject = "�˜��ձ��Z�㏊�����ƥ�E";                     //��`��E����}
            MailBody = "";                                               //��`��EΥܥǥ?
            SMTPServer = "smtp.gmail.com";  //���`�ӥ�
            SMTPPort = 587;                                              //���`�ӥ��Υݩ`��
            SMTPUsername = "pmaikej";                                    //��`��E�`���ɣ�
            SMTPPassword = "0728-5255900";                               //��`��Eѥ���E`��
            SMTPSSL = true;                                              //��`��E��ͤ�Er���Ż�����E
            SendAsync = false;
            TryAgianOnFailure = true;
            TryAgainDelayTime = 10000;
            RandomPassword = "000000";                                   //������ʥѥ���E`��
        }

        /// <summary>
        /// ��`��EΥܥǥ��򥻥å?
        /// </summary>
        /// <param name="random"></param>
        private void SetMailBody()
        {
            MailBody += "��ƣ��E��Ǥ��?" + "\n";
            MailBody += "�����Υ�`��E������ƥ���ԁE���ͤ餁E�EΤǡ����¤��ޤ���?" + "\n";
            MailBody += "  �˜��ձ��Z�㏊�����ƥ��ʹ�����Ȥ�Zӭ���ޤ���" + "\n";
            MailBody += "  ���ϥѥ���E`�ɤ�" + RandomPassword + "�Ǥ����˜��ձ��Z�㏊�����ƥ��������󤷤ơ��ѥ���E`�ɤ����������ۤ��������Ǥ��衣" + "\n";
            MailBody += "���ϤǤ�������������������ޤ���" +"\n";
            MailBody += "�˜��ձ��Z�㏊�����ƥ��_�k���`��E";
        }
        
    }
}

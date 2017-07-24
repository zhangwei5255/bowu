using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Win.YMK.Controls.Emails
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class MailSenderImpl : MailSender
    {
        private const string PROPS_HOST = "mail.host";
        private const string PROPS_SMTP = "mail.smtp.host";
        private const string PROPS_SMTP_PORT = "mail.smtp.port";
        private const string PROPS_CONNECT_TIMEOUT = "mail.smtp.connectiontimeout";
        private const string PROPS_TIMEOUT = "mail.smtp.timeout";
        private const string PROPS_DEBUG = "mail.debug";
        private const string PROPS_SMTP_AUTH = "mail.smtp.auth";
        private const string CODE_RETURN = "\r\n";
        private const string ENCODE_TYPE = "iso-2022-jp";
        private static readonly string BODY_TEXT_TYPE = "text/plain; charset=\"{%0}\"";
        private const string MAIL_ENCODE = "B";
        private MailInformation mailInfo = null;

        public MailSenderImpl()
        {
            this.mailInfo = new MailInformation();
        }


        #region MailSender メンバ

        public string MailEncoding
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void clearToAddress()
        {
            throw new NotImplementedException();
        }

        public string ToAddress
        {
            set { throw new NotImplementedException(); }
        }

        public IList<string> ToAddressList
        {
            set { throw new NotImplementedException(); }
        }

        public void clearCcAddress()
        {
            throw new NotImplementedException();
        }

        public string CcAddress
        {
            set { throw new NotImplementedException(); }
        }

        public IList<string> CcAddressList
        {
            set { throw new NotImplementedException(); }
        }

        public void clearBccAddress()
        {
            throw new NotImplementedException();
        }

        public string BccAddress
        {
            set { throw new NotImplementedException(); }
        }

        public IList<string> BccAddressList
        {
            set { throw new NotImplementedException(); }
        }

        public string FromAddress
        {
            set { throw new NotImplementedException(); }
        }

        public void setFromAddress(string paramString1, string paramString2)
        {
            throw new NotImplementedException();
        }

        public string SmtpHost
        {
            set { throw new NotImplementedException(); }
        }

        public int SmtpPort
        {
            set { throw new NotImplementedException(); }
        }

        public string SmtpUser
        {
            set { throw new NotImplementedException(); }
        }

        public string SmtpPassword
        {
            set { throw new NotImplementedException(); }
        }

        public string Subject
        {
            set { throw new NotImplementedException(); }
        }

        public string Message
        {
            set { throw new NotImplementedException(); }
        }

        public string MessageHeader
        {
            set { throw new NotImplementedException(); }
        }

        public string MessageFooter
        {
            set { throw new NotImplementedException(); }
        }

        public string AttachFile
        {
            set { throw new NotImplementedException(); }
        }

        public IList<string> AttachFileList
        {
            set { throw new NotImplementedException(); }
        }

        public int ConnectTimeOut
        {
            set { throw new NotImplementedException(); }
        }

        public int SendTimeOut
        {
            set { throw new NotImplementedException(); }
        }

        public bool DebugMode
        {
            set { throw new NotImplementedException(); }
        }

        public void send()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}



//javaクラスをご参照ください。
//import java.io.File;
//import java.io.UnsupportedEncodingException;
//import java.util.Date;
//import java.util.Iterator;
//import java.util.List;
//import java.util.Properties;
//import java.util.Vector;
//import javax.activation.DataHandler;
//import javax.activation.FileDataSource;
//import javax.mail.Address;
//import javax.mail.Message.RecipientType;
//import javax.mail.MessagingException;
//import javax.mail.Session;
//import javax.mail.Transport;
//import javax.mail.internet.AddressException;
//import javax.mail.internet.InternetAddress;
//import javax.mail.internet.MimeBodyPart;
//import javax.mail.internet.MimeMessage;
//import javax.mail.internet.MimeMultipart;
//import javax.mail.internet.MimeUtility;

//public class MailSenderImpl
//  implements MailSender
//{
//  private static final String PROPS_HOST = "mail.host";
//  private static final String PROPS_SMTP = "mail.smtp.host";
//  private static final String PROPS_SMTP_PORT = "mail.smtp.port";
//  private static final String PROPS_CONNECT_TIMEOUT = "mail.smtp.connectiontimeout";
//  private static final String PROPS_TIMEOUT = "mail.smtp.timeout";
//  private static final String PROPS_DEBUG = "mail.debug";
//  private static final String PROPS_SMTP_AUTH = "mail.smtp.auth";
//  private static final String CODE_RETURN = "\r\n";
//  private static final String ENCODE_TYPE = "iso-2022-jp";
//  private static final String BODY_TEXT_TYPE = "text/plain; charset=\"{%0}\"";
//  private static final String MAIL_ENCODE = "B";
//  private MailInformation mailInfo = null;
  
//  public MailSenderImpl()
//  {
//    this.mailInfo = new MailInformation();
//  }
  
//  public MailSenderImpl(String fileName)
//  {
//    MailXmlParser parser = new MailXmlParser();
//    this.mailInfo = parser.getDefinition(fileName);
//  }
  
//  public String getMailEncoding()
//  {
//    return this.mailInfo.getMailEncoding();
//  }
  
//  public void setMailEncoding(String mailEncoding)
//    throws MailException
//  {
//    checkParameterEssential(mailEncoding, "メールエンコード");
//    this.mailInfo.setMailEncoding(mailEncoding);
//  }
  
//  public void clearToAddress()
//  {
//    this.mailInfo.setToAddressList(new Vector());
//  }
  
//  public void setToAddress(String toAddress)
//    throws MailException
//  {
//    checkParameterEssential(toAddress, "送信先アドレス");
    
//    this.mailInfo.addToAddress(toAddress);
//  }
  
//  public void setToAddressList(List<String> toAddressList)
//    throws MailException
//  {
//    checkParameter(toAddressList, "送信先アドレスList");
    
//    String toAddress = null;
    
//    Iterator<String> toAddressListIt = toAddressList.iterator();
//    while (toAddressListIt.hasNext())
//    {
//      toAddress = (String)toAddressListIt.next();
//      if (!StringAttributeCheck.isNullOrEmpty(toAddress)) {
//        this.mailInfo.addToAddress(toAddress);
//      }
//    }
//  }
  
//  public void clearCcAddress()
//  {
//    this.mailInfo.setCcAddressList(new Vector());
//  }
  
//  public void setCcAddress(String ccAddress)
//    throws MailException
//  {
//    checkParameterEssential(ccAddress, "CCアドレス");
//    this.mailInfo.addCcAddress(ccAddress);
//  }
  
//  public void setCcAddressList(List<String> ccAddressList)
//    throws MailException
//  {
//    checkParameter(ccAddressList, "CCアドレスList");
    
//    String ccAddress = null;
    
//    Iterator<String> ccAddressListIt = ccAddressList.iterator();
//    while (ccAddressListIt.hasNext())
//    {
//      ccAddress = (String)ccAddressListIt.next();
//      if (!StringAttributeCheck.isNullOrEmpty(ccAddress)) {
//        this.mailInfo.addCcAddress(ccAddress);
//      }
//    }
//  }
  
//  public void clearBccAddress()
//  {
//    this.mailInfo.setBccAddressList(new Vector());
//  }
  
//  public void setBccAddress(String bccAddress)
//    throws MailException
//  {
//    checkParameterEssential(bccAddress, "BCCアドレス");
//    this.mailInfo.addBccAddress(bccAddress);
//  }
  
//  public void setBccAddressList(List<String> bccAddressList)
//    throws MailException
//  {
//    checkParameter(bccAddressList, "BCCアドレスList");
    
//    String bccAddress = null;
    
//    Iterator<String> bccAddressListIt = bccAddressList.iterator();
//    while (bccAddressListIt.hasNext())
//    {
//      bccAddress = (String)bccAddressListIt.next();
//      if (!StringAttributeCheck.isNullOrEmpty(bccAddress)) {
//        this.mailInfo.addBccAddress(bccAddress);
//      }
//    }
//  }
  
//  public void setFromAddress(String fromAddress)
//    throws MailException
//  {
//    checkParameterEssential(fromAddress, "送信元アドレス");
    
//    this.mailInfo.setFromAddress(fromAddress);
//    this.mailInfo.setFromName(null);
//  }
  
//  public void setFromAddress(String fromAddress, String fromName)
//    throws MailException
//  {
//    checkParameterEssential(fromAddress, "送信元アドレス");
//    checkParameterEssential(fromName, "送信元名称");
    

//    String encodeFromName = changeUniToJis(fromName);
    
//    this.mailInfo.setFromAddress(fromAddress);
//    this.mailInfo.setFromName(encodeFromName);
//  }
  
//  public void setSmtpHost(String smtpHost)
//    throws MailException
//  {
//    checkParameterEssential(smtpHost, "SMTPサーバ");
    
//    this.mailInfo.setSmtpHost(smtpHost);
//  }
  
//  public void setSmtpPort(int smtpPort)
//  {
//    this.mailInfo.setSmtpPort(smtpPort);
//  }
  
//  public void setSmtpUser(String smtpUser)
//    throws MailException
//  {
//    this.mailInfo.setSmtpUser(smtpUser);
//  }
  
//  public void setSmtpPassword(String smtpPassword)
//    throws MailException
//  {
//    this.mailInfo.setSmtpPassword(smtpPassword);
//  }
  
//  public void setSubject(String subject)
//    throws MailException
//  {
//    checkParameter(subject, "メールタイトル");
    

//    String encodeSubject = changeUniToJis(subject);
    
//    this.mailInfo.setSubject(encodeSubject);
//  }
  
//  public void setMessage(String message)
//    throws MailException
//  {
//    checkParameter(message, "メール本文");
    

//    String encodeMessage = changeUniToJis(message);
    
//    this.mailInfo.setMessage(encodeMessage);
//  }
  
//  public void setMessageHeader(String messageHeader)
//    throws MailException
//  {
//    checkParameter(messageHeader, "メール本文ヘッダ");
    

//    String encodeMessageHeader = changeUniToJis(messageHeader);
    
//    this.mailInfo.setMessageHeader(encodeMessageHeader);
//  }
  
//  public void setMessageFooter(String messageFooter)
//    throws MailException
//  {
//    checkParameter(messageFooter, "メール本文フッタ");
    

//    String encodeMessageFooter = changeUniToJis(messageFooter);
    
//    this.mailInfo.setMessageFooter(encodeMessageFooter);
//  }
  
//  public void setAttachFile(String attachFile)
//    throws MailException
//  {
//    checkParameterEssential(attachFile, "添付ファイルパス");
    
//    File attach = new File(attachFile);
//    if (!attach.exists()) {
//      throw new MailException(this, "CMN-1502E", attachFile);
//    }
//    this.mailInfo.addAttachFiles(attachFile);
//  }
  
//  public void setAttachFileList(List<String> attachFileList)
//    throws MailException
//  {
//    checkParameter(attachFileList, "添付ファイルパスList");
    
//    String attachFile = null;
    
//    Iterator<String> attachFileListIt = attachFileList.iterator();
//    while (attachFileListIt.hasNext())
//    {
//      attachFile = (String)attachFileListIt.next();
//      if (attachFile == null) {
//        throw new MailException(this, "CMN-1502E", String.valueOf(attachFile));
//      }
//      if (new File(attachFile).exists()) {
//        this.mailInfo.addAttachFiles(new File(attachFile).toString());
//      } else {
//        throw new MailException(this, "CMN-1502E", attachFile);
//      }
//    }
//  }
  
//  public void setConnectTimeOut(int connectTimeOut)
//  {
//    this.mailInfo.setConTimeOut(connectTimeOut);
//  }
  
//  public void setSendTimeOut(int sendTimeOut)
//  {
//    this.mailInfo.setSendTimeOut(sendTimeOut);
//  }
  
//  public void setDebugMode(boolean debugMode)
//  {
//    this.mailInfo.setDebugMode(debugMode);
//  }
  
//  public void send()
//    throws MailException
//  {
//    checkSendDefinition();
    
//    Transport transport = null;
//    try
//    {
//      Properties props = new Properties();
      

//      props.put("mail.host", this.mailInfo.getSmtpHost());
//      props.put("mail.smtp.host", this.mailInfo.getSmtpHost());
//      props.put("mail.smtp.port", String.valueOf(this.mailInfo.getSmtpPort()));
//      props.put("mail.smtp.connectiontimeout", String.valueOf(this.mailInfo.getConTimeOut()));
//      props.put("mail.smtp.timeout", String.valueOf(this.mailInfo.getSendTimeOut()));
//      props.put("mail.debug", String.valueOf(this.mailInfo.isDebugMode()));
      
//      String enc = this.mailInfo.getMailEncoding();
//      if ((enc == null) || ("".equals(enc))) {
//        enc = "iso-2022-jp";
//      }
//      boolean isAuth = false;
//      if ((this.mailInfo.getSmtpUser() != null) && (this.mailInfo.getSmtpPassword() != null)) {
//        isAuth = true;
//      }
//      props.put("mail.smtp.auth", String.valueOf(isAuth));
      

//      Session session = Session.getInstance(props, null);
      
//      MimeMessage mime = new MimeMessage(session);
//      try
//      {
//        mime.setSubject(MimeUtility.encodeText(this.mailInfo.getSubject(), enc, "B"));
//      }
//      catch (UnsupportedEncodingException uee)
//      {
//        List<String> msgTokens = new Vector();
//        msgTokens.add("メールタイトル");
//        msgTokens.add(this.mailInfo.getSubject());
//        throw new MailException(this, "CMN-1506E", msgTokens);
//      }
//      mime.setRecipients(Message.RecipientType.TO, createInternetAddress(this.mailInfo.getToAddressList(), enc));
      
//      mime.setRecipients(Message.RecipientType.CC, createInternetAddress(this.mailInfo.getCcAddressList(), enc));
      
//      mime.setRecipients(Message.RecipientType.BCC, createInternetAddress(this.mailInfo.getBccAddressList(), enc));
      

//      mime.setFrom(createInternetAddress(this.mailInfo.getFromAddress(), this.mailInfo.getFromName(), enc));
      

//      mime.setSentDate(new Date());
      

//      this.mailInfo.setMessage(createMessage(this.mailInfo.getMessage(), this.mailInfo.getMessageHeader(), this.mailInfo.getMessageFooter()));
//      if (this.mailInfo.getAttachFileList().size() > 0)
//      {
//        DataHandler dataHandler = null;
//        MimeMultipart content = new MimeMultipart();
        
//        mime.setContent(content);
        
//        MimeBodyPart textPart = new MimeBodyPart();
//        MimeBodyPart attachPart = null;
        
//        textPart.setContent(this.mailInfo.getMessage(), "text/plain; charset=\"{%0}\"".replace("{%0}", enc));
//        content.addBodyPart(textPart);
        

//        String attachFile = null;
//        String fileName = null;
//        Iterator<String> fileListIt = this.mailInfo.getAttachFileList().iterator();
//        while (fileListIt.hasNext())
//        {
//          attachFile = (String)fileListIt.next();
          
//          attachPart = new MimeBodyPart();
//          dataHandler = new DataHandler(new FileDataSource(attachFile));
          

//          attachPart.setDataHandler(dataHandler);
//          fileName = changeUniToJis(new File(attachFile).getName());
//          try
//          {
//            attachPart.setFileName(MimeUtility.encodeWord(fileName, enc, "B"));
//          }
//          catch (UnsupportedEncodingException e)
//          {
//            throw new MailException(this, "CMN-1506E", "添付ファイル名");
//          }
//          content.addBodyPart(attachPart);
//        }
//        mime.setContent(content);
//      }
//      else
//      {
//        mime.setContent(this.mailInfo.getMessage(), "text/plain; charset=\"{%0}\"".replace("{%0}", enc));
//      }
//      ComponentLogger.info(this, this.mailInfo.toString());
      
//      Address[] fromArray = mime.getFrom();
//      if (fromArray != null) {
//        for (int i = 0; i < fromArray.length; i++) {
//          ComponentLogger.info(this, "[FROM-ADDRESS-TYPE]：" + fromArray[i].getType() + " [FROM-ADDRESS]" + fromArray[i]);
//        }
//      }
//      Address[] toArray = mime.getAllRecipients();
//      if (toArray != null) {
//        for (int i = 0; i < toArray.length; i++) {
//          ComponentLogger.info(this, "[TO-ADDRESS-TYPE]：" + toArray[i].getType() + " [TO-ADDRESS]" + toArray[i]);
//        }
//      }
//      if (!isAuth)
//      {
//        Transport.send(mime);
//      }
//      else
//      {
//        transport = session.getTransport("smtp");
//        transport.connect(null, this.mailInfo.getSmtpUser(), this.mailInfo.getSmtpPassword());
//        transport.sendMessage(mime, mime.getAllRecipients());
//      }
//      return;
//    }
//    catch (MessagingException me)
//    {
//      throw new MailException(this, "CMN-1508E", me.toString(), me);
//    }
//    finally
//    {
//      if ((transport != null) && (transport.isConnected())) {
//        try
//        {
//          transport.close();
//        }
//        catch (MessagingException me)
//        {
//          throw new MailException(this, "CMN-1508E", me.toString(), me);
//        }
//      }
//    }
//  }
  
//  protected static String changeUniToJis(String sentence)
//  {
//    sentence = NullEmptyConvert.nullToEmpty(sentence);
    
//    StringBuffer buffer = new StringBuffer();
//    for (int i = 0; i < sentence.length(); i++)
//    {
//      char character = sentence.charAt(i);
//      switch (character)
//      {
//      case '～': 
//        character = '〜';
//        break;
//      case '∥': 
//        character = '‖';
//        break;
//      case '－': 
//        character = '−';
//        break;
//      case '―': 
//        character = '—';
//        break;
//      case '￠': 
//        character = '¢';
//        break;
//      case '￡': 
//        character = '£';
//        break;
//      case '￢': 
//        character = '¬';
//        break;
//      }
//      buffer.append(character);
//    }
//    return buffer.toString();
//  }
  
//  private String createMessage(String message, String header, String footer)
//  {
//    if (message == null) {
//      message = "";
//    }
//    if ((header != null) && (!"".equals(header))) {
//      message = header + "\r\n" + message;
//    }
//    if ((footer != null) && (!"".equals(footer))) {
//      message = message + "\r\n" + footer;
//    }
//    message = message + "\r\n";
    

//    String frontMessage = null;
//    String backMessage = null;
//    for (int i = 1; i < message.length(); i++) {
//      if ((message.charAt(i) == '\n') && (message.charAt(i - 1) != '\r'))
//      {
//        frontMessage = message.substring(0, i);
//        backMessage = message.substring(i);
//        backMessage = backMessage.replaceFirst("\n", "\r\n");
//        message = frontMessage + backMessage;
//      }
//    }
//    return message;
//  }
  
//  private InternetAddress[] createInternetAddress(List<String> addressList, String encode)
//    throws MailException
//  {
//    InternetAddress[] ieAddress = new InternetAddress[addressList.size()];
//    for (int i = 0; i < addressList.size(); i++) {
//      ieAddress[i] = createInternetAddress((String)addressList.get(i), (String)addressList.get(i), encode);
//    }
//    return ieAddress;
//  }
  
//  private InternetAddress createInternetAddress(String address, String personal, String encode)
//    throws MailException
//  {
//    InternetAddress ieAddress = null;
//    try
//    {
//      ieAddress = new InternetAddress(address, true);
//    }
//    catch (AddressException ae)
//    {
//      throw new MailException(this, "CMN-1505E", address);
//    }
//    if (personal != null) {
//      try
//      {
//        ieAddress = new InternetAddress(address, MimeUtility.encodeWord(personal, encode, "B"));
//      }
//      catch (UnsupportedEncodingException uee)
//      {
//        List<String> msgTokens = new Vector();
//        msgTokens.add(address);
//        msgTokens.add(personal);
//        throw new MailException(this, "CMN-1507E", msgTokens);
//      }
//    }
//    return ieAddress;
//  }
  
//  private void checkSendDefinition()
//    throws MailException
//  {
//    boolean isToAddressSet = containsEntry(this.mailInfo.getToAddressList());
//    boolean isCcAddressSet = containsEntry(this.mailInfo.getCcAddressList());
//    boolean isBccAddressSet = containsEntry(this.mailInfo.getBccAddressList());
//    if ((!isToAddressSet) && (!isCcAddressSet) && (!isBccAddressSet)) {
//      checkParameter(null, "送信先アドレス");
//    }
//    checkParameterEssential(this.mailInfo.getFromAddress(), "送信元アドレス");
//    checkParameterEssential(this.mailInfo.getSmtpHost(), "SMTPサーバ");
//    checkParameterEssential(this.mailInfo.getSubject(), "メールタイトル");
    

//    checkAddress(this.mailInfo.getToAddressList(), "TOアドレス");
//    checkAddress(this.mailInfo.getCcAddressList(), "CCアドレス");
//    checkAddress(this.mailInfo.getBccAddressList(), "BCCアドレス");
//    try
//    {
//      if ((!StringAttributeCheck.checkHalfChar(this.mailInfo.getFromAddress())) || (StringAttributeCheck.checkHalfKanaInclude(this.mailInfo.getFromAddress()) == true)) {
//        throw new MailException(this, "CMN-1505E", this.mailInfo.getFromAddress());
//      }
//    }
//    catch (StringException se)
//    {
//      throw new MailException(this, "CMN-1505E", this.mailInfo.getFromAddress());
//    }
//  }
  
//  private boolean containsEntry(List<?> list)
//  {
//    if ((StringAttributeCheck.isNull(list)) || (list.size() == 0)) {
//      return false;
//    }
//    return true;
//  }
  
//  private void checkAddress(List<String> addresses, String name)
//    throws MailException
//  {
//    String address = null;
//    Iterator<String> addressIt = addresses.iterator();
//    while (addressIt.hasNext()) {
//      try
//      {
//        address = (String)addressIt.next();
        
//        checkParameterEssential(address, name);
//        if ((!StringAttributeCheck.checkHalfChar(address)) || (StringAttributeCheck.checkHalfKanaInclude(address) == true)) {
//          throw new MailException(this, "CMN-1505E", address);
//        }
//      }
//      catch (StringException se)
//      {
//        throw new MailException(this, "CMN-1505E", address);
//      }
//    }
//  }
  
//  private void checkParameterEssential(String parameter, String parameterName)
//    throws MailException
//  {
//    if (StringAttributeCheck.isNullOrEmpty(parameter)) {
//      throw new MailException(this, "CMN-1501E", parameterName);
//    }
//  }
  
//  private void checkParameter(Object parameter, String parameterName)
//    throws MailException
//  {
//    if (StringAttributeCheck.isNull(parameter)) {
//      throw new MailException(this, "CMN-1501E", parameterName);
//    }
//    if (((parameter instanceof List)) && 
//      (((List)parameter).size() == 0)) {
//      throw new MailException(this, "CMN-1501E", parameterName);
//    }
//  }
//}

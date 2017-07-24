using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win.YMK.Controls.Emails
{

	public  interface MailSender
	{
	  string MailEncoding {get;set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setMailEncoding(String paramString) throws MailException;

	  void clearToAddress();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setToAddress(String paramString) throws MailException;
	  string ToAddress {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setToAddressList(java.util.List<String> paramList) throws MailException;
	  IList<string> ToAddressList {set;}

	  void clearCcAddress();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setCcAddress(String paramString) throws MailException;
	  string CcAddress {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setCcAddressList(java.util.List<String> paramList) throws MailException;
	  IList<string> CcAddressList {set;}

	  void clearBccAddress();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setBccAddress(String paramString) throws MailException;
	  string BccAddress {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setBccAddressList(java.util.List<String> paramList) throws MailException;
	  IList<string> BccAddressList {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setFromAddress(String paramString) throws MailException;
	  string FromAddress {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setFromAddress(String paramString1, String paramString2) throws MailException;
	  void setFromAddress(string paramString1, string paramString2);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setSmtpHost(String paramString) throws MailException;
	  string SmtpHost {set;}

	  int SmtpPort {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setSmtpUser(String paramString) throws MailException;
	  string SmtpUser {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setSmtpPassword(String paramString) throws MailException;
	  string SmtpPassword {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setSubject(String paramString) throws MailException;
	  string Subject {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setMessage(String paramString) throws MailException;
	  string Message {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setMessageHeader(String paramString) throws MailException;
	  string MessageHeader {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setMessageFooter(String paramString) throws MailException;
	  string MessageFooter {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setAttachFile(String paramString) throws MailException;
	  string AttachFile {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void setAttachFileList(java.util.List<String> paramList) throws MailException;
	  IList<string> AttachFileList {set;}

	  int ConnectTimeOut {set;}

	  int SendTimeOut {set;}

	  bool DebugMode {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public abstract void send() throws MailException;
	  void send();
	}
}

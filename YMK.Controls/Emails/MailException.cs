using System;
using System.Collections.Generic;

namespace Win.YMK.Controls.Emails
{



	public class MailException : ComponentException
	{
	  private const long serialVersionUID = 1L;

	  public MailException(object obj, string msgId, string msgToken) : base(obj, MailMessenger.Instance, msgId, msgToken)
	  {
	  }

	  public MailException(object obj, string msgId, IList<string> msgTokens) : base(obj, MailMessenger.Instance, msgId, msgTokens)
	  {
	  }

	  public MailException(object obj, string msgId, string msgToken, Exception cause) : base(obj, MailMessenger.Instance, msgId, msgToken, cause)
	  {
	  }
	}
}
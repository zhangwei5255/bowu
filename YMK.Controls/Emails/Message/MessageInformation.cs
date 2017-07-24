using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Win.YMK.Controls.Emails.Message
{


	public class MessageInformation
	{
	  private string msgId;
	  private string msgCategory;
	  private string msgLang;
	  private IList<string> msgTokens;

	  public virtual string MsgId
	  {
		  get
		  {
			return this.msgId;
		  }
		  set
		  {
			this.msgId = value;
		  }
	  }


	  public virtual string MsgCategory
	  {
		  get
		  {
			return this.msgCategory;
		  }
		  set
		  {
			this.msgCategory = value;
		  }
	  }


	  public virtual string MsgLang
	  {
		  get
		  {
			return this.msgLang;
		  }
		  set
		  {
			this.msgLang = value;
		  }
	  }


	  public virtual IList<string> MsgTokens
	  {
		  get
		  {
			return this.msgTokens;
		  }
		  set
		  {
			this.msgTokens = value;
		  }
	  }


	  public virtual void addMsgToken(string msgToken)
	  {
		if (this.msgTokens == null)
		{
		  this.msgTokens = new List<string>();
		}
		this.msgTokens.Add(msgToken);
	  }

	  public override string ToString()
	  {
		StringBuilder result = new StringBuilder(this.msgId);
		if (this.msgCategory != null)
		{
		  result.Append(this.msgCategory);
		}
		if (this.msgLang != null)
		{
		  result.Append(this.msgLang);
		}
		return result.ToString();
	  }
	}
}

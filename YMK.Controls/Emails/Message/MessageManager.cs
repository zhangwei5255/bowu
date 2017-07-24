using System.Collections.Generic;

namespace Win.YMK.Controls.Emails.Message
{

	public interface MessageManager
	{
	  string getMessage(MessageInformation paramMessageInformation);

	  string getMessage(string paramString);

	  string getMessage(string paramString1, string paramString2);

	  string getMessage(string paramString, IList<string> paramList);

	  string getMessage(string paramString1, string paramString2, string paramString3);

	  string getMessage(string paramString1, string paramString2, string paramString3, string paramString4);

	  string getMessage(string paramString1, string paramString2, string paramString3, IList<string> paramList);

	  string getMessageWithoutId(MessageInformation paramMessageInformation);

	  string getMessageWithoutId(string paramString);

	  string getMessageWithoutId(string paramString1, string paramString2);

	  string getMessageWithoutId(string paramString, IList<string> paramList);

	  string getMessageWithoutId(string paramString1, string paramString2, string paramString3);

	  string getMessageWithoutId(string paramString1, string paramString2, string paramString3, string paramString4);

	  string getMessageWithoutId(string paramString1, string paramString2, string paramString3, IList<string> paramList);
	}
}
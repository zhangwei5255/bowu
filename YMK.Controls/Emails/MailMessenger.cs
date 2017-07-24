

using Win.YMK.Controls.Emails.Message;
namespace Win.YMK.Controls.Emails
{

    public class MailMessenger : CacheMessageManager
    {
        public const string CMN_1501E = "CMN-1501E";
        public const string CMN_1502E = "CMN-1502E";
        public const string CMN_1503W = "CMN-1503W";
        public const string CMN_1504E = "CMN-1504E";
        public const string CMN_1505E = "CMN-1505E";
        public const string CMN_1506E = "CMN-1506E";
        public const string CMN_1507E = "CMN-1507E";
        public const string CMN_1508E = "CMN-1508E";

        static MailMessenger()
        {
            addMessage("CMN-1501E", "[%0]を設定してください。");
            addMessage("CMN-1502E", "添付ファイルが存在しません。ファイル[%0]");
            addMessage("CMN-1503W", "指定されたメール送信テンプレートXMLがクラスパスに設定されていません。ファイル[%0]");
            addMessage("CMN-1504E", "メール送信テンプレートXMLのパース時にエラーが発生しました。内容：%0");
            addMessage("CMN-1505E", "アドレスの設定が不正です。アドレス[%0]");
            addMessage("CMN-1506E", "文字のエンコードがサポートされていません。%0[%1]");
            addMessage("CMN-1507E", "文字のエンコードがサポートされていません。アドレス[%0] 名称[%1]");
            addMessage("CMN-1508E", "送信メール作成時にエラーが発生しました。内容：%0");
        }

        private static MailMessenger messenger = null;

        public static MailMessenger Instance
        {
            get
            {
                if (messenger == null)
                {
                    messenger = new MailMessenger();
                }
                return messenger;
            }
        }
    }
}

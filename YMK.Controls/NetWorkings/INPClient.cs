using System;
using System.IO;
using Win.YMK.NetWorkings.Base;

namespace Win.YMK.NetWorkings
{
    /// <summary>
    /// Summary description for INPClient.
    /// </summary>
    public class INPClient : ClientBase
    {
        public INPClient(string serverIP, int port)
            : base(serverIP, port)
        {
        }

        public void SendFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            string filesize = fs.Length.ToString().PadLeft(FILESIZE, '0');
            int startindex = fileName.LastIndexOf('\\') + 1;
            byte[] b1 = System.Text.Encoding.Default.GetBytes(fileName.Substring(startindex, FILENAMELENGTH));//文件名（15）
            byte[] b2 = System.Text.Encoding.Default.GetBytes(filesize);//文件大小（10）

            byte[] b3 = new byte[fs.Length];//文件内容
            fs.Read(b3, 0, b3.Length);

            byte[] im = new byte[b1.Length + b2.Length + b3.Length];

            Array.Copy(b1, 0, im, 0, b1.Length);
            Array.Copy(b2, 0, im, b1.Length, b2.Length);
            Array.Copy(b3, 0, im, b1.Length + b2.Length, b3.Length);

            base.Send(im);

            fs.Close();
        }

        public void SendString(String src)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        Uri initUri;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //// Uri の設定 
            //initUri = new Uri("https://www.google.co.jp/");
            //// ナビゲート 
            //this.wb.Navigate(initUri);


            String hqStr = GetWebContent("http://hq.sinajs.cn/list=s_sh000001");
            String[] arr = hqStr.Split(',');
            String sh = arr[1];
            


        }


        /// <summary> 获取远程HTML内容</summary>   
        /// <param name="url">远程网页地址URL</param>   
        /// <returns>成功返回远程HTML的代码内容</returns>   
        private string GetWebContent(string url)  
        {  
            using (WebClient client = new WebClient())  
            {

                //プロキシの設定
              //  client.Proxy = new System.Net.WebProxy("http://localhost:8080");

                System.Net.WebProxy proxy =
    new System.Net.WebProxy("http://iproxy04.intra.hitachi.co.jp:8080");
                //ユーザー名とパスワードを設定 
                proxy.Credentials = new System.Net.NetworkCredential("70310832", "zw5255%&'");
                client.Proxy = proxy;


                byte[] buffer = client.DownloadData(url);  
                string str = Encoding.GetEncoding("GB2312").GetString(buffer, 0, buffer.Length);  
                return str;  
            }  
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String hq_str = GetWebContent("http://hq.sinajs.cn/list=s_sh000001");
        }  

    }
}

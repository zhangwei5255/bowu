using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Win.YMK.Controls.WebBrowsers;
using YMK.Commons.Messages;

namespace bowu
{
    public partial class FrmBowu : Form
    {
        Uri initUri;
        Uri initUri2;

        //メッセージ
        private Msg msg;
        DateTime PreDateTime;

        System.Net.WebProxy proxy = null;
        WebClient client = new WebClient();
        private  const string SINA_GB_URL = @"http://hq.sinajs.cn/list={0}";

        public FrmBowu()
        {
            InitializeComponent();

            //メッセージのインストール
            msg = Msg.GetInstance();

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SinaBean bean = GetWebContent(ConfigurationManager.AppSettings["SH_CD"]);
                string percent = convertPercent(bean.Percent);
                lblSh1.Text = bean.Price + "+" + bean.Turnover + percent;
                double dblMax = double.Parse(txtShMax.Value);
                double dblMin = double.Parse(txtShMin.Value);
                double dblPrice = double.Parse(bean.Price);

                if (dblPrice >= dblMax || dblPrice <= dblMin)
                {
                    this.Activate();
                    this.BringToFront();
                    this.Focus();

                    if (bean.Price.CompareTo(txtShMax.Value + ".000") >= 0)
                    {
                        timer1.Stop();
                        msg.Information("↑" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer1.Start();
                    }
                    else
                    {
                        timer1.Stop();
                        msg.Information("↓" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer1.Start();
                    }
                }
            }
            catch
            {

            }
          
           
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                SinaBean bean = GetWebContent(ConfigurationManager.AppSettings["SZ_CD"]);
                string percent = convertPercent(bean.Percent);
                lblSz1.Text = bean.Price + "+" + bean.Turnover + percent;

                double dblMax = double.Parse(txtSZMax.Value);
                double dblMin = double.Parse(txtSZMin.Value);
                double dblPrice = double.Parse(bean.Price);

                if (dblPrice >= dblMax || dblPrice <= dblMin)
                {
                    this.Activate();
                    this.BringToFront();
                    this.Focus();

                    if (bean.Price.CompareTo(txtSZMax.Value + ".000") >= 0)
                    {
                        timer2.Stop();
                        msg.Information("↑" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer2.Start();
                    }
                    else
                    {
                        timer2.Stop();
                        msg.Information("↓" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer2.Start();
                    }

                }

            }
            catch
            {

            }
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                SinaBean bean = GetWebContent(ConfigurationManager.AppSettings["LT_CD"]);
                string percent = convertPercent(bean.Percent);
                lblLt1.Text = bean.Price + "+" + bean.Turnover + percent;
                double dblMax = double.Parse(txtLtMax.Value);
                double dblMin = double.Parse(txtLtMin.Value);
                double dblPrice = double.Parse(bean.Price);


                if (dblPrice >= dblMax || dblPrice <= dblMin)
                {
                    this.Activate();
                    this.BringToFront();
                    this.Focus();

                    if (dblPrice >= dblMax)
                    {
                        timer3.Stop();
                        msg.Information("↑" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer3.Start();
                    }
                    else
                    {
                        timer3.Stop();
                        msg.Information("↓" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer3.Start();
                    }

                }
            }
            catch
            {

            }
       
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                SinaBean bean = GetWebContent(ConfigurationManager.AppSettings["COM_CD4"]);
                string percent = convertPercent(bean.Percent);
                lbl4.Text = bean.Price + "+" + bean.Turnover + percent;
                double dblMax = double.Parse(txtMax4.Value);
                double dblMin = double.Parse(txtMin4.Value);
                double dblPrice = double.Parse(bean.Price);


                if (dblPrice >= dblMax || dblPrice <= dblMin)
                {
                    this.Activate();
                    this.BringToFront();
                    this.Focus();

                    if (dblPrice >= dblMax)
                    {
                        timer4.Stop();
                        msg.Information("↑" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer4.Start();
                    }
                    else
                    {
                        timer4.Stop();
                        msg.Information("↓" + bean.Price + label1.Text + bean.Turnover + percent);
                        timer4.Start();
                    }

                }
            }
            catch
            {

            }
        }


        private string convertPercent(string percent)
        {
            if (percent.StartsWith("-"))
            {
                return percent;
            }
            else
            {
                return "+" + percent;
            }
        }
 
        private SinaBean GetWebContent(string cd)
        {
            SinaBean bean = new SinaBean();
            string url = String.Format(SINA_GB_URL, cd);
            byte[] buffer = client.DownloadData(url);
            string hqStr = Encoding.GetEncoding("GB2312").GetString(buffer, 0, buffer.Length);
            String[] arr = hqStr.Split(',');
            bean.Name = arr[0];
            bean.Price = arr[1];
            bean.Offset = arr[2];
            bean.Percent = arr[3];
            bean.Turnover = Int32.Parse(arr[5].Substring(0,arr[5].Length - 3)) / 10000;
            return bean; 
        }



        private void FrmBowu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            label1.Text = ConfigurationManager.AppSettings["HYOJI_MOJI"];


            //プロキシの設定
            if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["PROXY_URL"]) == false)
            {
                proxy = new System.Net.WebProxy(ConfigurationManager.AppSettings["PROXY_URL"]);
                //ユーザー名とパスワードを設定 
                proxy.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["PROXY_USER_ID"], ConfigurationManager.AppSettings["PROXY_PASSWORD"]);

                client.Proxy = proxy;
            }
             


            //wb.ScriptErrorsSuppressed = false;
            //wb2.ScriptErrorsSuppressed = false;


            PreDateTime = DateTime.Now;
            String strSintyokuFlg = ConfigurationManager.AppSettings["SINTYOKU_FLG"];
            if ("true".Equals(strSintyokuFlg))
            {
                // Uri の設定 
                initUri = new Uri(ConfigurationManager.AppSettings["BOWU_URL"]);
                // ナビゲート 
                this.wb.Navigate(initUri);
            }
           
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            LblStk.Text = "進捗：100%";
            WebBrowser2 wbObj = sender as WebBrowser2;
            HtmlDocument _document = wbObj.Document;
            String strDate = null;
            String strUrl = null;
            DateTime lastUpd;


     //       wbObj.Document.Window.Error +=
     //new HtmlElementErrorEventHandler(Window_Error);

            HtmlElementCollection divs = _document.Body.GetElementsByTagName("div");
            
            foreach (HtmlElement em in divs)
            {
                if (em.GetAttribute("className") == "list" && em.GetAttribute("id") != "blogtypelist")
                {
                    HtmlElementCollection lis = em.GetElementsByTagName("li");

                    HtmlElementCollection spans = lis[0].GetElementsByTagName("span");
                    strDate = spans[0].InnerText.Replace("(","").Replace(")","");

                    HtmlElementCollection links = lis[0].GetElementsByTagName("a");
                    strUrl = links[0].GetAttribute("href");
                    break;
                    
                }
            }

            if (strDate != null)
            {
                lastUpd = DateTime.Parse(strDate).AddSeconds(59);                                                          //中国時間
                lastUpd = lastUpd.AddHours(Int32.Parse(ConfigurationManager.AppSettings["JISA"]));　　　//日本時間

                if (PreDateTime.CompareTo(lastUpd) <= 0)
                {
                    wb2.Navigate(strUrl);

                    this.Activate();
                    this.BringToFront();
                    this.Focus();

                    //this.WindowState = FormWindowState.Maximized;

                    PreDateTime = DateTime.Now.AddMinutes(1);
                    progressBar1.Value = 100;
                    LblStk.Text = @"進捗：100%";
                    msg.Information(strDate + label1.Text);
                    //this.WindowState = FormWindowState.Minimized;

                    TimerCallback timerDelegate = new TimerCallback(reload);
                    System.Threading.Timer timer = new System.Threading.Timer(timerDelegate);
                    timer.Change(1000, 0);
                }
                else
                {
                    TimerCallback timerDelegate = new TimerCallback(reload);
                    System.Threading.Timer timer = new System.Threading.Timer(timerDelegate);
                    timer.Change(1000, 0);
                }
            }
            else
            {
                TimerCallback timerDelegate = new TimerCallback(reload);
                System.Threading.Timer timer = new System.Threading.Timer(timerDelegate);
                timer.Change(1000, 0);
            }
            

            //TimerCallback timerDelegate = new TimerCallback(reload);
            //System.Threading.Timer timer = new System.Threading.Timer(timerDelegate);
            //timer.Change(1000, 0);

        }

        private void wb2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser2 wbObj = sender as WebBrowser2;
            HtmlDocument _document = wbObj.Document;
            string strTitle = "";

            HtmlElementCollection divs = _document.Body.GetElementsByTagName("div");
            HtmlElement emBody = _document.GetElementById("articleBody");

            foreach (HtmlElement em in divs)
            {
                if (em.GetAttribute("className") == "articleTitle")
                {
                    strTitle = em.InnerText; 
                   
                    break;

                }
            }

            txtBody.Text = strTitle + "\n" + emBody.InnerText;

        }


        private void reload(object o)
        {
            this.wb.Navigate(initUri);
        }
        private void BntReset_Click(object sender, EventArgs e)
        {
            this.wb.Refresh();
        }

        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            progressBar1.Value = 50;
            LblStk.Text = "進捗：50%";
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            progressBar1.Value = 10;
            LblStk.Text = "進捗：10%";
        }

        private void wb_NavigateError(object sender, Win.YMK.Controls.WebBrowsers.WebBrowserNavigateErrorEventArgs e)
        {
            label1.Text += e.StatusCode + ":";
            //msg.Information(e.StatusCode + "" + this.wb.ReadyState);
            //this.wb.Refresh();
            this.wb.Navigate("https://www.google.co.jp/?gws_rd=ssl");
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            //ScriptErrorsSuppressed
            e.Handled = true;
        }


       

       

       
    }
}

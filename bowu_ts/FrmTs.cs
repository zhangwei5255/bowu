using JPBook.YMK.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win.YMK.Controls.WebBrowsers;

namespace bowu_ts
{
    public partial class FrmTs : BaseForm
    {
        Uri initUri;
        string strUrl = "";

        public FrmTs()
        {
            InitializeComponent();
        }

        private void FrmTs_Load(object sender, EventArgs e)
        {
            // Uri の設定 
            initUri = new Uri(ConfigurationManager.AppSettings["BOWU_URL"]);
            // ナビゲート 
            this.wb.Navigate(initUri);

           
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser2 wbObj = sender as WebBrowser2;
            HtmlDocument _document = wbObj.Document;
            string strTitle = "";
            
            HtmlElement enlst = _document.GetElementById("emblog_list");
            HtmlElementCollection divs = enlst.GetElementsByTagName("div");
            HtmlElement emLi;

            foreach (HtmlElement em in divs)
            {
                if (em.GetAttribute("className") == "list")
                {

                    emLi = em.GetElementsByTagName("li")[0];

                    HtmlElementCollection links = emLi.GetElementsByTagName("a");
                    strUrl = links[0].GetAttribute("href");

                    wb2.Navigate(strUrl);

                   
                    break;

                }
            }

           
        }

        private void wb2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "100";
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


            TimerCallback timerDelegate = new TimerCallback(reload);
            System.Threading.Timer timer = new System.Threading.Timer(timerDelegate);
            timer.Change(1000, 0);
        }

        private void reload(object o)
        {
            if (String.IsNullOrWhiteSpace(strUrl) == false)
            {
                this.wb2.Navigate(strUrl);
            }
            
        }

        private void wb_NavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            
        }

        private void wb2_NavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            this.wb2.Navigate("https://www.google.co.jp/?gws_rd=ssl");
        }

        private void wb2_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = "10";
        }

        private void wb2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Text = "50";
        }

      

       
    }
}

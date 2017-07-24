using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace Win.YMK.Controls.HttpImages
{
	public partial class HttpImage : UserControl
	{
		public HttpImage()
		{
			InitializeComponent();
		}
		private string m_url = string.Empty;
		public string URL
		{
			get { return m_url; }
			set
			{
				m_url = value;
				m_imageflag = true;
				string pageurl = string.Empty;
				if (m_uploadedflag)
				{
					pageurl = ConfigurationManager.AppSettings["WebSiteURL"] +
								ConfigurationManager.AppSettings["RootURL"] + "image.aspx";
					wbImage.Url = new Uri(pageurl);
				}
				else
				{
					pageurl = Application.StartupPath +
								(Application.StartupPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ?
									string.Empty : Path.DirectorySeparatorChar.ToString()) + "image.html";
					if (File.Exists(pageurl))
						wbImage.Url = new Uri(pageurl);
				}
			}
		}
		private bool m_uploadedflag = false;
		public bool UploadedFlag { get { return m_uploadedflag; } set { m_uploadedflag = value; } }
		private bool m_imageflag = false;
		public bool ImageFlag { get { return m_imageflag; } }

		private void wbImage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlElement image = wbImage.Document.GetElementById("image");
			if (image != null)
			{
				//image.SetAttribute("src", CFL.Tos(m_url));
                image.SetAttribute("src", (m_url));
				image.SetAttribute("visible", string.IsNullOrEmpty(m_url) ? "false" : "true");
			}
		}
		private void btnAddImg_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				m_uploadedflag = false;
				URL = openFileDialog.FileName;
			}
		}
		public byte[] GetFileContent(int width, int height)
		{
			return GetFileContent(width, height, 0, 0);
		}
		public byte[] GetFileContent(int width, int height, float hdpi, float vdpi)
		{
			MemoryStream stream = new MemoryStream();
			try
			{
				ImageCodecInfo encoder = GetEncoderInfo("image/jpeg");
				if (encoder != null)
				{
					Bitmap bitmaporigin = new Bitmap(URL);
					double originaspect = ((double)bitmaporigin.Width / (double)bitmaporigin.Height);
					double aspect = ((double)width / (double)height);
					if (originaspect > aspect)
						height = ((int)((double)width / originaspect));
					else if (originaspect < aspect)
						width = ((int)((double)height * originaspect));

					Bitmap bitmapconverted = new Bitmap(bitmaporigin, width, height);
					EncoderParameters eps = new EncoderParameters(1);
					hdpi = ((hdpi > 0 && bitmaporigin.HorizontalResolution > hdpi) ? hdpi :
								bitmaporigin.HorizontalResolution);
					vdpi = ((vdpi > 0 && bitmaporigin.VerticalResolution > vdpi) ? vdpi :
								bitmaporigin.VerticalResolution);
					bitmapconverted.SetResolution(hdpi, vdpi);
					eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 80L);
					bitmapconverted.Save(stream, encoder, eps);
					return stream.ToArray();
				}
			}
			catch { }
			finally
			{
				if (stream != null)
				{
					stream.Close();
					stream.Dispose();
				}
			}
			return new byte[0];
		}

		#region 取得图片编码信息
		private ImageCodecInfo GetEncoderInfo(String mimetype)
		{
			ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
			for (int j = 0; j < encoders.Length; ++j)
			{
				if (encoders[j].MimeType == mimetype)
					return encoders[j];
			}
			return null;
		}
		#endregion
		public void Clear()
		{
			URL = string.Empty;
			m_imageflag = false;
			m_uploadedflag = false;
		}
	}
}
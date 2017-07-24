using System;
using System.IO;
using Win.YMK.NetWorkings.Bean;
using Win.YMK.NetWorkings.Base;

namespace Win.YMK.Networkings
{
	public class INPServer : ServerBase
	{
		public event EventHandler RecieveCompleted;

		public void OnRecieveCompleted()
		{
			if (RecieveCompleted != null)
				RecieveCompleted(this, new EventArgs());
		}

		public INPServer(string localIP, int port)
			: base(localIP, port)
		{

		}

		// all i have to do if override this function and redirect
		// the data to a file.
		public override void OnDataRecieved(ClientInfo info)
		{
			// change the fileName if you want to test this whit a other file.
			string filename = new string(System.Text.Encoding.Default.GetChars(info.Buffer, 0, FILENAMELENGTH));

			int filesize = int.Parse(new string(System.Text.Encoding.Default.GetChars(info.Buffer, FILENAMELENGTH, FILESIZE)));

			if (filesize > BUFFERSIZE - FILENAMELENGTH - FILESIZE)
				return;

			FileStream fs = new FileStream("E:\\" + filename, FileMode.OpenOrCreate);

			fs.Write(info.Buffer, FILENAMELENGTH + FILESIZE, filesize);

			fs.Flush();

			// this is importend 
			// don't forget to close the file or you won't be able to acces 
			// the file the next time the function is called.
			fs.Close();

			// check if the stream is empty
			if (info.Socket.Available == 0)
				OnRecieveCompleted();

			base.OnDataRecieved(info);
		}
	}
}


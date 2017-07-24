using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Win.YMK.NetWorkings.Bean;

namespace Win.YMK.NetWorkings.Base
{
	public class ServerBase
	{
		private const int BACKLOG = 10;
		protected const int BUFFERSIZE = 20000;
		protected const int FILENAMELENGTH = 18;//length of filename
		protected const int FILESIZE = 10;//length of filename

		private int _port;
		private string _localIP;
		private Socket _mainSoc;
		private ArrayList _connections;
		private AsyncCallback _dataRecievedCallback;
		private AsyncCallback _acceptCallback;

		public event NetworkEventHandler ClientConnected;
		public event NetworkEventHandler ClientDisConnected;
		public event NetworkEventHandler DataRecieved;

		public virtual void OnDataRecieved(ClientInfo info)
		{
			if (DataRecieved != null)
			{
				DataRecieved(this,
					new NetworkEventArgs(info));
			}
		}

		public void OnClientConnected(ClientInfo info)
		{
			if (ClientConnected != null)
			{
				ClientConnected(this,
					new NetworkEventArgs(info));
			}
		}

		public void OnClientDisConnected(ClientInfo info)
		{
			if (ClientDisConnected != null)
			{
				ClientDisConnected(this,
					new NetworkEventArgs(info));
			}
		}

		public ServerBase(string localIP, int port)
		{
			_connections = new ArrayList();

			_port = port;
			_localIP = localIP;
			_mainSoc = new Socket(
				AddressFamily.InterNetwork,
				SocketType.Stream,
				ProtocolType.Tcp);

			_mainSoc.Bind(new IPEndPoint(IPAddress.Parse(_localIP), _port));
			_acceptCallback = new AsyncCallback(OnAccept);
			_dataRecievedCallback = new AsyncCallback(OnDataRecieved);
		}

		public void Start()
		{
			_mainSoc.Listen(BACKLOG);

			_mainSoc.BeginAccept(_acceptCallback, null);
		}

		public void Stop()
		{
			if (_mainSoc.Connected)
				_mainSoc.Shutdown(SocketShutdown.Both);
		}

		private void OnAccept(IAsyncResult ar)
		{
			Socket clientSoc = _mainSoc.EndAccept(ar);

			ClientInfo info = new ClientInfo(
				clientSoc, new byte[BUFFERSIZE]);

			OnClientConnected(info);

			WaitForData(info);

			_mainSoc.BeginAccept(_acceptCallback, null);
		}

		private void WaitForData(ClientInfo info)
		{
			info.Socket.BeginReceive(info.Buffer, 0, info.Buffer.Length,
				SocketFlags.None,
				_dataRecievedCallback, info);

			_mainSoc.BeginAccept(_acceptCallback, null);
		}

		private void OnDataRecieved(IAsyncResult ar)
		{
			// free up some memory.
			GC.Collect();

			ClientInfo info =
				info = (ClientInfo)ar.AsyncState;

			int byteCount = 0;
			try
			{
				byteCount = info.Socket.EndReceive(ar);
			}
			catch (SocketException e)
			{
				if (e.ErrorCode == 10054)
				{
					OnClientDisConnected(info);
					info.Dispose();
					info = null;
					return;
				}
			}

			if (byteCount == 0)
			{
				OnClientDisConnected(info);
				info.Dispose();
				info = null;
			}
			else
			{
				OnDataRecieved(info);

				WaitForData(info);
			}
		}
	}
}

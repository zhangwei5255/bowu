using System;
using System.Net;
using System.Net.Sockets;
using Win.YMK.NetWorkings.Bean;

namespace Win.YMK.NetWorkings.Base
{
    /// <summary>
    /// Summary description for ClientBase.
    /// </summary>
    public class ClientBase
    {
        private const int BUFFERSIZE = 20000;
        protected const int FILENAMELENGTH = 18;//length of filename
        protected const int FILESIZE = 10;//length of filename

        private int _port;
        private string _serverIP;
        private Socket _mainSoc;
        private ClientInfo _info;

        private AsyncCallback _dataRecievedCallback;
        public event NetworkEventHandler DataRecieved;

        public ClientBase(string serverIP, int port)
        {
            _serverIP = serverIP;
            _port = port;

            _mainSoc = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            _info = new ClientInfo(
                _mainSoc,
                new byte[BUFFERSIZE]);

            _dataRecievedCallback = new AsyncCallback(OnDataRecieved);

        }

        // i add the data parameter so it can be overriden in a superclass
        // where you can do something with it
        public virtual void OnDataRecieved(byte[] data)
        {
            if (DataRecieved != null)
            {
                DataRecieved(this,
                    new NetworkEventArgs(_info));
            }
        }

        public void Send(byte[] data)
        {
            _mainSoc.Send(data);
        }

        public void Connect()
        {
            _mainSoc.Connect(
                new IPEndPoint(
                IPAddress.Parse(_serverIP),
                _port));
        }

        public void Disconnect()
        {
            if (_mainSoc.Connected)
                _mainSoc.Shutdown(SocketShutdown.Both);
        }

        public void WaitForData()
        {
            // lets wait and listen if i recieve some data
            _mainSoc.BeginReceive(_info.Buffer, 0, _info.Buffer.Length,
                SocketFlags.None,
                _dataRecievedCallback, null);
        }

        private void OnDataRecieved(IAsyncResult ar)
        {
            // free up some memory.
            GC.Collect();

            int byteCount = 0;

            byteCount = _mainSoc.EndReceive(ar);

            if (byteCount == 0)
            {
                // server disconnected.
            }
            else
            {
                OnDataRecieved(_info.Buffer);

                WaitForData();
            }
        }
    }
}

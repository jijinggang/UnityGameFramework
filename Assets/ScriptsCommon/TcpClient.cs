using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ByteBuffer;


class TcpClient
{
    private Socket _socket = null;
    private bool _ready = false;
    public void Connect(string ip, int port)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        socket.Blocking = false;
        socket.BeginConnect(IPAddress.Parse(ip), port, new AsyncCallback(onConnected), this);
        _socket = socket;
        _ready = false;
    }
    public Package GetMessage()
    {
        return popPackage();
    }
    private Queue<Package> _receivePackage = new Queue<Package>();
    private void pushPackage(Package package)
    {
        lock (_receivePackage)
        {
            _receivePackage.Enqueue(package);
        }
    }
    private Package popPackage()
    {
        Package package = null;
        lock (_receivePackage)
        {
            if(_receivePackage.Count > 0)
                package = _receivePackage.Dequeue();
        }
        return package;
    }
	//public delegate void OnReceiveFn(int type,byte[] data);
    //public OnReceiveFn OnReceive { set; get; }
    public delegate void OnConnectHandler();
    public OnConnectHandler OnConnect { get; set; }
    private void onConnected(IAsyncResult result)
    {
        if (_socket.Connected)
        {
            _socket.EndConnect(result);
            _ready = true;
			ReceiveOnce();
            if (OnConnect != null)
                OnConnect();
        }
    }
	
    private const int HEAD_SIZE = 8;
    private byte[] _headBuffer = new byte[HEAD_SIZE];
    private byte[] _dataBuffer = null;
    private void ReceiveOnce()
    {
        if (!_ready)
            return ;
        byte[] buffer = _headBuffer;
        _socket.BeginReceive(buffer, 0, HEAD_SIZE, SocketFlags.None, new AsyncCallback(onReceiveHeader), buffer);
    }
	private void onReceiveHeader(IAsyncResult result){
		int n = _socket.EndReceive(result);
        if (n != HEAD_SIZE)
            return ;
        byte[] buf = _headBuffer;
        int len = (buf[0] << 24) + (buf[1] << 16) + (buf[2] << 8) + buf[3];
        int type = (buf[4] << 24) + (buf[5] << 16) + (buf[6] << 8) + buf[7];
        _dataBuffer = new byte[len];
        _socket.BeginReceive(_dataBuffer, 0, len, SocketFlags.None, new AsyncCallback(onReceiveData), type);
	}
	private void onReceiveData(IAsyncResult result){
		int type = (int) result.AsyncState;
		int len = _socket.EndReceive(result);
		byte[] buf = _dataBuffer;
        pushPackage(new Package(type, buf));
		ReceiveOnce();
	}
    private ByteBuffer _sendBuff = new ByteBuffer();
    public void Send(int type,byte[] buf)
    {
        if(!_ready)
            return;
        _sendBuff.Initialize();
        int len = buf.Length;
        _sendBuff.PushLong(len);
		_sendBuff.PushLong(type);
        _sendBuff.PushByteArray(buf);
        _socket.Send(_sendBuff.ToByteArray());
    }
    private void Close()
    {
        _socket.Close();
        _ready = false;
    }

    public class Package
    {
        public int type;
        public byte[] data;
        public Package(int type, byte[] data)
        {
            this.type = type;
            this.data = data;
        }
    };
}


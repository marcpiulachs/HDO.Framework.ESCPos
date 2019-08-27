using System;
using System.Net;
using System.Net.Sockets;

namespace HDO.Framework.ESCPos.Connectors
{
    public class NetworkPrinterConnector : IPrinterConnector
    {
        private readonly IPEndPoint endPoint;
        private Socket socket;

        public NetworkPrinterConnector(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            OpenSocket();
        }

        public NetworkPrinterConnector(IPAddress ipAddress, int port)
        {
            endPoint = new IPEndPoint(ipAddress, port);
            OpenSocket();
        }

        public NetworkPrinterConnector(string ipAddress, int port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            OpenSocket();
        }

        private void OpenSocket()
        {
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
        }

        public void Dispose()
        {
            if (socket != null)
                socket.Dispose();
        }

        public byte[] Read()
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] data)
        {
            socket.Send(data);
        }
    }
}

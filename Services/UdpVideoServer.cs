using System.Net.Sockets;
using System.Net;

namespace UDP_data.Services
{
    public class UdpVideoServer
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;

        public UdpVideoServer(string serverIp, int serverPort)
        {
            _udpClient = new UdpClient();
            _endPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
        }

        public void SendData(byte[] data)
        {
            try
            {
                _udpClient.Send(data, data.Length, _endPoint);
                Console.WriteLine($"Sent {data.Length} bytes to {_endPoint.Address}:{_endPoint.Port}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
            }
        }
    }
}

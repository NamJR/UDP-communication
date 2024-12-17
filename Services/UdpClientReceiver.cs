using System.Net.Sockets;
using System.Net;

namespace UDP_data.Services
{
    public class UdpClientReceiver 
    {
        private readonly UdpClient udpClient;
        private readonly IPEndPoint endPoint;

        public UdpClientReceiver(int port)
        {
            udpClient = new UdpClient(port);
            endPoint = new IPEndPoint(IPAddress.Any, port); 
        }

        public void StartReceiving()
        {
            try
            {
                Console.WriteLine("Starting to receive UDP packets...");
                while (true)
                {
                    IPEndPoint tempEndPoint = new IPEndPoint(IPAddress.Any, endPoint.Port);

                    // Nhận gói UDP
                    byte[] data = udpClient.Receive(ref tempEndPoint);
                    Console.WriteLine($"Received {data.Length} bytes from {tempEndPoint.Address}:{tempEndPoint.Port}");

                    Console.WriteLine($"Received data: {BitConverter.ToString(data)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving UDP packets: {ex.Message}");
            }
        }
    }
}

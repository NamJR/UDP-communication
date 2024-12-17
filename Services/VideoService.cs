namespace UDP_data.Services
{
    public class VideoService
    {
        private readonly UdpVideoServer _udpServer;

        public VideoService(UdpVideoServer udpServer)
        {
            _udpServer = udpServer;
        }

        public void StreamVideo(string videoFilePath)
        {
            try
            {
                if (!File.Exists(videoFilePath))
                {
                    throw new FileNotFoundException("Video file not found.");
                }

                byte[] videoData = File.ReadAllBytes(videoFilePath);
                int bufferSize = 1024; // Kích thước gói UDP (1 KB)

                for (int i = 0; i < videoData.Length; i += bufferSize)
                {
                    int chunkSize = Math.Min(bufferSize, videoData.Length - i);
                    byte[] chunk = new byte[chunkSize];
                    Array.Copy(videoData, i, chunk, 0, chunkSize);

                    _udpServer.SendData(chunk);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error streaming video: {ex.Message}");
                throw;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using UDP_data.Services;

namespace UDP_data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UdpController : Controller
    {
        private readonly VideoService _videoService;

        public UdpController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost("stream")]
        public IActionResult StreamVideo([FromBody] string videoFilePath)
        {
            try
            {
                _videoService.StreamVideo(videoFilePath);
                return Ok("Video streaming started.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error streaming video: {ex.Message}");
            }
        }
    }
}

using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.CompilerServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/images")]
    [ApiController]
    [AllowAnonymous]
    public class ImageController : ControllerBase
    {
        private IWebHostEnvironment environment;
        private ProductRepository productRepository;
        public ImageController(IWebHostEnvironment env , ProductRepository productRepository) 
        { 
            this.environment = env;
            this.productRepository = productRepository;
        }
        // GET api/<PictureController>/5
        [HttpGet("{fileName}")]
        public async Task<IActionResult> getImage(string fileName)
        {
            try
            {
                var imageDirectory = Path.Combine(this.environment.ContentRootPath, "images");
                var filePath = Path.Combine(imageDirectory, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    var fileStream = System.IO.File.OpenRead(filePath);
                    var contentType = GetContentType(fileName); // Lấy loại nội dung dựa trên phần mở rộng của tệp tin
                    return File(fileStream, contentType); // Adjust content type based on your image type
                }
                return NotFound("Image not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        // POST api/<ProductController>
        //[Authorize(Policy = "authenticated")]
        [HttpPost]
        public async Task<IActionResult> uploadImage([FromForm] Image image)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            var fileName = await productRepository.saveImages(image.ImageFile);
            status.Message = fileName;
            return Ok(status);

        }

        private string GetContentType(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "application/octet-stream"; // Loại nội dung mặc định nếu không xác định được
            }
        }
    }
}

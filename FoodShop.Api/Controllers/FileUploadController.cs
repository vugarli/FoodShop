using FoodShop.Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private IPresignedUploadUrlGeneratorService _urlGenerator { get; }
        public FileUploadController(IPresignedUploadUrlGeneratorService urlGenerator)
        {
            _urlGenerator = urlGenerator;
        }


        [HttpGet("{type}/{filename}")]
        public async Task<IActionResult> GenerateFileUrlAsync
            (
                string type,
                string filename
            )
        {
            var url = await _urlGenerator.GenerateUrlAsync(filename, type);
            return Ok(url);
        }

    }
}

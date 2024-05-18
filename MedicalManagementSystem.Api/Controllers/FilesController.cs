using MedicalManagementSystem.Application.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IWebHostEnvironment web) : ControllerBase
    {
        private readonly IWebHostEnvironment _web = web;

        [HttpPost("{subfolder}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(string subfolder)
        {
            try
            {
                var file = (await Request.ReadFormAsync()).Files[0];
                var fileName = Files.UploadFiles(file, subfolder);
                return Ok(new { filename = fileName, location = $"{Request.Scheme}:/{Request.Host.Value}/{Files.masterFolderName}/{subfolder}/{fileName}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }

        [HttpGet, Route("{path}/{fileName}")]
        public IActionResult GetFile(string path, string fileName)
        {
            string filePath = $"/{path}/{fileName}";
            string root = $"{_web.WebRootPath}{Files.masterFolderName}";
            return File(Files.GetImage(root, filePath), "image/png");
        }
    }
}

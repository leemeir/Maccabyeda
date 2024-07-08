using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleDbRepository;
using TriangleFileStorage;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly FilesManage _filesManage;

        public MediaController(FilesManage filesManage)
        {
           _filesManage = filesManage;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] string imageBase64)
        {
            string fileName = await _filesManage.SaveFile(imageBase64, "png", "uploadedFiles");
            return Ok(fileName);
        }

    }
}

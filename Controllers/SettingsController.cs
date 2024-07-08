using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programmin2_classroom.Shared.DTOS;
using TriangleDbRepository;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly DbRepository _db;
        public SettingsController(DbRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {

            object param = new
            {
                UserId = userId
            };
            string userQuery = "SELECT * FROM Users WHERE UserId = @UserId";
            var records = await _db.GetRecordsAsync<Users>(userQuery, param);
            Users user = records.FirstOrDefault();
            if (user != null)
            {
                return Ok(user);

            }
            return BadRequest("No such user");

        }

    }
}

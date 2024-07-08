using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Programmin2_classroom.Shared.DTOS;
using TriangleDbRepository;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]/{PersonalId}/{Password}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbRepository _db;
        public LoginController(DbRepository db)
        {
            _db = db;
        }

        //קריאה שמושכת את כל הפרטים של המשתמש לאחר הזנת תעודת הזהות במסך ההתחברות
        [HttpGet]
        public async Task<IActionResult> Login(int PersonalId, string Password)
        {

            object param = new
            {
                personalid = PersonalId,
                password = Password
            };
                    string userQuery = "SELECT * FROM Users WHERE PersonalId = @personalid AND Password = @password";
                    var records = await _db.GetRecordsAsync<Users>(userQuery, param);
                    Users user = records.FirstOrDefault();
            if(user != null)
            {
                return Ok(user);

            }
            return BadRequest("No such user");

        }
    }
}

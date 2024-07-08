using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programmin2_classroom.Shared.DTOS;
using TriangleDbRepository;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly DbRepository _db;
        public CoinsController(DbRepository db)
        {
            _db = db;
        }

        [HttpGet("HaifaTrivia/{UserId}/{coins}")]
        public async Task<IActionResult> UpdateHaifaTrivia(int UserId, int coins)
        {
            object param = new
            {
                coins = coins,
                UserId = UserId,    

            };


            if (UserId > 0)
            {
                string query = "UPDATE Users set Coins = Coins + @coins, TriviaHaifa = true WHERE UserId = @UserId";

                bool isUpdate = await _db.SaveDataAsync(query, param);
                if (isUpdate == true)
                {
                    return Ok();
                }
                return BadRequest("Update Failed");
            }
            return BadRequest("ID not sent");
        }



        [HttpGet("HaifaStudyUnit/{UserId}")]
        public async Task<IActionResult> UpdateHaifaStudyunit(int UserId)
        {
            object param = new
            {
                UserId = UserId,

            };


            if (UserId > 0)
            {
                string query = "UPDATE Users set Coins = Coins + 100, UnitHaifa = true WHERE UserId = @UserId";

                bool isUpdate = await _db.SaveDataAsync(query, param);
                if (isUpdate == true)
                {
                    return Ok();
                }
                return BadRequest("Update Failed");
            }
            return BadRequest("ID not sent");
        }



    }
}

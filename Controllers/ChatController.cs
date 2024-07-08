using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleDbRepository;
using Programmin2_classroom.Shared.DTOS.ChatDtos;


namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly DbRepository _db;


        public ChatController(DbRepository db)
        {
            _db = db;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            object param = new
            {
            };

            string userQuery = "SELECT UserId,FirstName,LastName FROM Users";
            var records = await _db.GetRecordsAsync<PhoneBook>(userQuery, param);
            List<PhoneBook> users = records.ToList();
            if (users != null)
            {
                return Ok(users);

            }
            return BadRequest("null");
        }


        [HttpGet("HistoryChat/{receiverId}/{senderId}")]
        public async Task<IActionResult> HistoryChat(int receiverId, int senderId)
        {
            object param = new
            {
                ReceiverId = receiverId,
                SenderId = senderId

            };
            string Query = "SELECT * From Chat WHERE (UserId = @SenderId AND ReceiverId =@ReceiverId) OR (UserId = @ReceiverId AND ReceiverId=@SenderId)";
            var record = await _db.GetRecordsAsync<Chating>(Query, param);
            ListMessage chatHistory = new ListMessage
            {
                senderId = senderId,
                receiverId = receiverId,
                HistoryChatList = record.ToList()
            };
            if (chatHistory.HistoryChatList.Count > 0)
            {
                return Ok(chatHistory);
            }
            return Ok(new ListMessage { HistoryChatList = new List<Chating>() });
        }


        [HttpPost("Message")]
        public async Task<IActionResult> Message(NewMessage newMessage)
        {
            object param = new
            {
                userId = newMessage.senderId,
                receiverId = newMessage.receiverId,
                message = newMessage.message

            };

            string insertQuery = "INSERT INTO Chat (Sender,Receiver,Message, UserId, ReceiverId) VALUES ((SELECT FirstName || ' ' || LastName FROM Users WHERE UserId =@userId),(SELECT FirstName || ' ' || LastName FROM Users WHERE UserId =@receiverId),@message,(SELECT UserId FROM Users WHERE UserId =@userId),(SELECT UserId FROM Users WHERE UserId = @receiverId)) ";
            int id = await _db.InsertReturnId(insertQuery, param);
            if (id != 0)
            {
                return Ok(param);
            }
            return BadRequest("not messageid");


        }

    }
}

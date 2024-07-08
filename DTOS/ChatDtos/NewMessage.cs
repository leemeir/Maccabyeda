using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.DTOS.ChatDtos
{
    public class NewMessage
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string message { get; set; }
        public DateTime messageTime { get; set; }

    }
}

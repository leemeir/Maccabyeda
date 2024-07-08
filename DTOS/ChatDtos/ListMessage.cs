using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.DTOS.ChatDtos
{
    public class ListMessage
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public List<Chating> HistoryChatList { get; set; }

    }
}

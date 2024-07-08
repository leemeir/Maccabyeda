using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.DTOS.ChatDtos
{
    public class Chating
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public int ReceiverId { get; set; }
    }
}

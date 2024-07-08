using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.DTOS
{
	public class Users
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public int PersonalId { get; set; }
		public string Password { get; set; }
		public string ImageUrl { get; set; }
		public int Coins { get; set; }
		public bool UnitHaifa { get; set; }
        public bool TriviaHaifa { get; set; }
        public bool UnitTelaviv { get; set; }
        public bool TriviaTelaviv { get; set; }
		public bool UnitSeaofgalilee { get; set; }
		public bool TriviaSeaofgalilee { get; set; }
		public bool UnitDeadsea { get; set; }
		public bool TriviaDeadsea { get; set; }
		public bool UnitJerusalem { get; set; }
		public bool TriviaJerusalem { get; set; }
		public bool UnitEilat{ get; set; }
		public bool TriviaEilat{ get; set; }

	}
}

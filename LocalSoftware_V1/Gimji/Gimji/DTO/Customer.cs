using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
	internal class Customer
	{
		public string	Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string fullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string phoneNumber { get; set; }
		public string contactAddress { get; set; }
		public string Email { get; set; }
		public int Point { get; set; }

		public string Type { get; set; }
	}
}

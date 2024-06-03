using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Admin
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string fullName { get; set; }
        public string DateOfBirth { get; set; }

        public string Email { get; set; }
        public string phoneNumber { get; set; }


    }
}

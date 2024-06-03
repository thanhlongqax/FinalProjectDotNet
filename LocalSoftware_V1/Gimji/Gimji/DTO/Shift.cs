using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
	internal class Shift
	{
		public string shiftID { get; set; }
        public string note { get; set; }
        public string shiftName { get; set; }
		public DateTime dateTime { get; set; }
        public string staffID { get; set; }
		public string staffName { get; set;}

    }
	
}

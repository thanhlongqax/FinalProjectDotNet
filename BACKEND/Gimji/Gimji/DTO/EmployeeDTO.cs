using Gimji.Models;

namespace Gimji.DTO
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string jobTitle { get; set; }
        public string homeLocation { get; set; }
        public bool hasCertification { get; set; }
        public int roleId { get; set; }
        public string accountId { get; set; }
        public string accountPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimji.Models
{
    [Table ("employee")]
    public class employee
    {
        [Key]
        public int id {  get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Tên không dài quá 30 ký tự")]
        public string givenName { get; set; }
        [MaxLength(30, ErrorMessage = "Họ không dài quá 30 ký tự")]
        public string familyName { get; set; }
        public string? gender { get; set; }
        public DateTime? birthDate { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string telephone { get; set; }
        public string? jobTitle { get; set; }
        public string homeLocation { get; set; }
        public Boolean? hasCertification { get; set; }
        public string? accountId { get; set; }
        public string? accountPassword { get; set; }
        [NotMapped]
        public string FullName => $" {familyName} {givenName} ";

        public virtual ICollection<Role> Roles {get ; set;}

    }
}

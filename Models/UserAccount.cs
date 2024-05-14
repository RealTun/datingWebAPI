using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("user_account")]
    public class UserAccount
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? Bio { get; set; }

        public int? Age { get; set; }

        public byte Gender { get; set; }

        public byte Looking_For { get; set; }

        public string? Location { get; set; }

        public string? Confirmation_Code { get; set; }

        public DateTime? Confirmation_Time { get; set; }
    }

}

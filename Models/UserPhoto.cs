using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("user_photo")]
    public class UserPhoto
    {
        public int Id { get; set; }
        [Column("user_account_id")]
        public int UserAccountId { get; set; }
        public string? Link { get; set; }

        // Optional navigation property for UserAccount
        public UserAccount? UserAccount { get; set; }
    }
}

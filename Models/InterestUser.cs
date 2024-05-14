using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("interest_user")]
    public class InterestUser
    {
        public int Id { get; set; }
        [Column("user_account_id")]
        public int UserAccountId { get; set; }
        [Column("interest_type_id")]
        public int InterestTypeId { get; set; }

        // Optional navigation properties
        public UserAccount? UserAccount { get; set; }
        public InterestType? InterestType { get; set; }
    }
}

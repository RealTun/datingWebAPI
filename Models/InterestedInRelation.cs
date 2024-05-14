using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("interested_in_relation")]
    public class InterestedInRelation
    {
        public int Id { get; set; }
        [Column("user_account_id")]
        public int UserAccountId { get; set; }
        [Column("relationship_type_id")]
        public int RelationshipTypeId { get; set; }

        // Optional navigation properties
        public UserAccount? UserAccount { get; set; }
        public RelationshipType? RelationshipType { get; set; }
    }

}

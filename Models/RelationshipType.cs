using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("relationship_type")]
    public class RelationshipType
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}

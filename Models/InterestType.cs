using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAPI.Models
{
    [Table("interest_type")]
    public class InterestType
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}

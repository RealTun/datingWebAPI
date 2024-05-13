using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DatingAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public long Phone { get; set; }
        public string Password { get; set; } = string.Empty;
        public int Confirmation_code { get; set; }
        public DateTime Confirmation_time { get; set; }
        public string Bio { get; set; } = string.Empty;
        public int Age { get; set; }
        public short Gender { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}

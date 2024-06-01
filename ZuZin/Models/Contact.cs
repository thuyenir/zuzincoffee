using System.ComponentModel.DataAnnotations.Schema;

namespace ZuZin.Models
{
    [Table("Contact")]
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BraviSimpleCRUD.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

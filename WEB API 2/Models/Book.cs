using System.ComponentModel.DataAnnotations;

namespace WEB_API_2.Models
{
    public class book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Author { get; set; }
    }
}

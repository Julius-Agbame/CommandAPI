using System.ComponentModel.DataAnnotations;
namespace CommandAPI.Models
{
    public class Commands
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string CommandLine { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Platform { get; set; } = string.Empty;
    }
}
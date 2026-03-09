using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Dtos
{
    public class CommandUpdateDto
    {
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
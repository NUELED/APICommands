using System.ComponentModel.DataAnnotations;

namespace Commands.DTOs
{
 public class CommandDTO
 {
        [Key]
        public int id { get; set; }
        [Required]
         [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string line { get; set; }
        //[Required]
        // public string Platform { get; set; }
 }

}
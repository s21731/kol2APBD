using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        [Required]
        public int TeamID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(4)]
        public string FileExtension  { get; set; }
        [Required]
        public int FileSize { get; set; }


        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
    }
}

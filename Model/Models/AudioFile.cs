using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class AudioFile
    {
        [Key, ForeignKey("Issue")]
        public int Id { get; set; }

        public string FileName { get; set; }

        [Required]
        public string sufix { get; set; }

        public byte[] Data { get; set; }

        public virtual Issue Issue { get; set; }
    }
}

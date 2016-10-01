using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class TrackFileInfo
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        public string FileName { get; set; }

        [ForeignKey("Issue")]
        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Issue
    {
        public Issue()
        {
            TracksFileName = new List<TrackFileInfo>();
        }

        [Key]
        public int IssueId { get; set; }

        [Required]
        public int IssueNr { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("Dialogue")]
        public int DialogueId { get; set; }

        public virtual Dialogue Dialogue { get; set; }

        [ForeignKey("Actor")]

        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }


        public virtual ICollection<TrackFileInfo> TracksFileName { get; set; }
    }
}

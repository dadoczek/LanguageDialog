using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Actor
    {
        public Actor()
        {
            Issues = new List<Issue>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Dialogue")]
        public int DialogueId { get; set; }

        public virtual Dialogue Dialogue { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

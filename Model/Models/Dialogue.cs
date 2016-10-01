using Model.EnumType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Dialogue
    {
        public Dialogue()
        {
            Actors = new List<Actor>();
            Issues = new List<Issue>();
        }

        [Key]
        public int DialogueId { get; set; }

        [Required]
        public string Name { get; set; }

        public DialogueStatus Status { get; set; }

        //Tabele powiązane

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

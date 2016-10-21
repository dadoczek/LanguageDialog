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
            UserDialogue = new List<UserDialogue>();
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

        [Required]
        [ForeignKey("Autor")]
        public string AutorId { get; set; }
        public virtual User Autor { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<UserDialogue> UserDialogue { get; set; }
    }
}

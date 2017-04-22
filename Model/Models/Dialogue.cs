using Model.EnumType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DialogueStatus Status { get; set; } = DialogueStatus.Edit;

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

        public List<Issue> GetIssues()
        {
            var issues = new List<Issue>();
            foreach (var items in this.Actors.Select(a => a.Issues))
            {
                issues.AddRange(items);
            }

            foreach (var issue in issues)
            {
                if (issue.AudioFile != null) ;
            }

            return issues;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Language
    {
        public Language()
        {
            ChildLanguages = new List<Language>();
        }

        [Key]
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ParentLanguage")]
        public int? ParentId { get; set; }

        public virtual Language ParentLanguage { get; set; }

        public virtual ICollection<Language> ChildLanguages { get; set; }

        public string GetFullName()
        {
            var name = "";
            if (ParentId != null)
            {
                name = ParentLanguage.GetFullName();
                name += " : ";
            }
            name += Name;

            return name;
        }
    }
}

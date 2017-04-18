using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class UserLanguage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [ForeignKey("User")]
        public string UserId{ get; set; }
        public virtual User User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class ViewText
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ViewLanguage")]
        public int ViewLanguageId { get; set; }
        public virtual ViewLanguage ViewLanguage { get; set; }
    }
}

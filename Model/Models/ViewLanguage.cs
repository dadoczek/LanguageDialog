using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class ViewLanguage
    {
        public ViewLanguage()
        {
            ViewTexts = new List<ViewText>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string ViewName { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<ViewText> ViewTexts{ get; set; }
    }
}

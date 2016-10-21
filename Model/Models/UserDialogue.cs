using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class UserDialogue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string DialogueId { get; set; }
        public virtual Dialogue Dialogue { get; set; }

    }
}

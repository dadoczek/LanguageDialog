using Model.Models;

namespace Contract.Dtos
{
    public class DialoguePlayDto
    {
        public Dialogue Dialogue { get; set; }
        public int? SelectActor { get; set; }
        public bool VisableMyText { get; set; }
        public bool VisableOtherText { get; set; }
    }
}

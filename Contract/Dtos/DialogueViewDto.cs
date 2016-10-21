using Contract.Enum;
using Model.Models;
using System.Collections.Generic;

namespace Contract.Dtos
{
    public class DialogueViewDto
    {
        public Dialogue Dialogue { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public DialogueEditWindow ActiveDialogueEditWindow { get; set; }
    }
}

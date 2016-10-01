using Model.Models;
using System.Collections.Generic;

namespace Contract.Dtos
{
    public class CreateDialogueDto
    {
        public Dialogue Dialogue { get; set; }

        public IEnumerable<Language> Languages { get; set; }
    }
}

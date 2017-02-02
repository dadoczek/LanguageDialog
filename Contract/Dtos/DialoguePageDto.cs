using Model.Models;
using System.Collections.Generic;

namespace Contract.Dtos
{
    public class DialoguePageDto
    {
        public PagingDto Paging { get; set; }
        public List<Dialogue> Dialogues { get; set; }
        public DialogueSortDto Sort { get; set; }
    }
}

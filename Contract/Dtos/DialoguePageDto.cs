using Model.Models;
using System.Linq;

namespace Contract.Dtos
{
    public class DialoguePageDto
    {
        public PagingDto Paging { get; set; }
        public IQueryable<Dialogue> Dialogues { get; set; }
    }
}

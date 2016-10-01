using Model.Models;
using System.Linq;

namespace Contract.Responses
{
    public class DialogueCollectionResponse : BaseResponse
    {
        public IQueryable<Dialogue> Diaogues { get; set; }
    }
}

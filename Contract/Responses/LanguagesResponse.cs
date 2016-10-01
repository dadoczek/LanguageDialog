using Model.Models;
using System.Linq;

namespace Contract.Responses
{
    public class LanguagesResponse : BaseResponse
    {
        public IQueryable<Language> Languages { get; set; }
    }
}

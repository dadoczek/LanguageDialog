using Model.Models;
using System.Linq;

namespace Contract.Dtos
{
    public class LanguagePageDto
    {
        public PagingDto Paging { get; set; }
        public IQueryable<Language> Language { get; set; }
    }
}

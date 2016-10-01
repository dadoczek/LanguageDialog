using Contract.Dtos;
using Model.Models;
using System.Linq;

namespace Repository.AbstractRepo
{
    public interface ILanguageRepository
    {
        IQueryable<Language> GetAll();

        IQueryable<Language> GetMainAll();

        LanguagePageDto GetPage(int page);

        Language GetOne(int languageId);

        void Remove(int languageId);

        void Add(Language language);

        void Edit(Language language);
    }
}

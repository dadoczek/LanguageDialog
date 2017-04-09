using System.Linq;
using Contract.Dtos;
using Model.Models;

namespace Repo.AbstractRepo
{
    public interface ILanguageRepository
    {
        IQueryable<Language> GetAll();

        IQueryable<Language> GetMainAll();

        LanguagePageDto GetPage(int page);

        Language GetOne(int id);

        void Remove(int id);

        void Add(Language language);

        void Edit(Language language);
    }
}

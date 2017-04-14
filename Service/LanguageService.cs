using System.Collections.Generic;
using Contract.WebModel;
using Model.Models;
using Service.Helper;
using System.Linq;

namespace Service
{
    public class LanguageService : EntityBaseService, ILanguageService
    {
        public LanguageService(IRepositoryProvider provider) : base(provider) { }

        public void Add(Language language)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Add(language);
            });
        }

        public void Edit(Language language)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Edit(language);
            });
        }

        public Language GetOne(int id)
        {
            return RepositoryProvider.Do(repo => repo.GetOne<Language>(id));
        }

        public void Remove(int id)
        {
            RepositoryProvider.Do(repo => repo.Remove<Language>(id));
        }

        public ICollection<Language> GetAll()
        {
            return RepositoryProvider.Do(repo => repo.GetCollection<Language>().ToList());
        }

        public ICollection<Language> GetMainAll()
        {
            return RepositoryProvider.Do(
                repo => repo.GetCollection<Language>().Where(language => language.ParentId == null).ToList());
        }

        public PageData<Language> GetPage(int page)
        {
            return RepositoryProvider.Do(repo =>
            {
                var data = repo.GetCollection<Language>()
                .Where(language => language.ParentId == null).OrderBy(language => language.Name);

                var pageData = PagingService.GetPaging(data, page);

                return pageData;
            });
        }
    }
}

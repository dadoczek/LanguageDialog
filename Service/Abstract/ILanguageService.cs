using System.Collections.Generic;
using Contract.WebModel;
using Model.Models;

namespace Service.Abstract
{
    public interface ILanguageService
    {
        void Add(Language language);
        void Edit(Language language);
        ICollection<Language> GetAll();
        ICollection<Language> GetMainAll();
        Language GetOne(int id);
        PageData<Language> GetPage(int page);
        void Remove(int id);
    }
}
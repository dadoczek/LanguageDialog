namespace Core.AbstractRepoApplication
{
    public interface ILanguageApplication
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

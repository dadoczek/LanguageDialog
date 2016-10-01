using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface ILanguageApplication
    {
        LanguagesResponse GetAll();

        LanguagesResponse GetMainAll();

        LanguagePageResponse GetPage(int page);

        LanguageResponse GetOne(int languageId);

        BaseResponse Remove(int languageId);

        BaseResponse Add(Language language);

        BaseResponse Edit(Language language);
    }
}

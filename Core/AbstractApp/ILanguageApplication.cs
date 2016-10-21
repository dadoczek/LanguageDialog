using Contract.Dtos;
using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface ILanguageApplication
    {
        QueryableDataResponse<Language> GetAll();

        QueryableDataResponse<Language> GetMainAll();

        DataResponse<LanguagePageDto> GetPage(int page);

        DataResponse<Language> GetOne(int languageId);

        BaseResponse Remove(int languageId);

        BaseResponse Add(Language language);

        BaseResponse Edit(Language language);
    }
}

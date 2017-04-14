using Contract.Dtos;
using Contract.Responses;
using Contract.WebModel;
using Model.Models;

namespace Core.AbstractApp
{
    public interface ILanguageApplication
    {
        CollectionDataResponse<Language> GetAll();

        CollectionDataResponse<Language> GetMainAll();

        PageResponse<Language> GetPage(int page);

        DataResponse<Language> GetOne(int id);

        BaseResponse Remove(int id);

        BaseResponse Add(Language language);

        BaseResponse Edit(Language language);
    }
}

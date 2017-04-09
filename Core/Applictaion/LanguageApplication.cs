using Contract.Dtos;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Collections.Generic;
using Repo.AbstractRepo;

namespace Core.Applictaion
{
    internal class LanguageApplication : BaseApplication, ILanguageApplication
    {
        private readonly ILanguageRepository _languageRepository;
        public static IEnumerable<Language> Languages;
        public LanguageApplication(IFactory factory)
        {
            _languageRepository = factory.GetLanguageRepository;
        }

        public BaseResponse Add(Language language)
        {
            return DoSuccess(() =>
            {
                _languageRepository.Add(language);
            });
        }

        public BaseResponse Edit(Language language)
        {
            return DoSuccess(() =>
            {
                _languageRepository.Edit(language);
            });
        }

        public QueryableDataResponse<Language> GetAll()
        {
            Languages = _languageRepository.GetAll();
            return Do(() => new QueryableDataResponse<Language>
            {
                Data = _languageRepository.GetAll()
            });
        }

        public QueryableDataResponse<Language> GetMainAll()
        {
            return Do(() => new QueryableDataResponse<Language>
            {
                Data = _languageRepository.GetMainAll()
            });
        }

        public DataResponse<Language> GetOne(int languageId)
        {
            return Do(() => new DataResponse<Language>
            {
                Data = _languageRepository.GetOne(languageId)
            });
        }

        public DataResponse<LanguagePageDto> GetPage(int page)
        {
            return Do(() => new DataResponse<LanguagePageDto>
            {
                Data = _languageRepository.GetPage(page)
            });
        }

        public BaseResponse Remove(int languageId)
        {
            return DoSuccess(() =>
            {
                _languageRepository.Remove(languageId);
            });
        }
    }
}

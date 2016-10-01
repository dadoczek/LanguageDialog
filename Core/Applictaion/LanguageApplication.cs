using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repository.AbstractRepo;

namespace Core.Applictaion
{
    internal class LanguageApplication : BaseApplication, ILanguageApplication
    {
        private readonly Factory _factory;
        private readonly ILanguageRepository _languageRepository;

        public LanguageApplication(Factory factory)
        {
            _factory = factory;
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

        public LanguagesResponse GetAll()
        {
            return Do(() => new LanguagesResponse
            {
                Languages = _languageRepository.GetAll()
            });
        }

        public LanguagesResponse GetMainAll()
        {
            return Do(() => new LanguagesResponse
            {
                Languages = _languageRepository.GetMainAll()
            });
        }

        public LanguageResponse GetOne(int languageId)
        {
            return Do(() => new LanguageResponse
            {
                Language = _languageRepository.GetOne(languageId)
            });
        }

        public LanguagePageResponse GetPage(int page)
        {
            return Do(() => new LanguagePageResponse
            {
                LanguagePageDto = _languageRepository.GetPage(page)
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

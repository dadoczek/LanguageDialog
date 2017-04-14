using Contract.Dtos;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Collections.Generic;
using Contract.WebModel;
using Repo.AbstractRepo;
using Service;

namespace Core.Applictaion
{
    internal class LanguageApplication : BaseApplication, ILanguageApplication
    {
        private readonly ILanguageService _service;


        public LanguageApplication(IFactory factory)
        {
            _service = factory.GetLanguageService;
        }

        public BaseResponse Add(Language language)
        {
            return DoSuccess(() =>
            {
                _service.Add(language);
            });
        }

        public BaseResponse Edit(Language language)
        {
            return DoSuccess(() =>
            {
                _service.Edit(language);
            });
        }

        public CollectionDataResponse<Language> GetAll()
        {
            return Do(() => new CollectionDataResponse<Language>
            {
                Data = _service.GetAll()
            });
        }

        public CollectionDataResponse<Language> GetMainAll()
        {
            return Do(() => new CollectionDataResponse<Language>
            {
                Data = _service.GetMainAll()
            });
        }

        public DataResponse<Language> GetOne(int id)
        {
            return Do(() => new DataResponse<Language>
            {
                Data = _service.GetOne(id)
            });
        }

        public PageResponse<Language> GetPage(int page)
        {
            return Do(() => new PageResponse<Language>
            {
                PageData = _service.GetPage(page)
            });
        }

        public BaseResponse Remove(int id)
        {
            return DoSuccess(() =>
            {
                _service.Remove(id);
            });
        }
    }
}

using Contract.Responses;
using Core.Factories;
using Service.Abstract;

namespace Core.Applictaion
{
    internal class ViewLanguageApplication : BaseApplication, IViewLanguageApplication
    {
        private readonly IViewLanguageService _service;


        public ViewLanguageApplication(IFactory factory)
        {
            _service = factory.GetViewLanguageService;
        }

        public DictionaryResponse<string, string> GetViewText(string viewName, int languageId)
        {
            return Do(() => new DictionaryResponse<string,string>
            {
                Dictionary = _service.GetViewText(viewName,languageId)
            });
        }
    }
}

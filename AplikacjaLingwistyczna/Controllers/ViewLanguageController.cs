using System.Web.Mvc;
using Core.Applictaion;
using Core.Factories;

namespace AplikacjaLingwistyczna.Controllers
{
    public class ViewLanguageController : Controller
    {
        private readonly IViewLanguageApplication _app;

        public ViewLanguageController(IFactory factory)
        {
            _app = factory.GetViewLanguageApplication;
        }

        public EmptyResult GetText(string viewName, int languageId, ViewDataDictionary viewData )
        {
            viewData.Add("ViewText", _app.GetViewText(viewName,languageId));

            return new EmptyResult();
        }
    }
}
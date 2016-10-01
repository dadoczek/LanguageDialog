using Core.Factory;
using Model.Models;
using Repository.AbstractRepo;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageCrud;

        public LanguageController(IFactory factory)
        {
            _languageCrud = factory.GetLanguageRepository;
        }

        public ActionResult GetPage(int page = 1)
        {
            var model = _languageCrud.GetPage(page);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int? idParent = null)
        {
            var language = new Language
            {
                ParentId = idParent
            };

            return View(language);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ParentId,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                _languageCrud.Add(language);
                return RedirectToAction("GetPage");
            }
            return View(language);
        }

        public ActionResult Remove(int idLanguage)
        {
            _languageCrud.Remove(idLanguage);
            return RedirectToAction("GetPage");
        }

    }
}
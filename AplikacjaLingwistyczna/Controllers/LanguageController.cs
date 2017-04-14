using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    [Authorize(Roles ="Admin,Moderator")]
    public class LanguageController : Controller
    {
        private readonly ILanguageApplication _languageCrud;

        public LanguageController(IFactory factory)
        {
            _languageCrud = factory.GetLanguageApplication;
        }

        [AllowAnonymous]
        public EmptyResult GetAll(ViewDataDictionary viewData)
        {
            var response = _languageCrud.GetAll();
            var data = response.Data;
            viewData.Add("Languages", data);

            return new EmptyResult();
        }

        public ActionResult GetPage(int page = 1)
        {
            var model = _languageCrud.GetPage(page);
            return View(model.PageData);
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

        public ActionResult Remove(int id)
        {
            _languageCrud.Remove(id);
            return RedirectToAction("GetPage");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model =  _languageCrud.GetOne(id);
            return View(model.Data);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ParentId, Name, Id")] Language language)
        {
            if (ModelState.IsValid)
            {
                _languageCrud.Edit(language);
                return RedirectToAction("GetPage");
            }

            return View(language);
        }
    }
}
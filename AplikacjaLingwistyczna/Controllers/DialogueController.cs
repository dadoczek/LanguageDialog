using System.Collections.Generic;
using Contract.Enum;
using Contract.Params;
using Contract.WebModel;
using Core.AbstractApp;
using Core.Factories;
using Microsoft.AspNet.Identity;
using Model.Models;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    [Authorize]
    public class DialogueController : Controller
    {
        private readonly IDialogueApplication _dialogueApp;

        public DialogueController(IFactory factory)
        {
            _dialogueApp = factory.GetDialogueApplication;
        }

        [Authorize(Roles = "Admin,Moderator")]
        public ICollection<Dialogue> GetAll()
        {
            var model = _dialogueApp.GetAll();
            return model.Data;
        }

        [AllowAnonymous]
        public ActionResult GetPage(DialoguePageParams @params = null)
        {
            if (@params == null)
                @params = new DialoguePageParams();

            var model = _dialogueApp.GetPage(@params);
            ViewData.Add("GetPage", model.PageData);
            return View(model.PageData);
        }

        [AllowAnonymous]
        public ActionResult ViewPage(DialoguePageParams @params = null)
        {
            if (@params == null)
                @params = new DialoguePageParams();

            GetPage(@params);

            return View(@params);
        }

        public ActionResult GetMyDialoguePage(DialoguePageParams @params)
        {
            var data = MyDialogData(@params);
            return View("GetPage", data);
        }

        private PageData<Dialogue> MyDialogData(DialoguePageParams @params)
        {
            if (@params == null)
                @params = new DialoguePageParams();

            @params.IdUser = User.Identity.GetUserId();

            ViewData.Add("UserId", User.Identity.GetUserId());
            var model = _dialogueApp.GetMyDialoguePage(@params);
            return model.PageData;
        }

        [HttpPost]
        public string PublishDialogue(int id)
        {
            var result = _dialogueApp.PublishDialogue(id);

            return result.Message;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SortPage(DialoguePageParams @params)
        {
            ViewData.Add("UserId", User.Identity.GetUserId());
            @params.IdUser = User.Identity.GetUserId();

            return View("ViewPage", @params);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userIdClaim = claimsIdentity?.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var model = new Dialogue {AutorId = userIdClaim.Value};

            return View(model);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,LanguageId,AutorId")] Dialogue model)
        {
            if (ModelState.IsValid)
            {
                _dialogueApp.Add(model);
                return RedirectToAction("ViewPage");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditView(int id, DialogueEditWindow activeWindow = DialogueEditWindow.GeneralWindow)
        {
            var result = _dialogueApp.GetOne(id);

            ViewData.Add("ActiveWindows", activeWindow);

            return View(result.Data);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,LanguageId,AutorId")] Dialogue model)
        {
            if (ModelState.IsValid)
            {
                _dialogueApp.Edit(model);
            }
            return View(model);
        }

        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Remove(int idDialogue)
        {
            var result = _dialogueApp.Remove(idDialogue);
            return RedirectToAction("ViewPage");
        }

        [Authorize]
        public ActionResult RemoveEdit(int idDialogue)
        {
            var result = _dialogueApp.RemoveEdit(idDialogue, User.Identity.GetUserId());
            var data = MyDialogData(new DialoguePageParams());
            return RedirectToAction("ViewPage", data);
        }
    }
}
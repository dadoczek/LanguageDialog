using Contract.Enum;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Net;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorApplication _actorApp;

        public ActorController(IFactory factory)
        {
            _actorApp = factory.GetActorApplication;
        }

        public ActionResult GetPage(int idDialogue, int page = 1)
        {
            var data = _actorApp.GetPage(idDialogue, page);

            return View(data.PageData);
        }


        [HttpPost]
        public ActionResult CreateActor([Bind(Include = "Id,Name,DialogueId")] Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorApp.Add(model);
            }
            return RedirectToAction("EditView", "Dialogue", new { id = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
        }

        public ActionResult Delete(int idActor, int idDialogue)
        {
            _actorApp.Remove(idActor);
            return RedirectToAction("EditView", "Dialogue", new { id = idDialogue, activeWindow = DialogueEditWindow.ActorWindow });
        }

        [HttpGet]
        public ActionResult Edit(int idActor)
        {
            var actor = _actorApp.GetOne(idActor);
            if (actor == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(actor.Data);
        }
        [HttpPost]
        public ActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorApp.Edit(model);
                return RedirectToAction("EditView", "Dialogue", new { id = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
            }
            else
                return View(model);
        }
    }
}
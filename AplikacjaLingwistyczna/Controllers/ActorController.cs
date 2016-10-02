using Contract.Dtos;
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


        [HttpPost]
        public ActionResult CreateActor([Bind(Include = "DialogueId,Name")] Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorApp.Add(model);
            }
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
        }

        public ActionResult Delete(int idActor, int idDialogue)
        {
            _actorApp.Remove(idActor);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = idDialogue, activeWindow = DialogueEditWindow.ActorWindow });
        }

        [HttpGet]
        public ActionResult Edit(int idActor)
        {
            var actor = _actorApp.GetOne(idActor);
            if (actor == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(actor);
        }
        [HttpPost]
        public ActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorApp.Edit(model);
                return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
            }
            else
                return View(model);
        }
    }
}
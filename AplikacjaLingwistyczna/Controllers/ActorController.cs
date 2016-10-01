using Contract.Dtos;
using Core.Factory;
using Model.Models;
using Repository.AbstractRepo;
using System.Net;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorCrud;

        public ActorController(IFactory factory)
        {
            _actorCrud = factory.GetActorRepository;
        }


        [HttpPost]
        public ActionResult CreateActor([Bind(Include = "DialogueId,Name")] Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorCrud.Add(model);
            }
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
        }

        public ActionResult Delete(int idActor, int idDialogue)
        {
            _actorCrud.Remove(idActor);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = idDialogue, activeWindow = DialogueEditWindow.ActorWindow });
        }

        [HttpGet]
        public ActionResult Edit(int idActor)
        {
            var actor = _actorCrud.GetOne(idActor);
            if (actor == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(actor);
        }
        [HttpPost]
        public ActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                _actorCrud.Edit(model);
                return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.ActorWindow });
            }
            else
                return View(model);
        }
    }
}
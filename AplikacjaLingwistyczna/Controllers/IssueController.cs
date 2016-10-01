using Contract.Dtos;
using Core.Factories;
using Model.Models;
using Repository.AbstractRepo;
using System.Net;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository _issueCrud;

        public IssueController(IFactory factory)
        {
            _issueCrud = factory.GetIssueRepository;
        }


        [HttpPost]
        public ActionResult CreateIssue([Bind(Include = "DialogueId,Text,IssueNr,ActorId")] Issue model)
        {
            if (ModelState.IsValid)
            {
                _issueCrud.Add(model);
            }
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });

        }

        public ActionResult Delete(int positionId, int idDialogue)
        {
            _issueCrud.Remove(idDialogue, positionId);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = idDialogue, activeWindow = DialogueEditWindow.IssueWindow });
        }

        public ActionResult ChangePosition(int positionId, int idDialogue, int direction)
        {
            _issueCrud.ChangePosition(idDialogue, positionId, direction);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = idDialogue, activeWindow = DialogueEditWindow.IssueWindow });
        }

        [HttpGet]
        public ActionResult Edit(int positionId, int idDialogue)
        {
            var issue = _issueCrud.GetOne(positionId, idDialogue);
            if (issue == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(issue);
        }
        [HttpPost]
        public ActionResult Edit(Issue model)
        {
            if (ModelState.IsValid)
            {
                _issueCrud.Edit(model);
                return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
            }
            else
                return View(model);
        }
    }
}
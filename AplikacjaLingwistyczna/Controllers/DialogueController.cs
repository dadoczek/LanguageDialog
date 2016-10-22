using Contract.Dtos;
using Contract.Enum;
using Contract.Params;
using Core.AbstractApp;
using Core.Factories;
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
        public ActionResult GetAll()
        {
            var model = _dialogueApp.GetAll();
            return View(model.Data);
        }

        [AllowAnonymous]
        public ActionResult GetPage(int page = 1, DialogueSortDto sort = null)
        {
            var model = _dialogueApp.GetPage(new DialoguePageParams
            {
                Page = page,
                Sort = sort
            });
            return View(model.Data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = _dialogueApp.GetToCreateData();
            return View(model.Data);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Dialogue")] DialogueViewDto model)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        model.Dialogue.AutorId = userIdClaim.Value;
                    }
                }
                _dialogueApp.Add(model.Dialogue);
                return RedirectToAction("GetPage");
            }
            else
            {
                var result = _dialogueApp.SetLanguages(model);
                return View(result.Data);
            }
        }

        [HttpGet]
        public ActionResult Edit(int idDialogue, DialogueEditWindow activeWindow = DialogueEditWindow.GeneralWindow)
        {
            var result = _dialogueApp.GetToEditData(
                new DialogueEditWievParams
                {
                    Id = idDialogue,
                    DialogueEditWindow = activeWindow
                });

            return View(result.Data);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Dialogue")]DialogueViewDto editModel)
        {
            if (ModelState.IsValid)
            {
                editModel = _dialogueApp.SetLanguages(editModel).Data;
                return View(editModel);
            }
            else
            {
                editModel = _dialogueApp.SetLanguages(editModel).Data;
                return View("Edit", editModel);
            }
        }

        [HttpPost]
        public ActionResult EditGeneral([Bind(Include = "Dialogue")]DialogueViewDto editModel)
        {
            if (ModelState.IsValid)
            {
                _dialogueApp.Edit(editModel.Dialogue);
                return RedirectToAction("Edit", new { idDialogue = editModel.Dialogue.DialogueId });
            }
            else
            {
                return Edit(editModel);
            }
        }

        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Remove(int idDialogue)
        {
            _dialogueApp.Remove(idDialogue);
            return RedirectToAction("GetPage");
        }
    }
}
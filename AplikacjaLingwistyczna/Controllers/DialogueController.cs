using Contract.Dtos;
using Contract.Params;
using Core.AbstractRepoApplication;
using Core.Factory;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class DialogueController : Controller
    {
        private readonly IDialogueApplication _dialogueApp;

        public DialogueController(IFactory factory)
        {
            _dialogueApp = factory.GetDialogueApplication;
        }

        public ActionResult GetAll()
        {
            var model = _dialogueApp.GetAll();
            return View(model.Diaogues);
        }

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
        public ActionResult Create([Bind(Include = "Dialogue")] CreateDialogueDto model)
        {
            if (ModelState.IsValid)
            {
                _dialogueApp.Add(model.Dialogue);
                return RedirectToAction("GetPage");
            }
            else
            {
                var result = _dialogueApp.GetToCreateData(model);
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
        public ActionResult Edit([Bind(Include = "Dialogue")]EditDialogueDto editModel)
        {
            if (ModelState.IsValid)
            {
                editModel = _dialogueApp.GetToEditData(editModel).Data;
                return View(editModel);
            }
            else
            {
                editModel = _dialogueApp.GetToEditData(editModel).Data;
                return View("Edit", editModel);
            }
        }

        [HttpPost]
        public ActionResult EditGeneral([Bind(Include = "Dialogue")]EditDialogueDto editModel)
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

        public ActionResult Remove(int idDialogue)
        {
            _dialogueApp.Remove(idDialogue);
            return RedirectToAction("GetPage");
        }
    }
}
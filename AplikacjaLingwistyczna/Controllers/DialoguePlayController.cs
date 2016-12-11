using Core.Factories;
using System.Web.Mvc;
using Core.AbstractApp;
using Contract.Responses;

namespace AplikacjaLingwistyczna.Controllers
{
    public class DialoguePlayController : Controller
    {
        private IPlayerDialogueAppplication _playerApp;

        public DialoguePlayController(IFactory factory)
        {
            _playerApp = factory.GetPlayerDiaogueApplication;
        }

        [HttpGet]
        public ActionResult Play(int dialogueId)
        {
            var result = _playerApp.GetPlayerModel(dialogueId);
            return View(result.Data);
        }

        [HttpPost]
        public ActionResult Play(PlayResponse model)
        {
            var result = _playerApp.ReloadDialogue(model);
            return View(result.Data);
        }
    }
}
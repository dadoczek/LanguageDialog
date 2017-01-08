using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using System.IO;
using System.Web.Mvc;

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
        public ActionResult PlayAudio(int fileId)
        {

            byte[] bytes = _playerApp.GetAudioBytes(fileId).Data;

            var ms = new MemoryStream(bytes);
            return File(ms, "audio/mpeg");
        }

        public int PlayDialogue(int? nr, int idDialogue, int idActor)
        {
            return _playerApp.PlayDialogue(nr, idDialogue, idActor);
        }
    }
}
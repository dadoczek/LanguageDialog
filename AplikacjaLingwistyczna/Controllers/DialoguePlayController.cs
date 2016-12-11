using Core.Factories;
using System.Web.Mvc;
using Core.AbstractApp;
using Contract.Responses;
using System.IO;

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

            MemoryStream ms = new MemoryStream(bytes);
            return File(ms, "audio/mpeg");
        }

    }
}
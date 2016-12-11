using Core.Factories;
using System.Web.Mvc;
using Core.AbstractApp;
using Contract.Responses;
using System.IO;
using System.Linq;

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

        public int PlayDialogue(int? nr, int idDialogue, int idActor)
        {
            var model = _playerApp.GetPlayerModel(idDialogue).Data;
            bool isPlay;

            do
            {
                var last = model.Dialogue.Issues.OrderBy(i => i.IssueNr).Last().IssueNr;
                if (nr >= last)
                {
                    nr = model.Dialogue.Issues.OrderBy(i => i.IssueNr).First().IssueNr;
                }
                nr = +nr + 1;
                if (idActor == null)
                {
                    isPlay = true;
                }
                else
                {
                    var Actor = model.Dialogue.Actors.FirstOrDefault(a => a.ActorId == idActor);
                    isPlay = !Actor.Issues.Any(i => i.IssueNr == nr);
                }

            } while (!isPlay);

            return nr.Value;
        }
    }
}
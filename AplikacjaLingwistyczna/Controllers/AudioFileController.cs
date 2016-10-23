using AplikacjaLingwistyczna.Models;
using Contract.Enum;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Web;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class AudioFileController : Controller
    {
        private readonly IFileApplication _fileApp;
        public AudioFileController(IFactory factory)
        {
            _fileApp = factory.GetFileApplication;
        }

        [HttpPost]
        public ActionResult Upload(Issue issue, HttpPostedFileBase file)
        {
            var audioFile = new AudioFile
            {
                Id = issue.IssueId,
                FileName = file.FileName,
                sufix = ".mp3",
                Data = new byte[file.ContentLength]
            };

            file.InputStream.Read(audioFile.Data, 0, file.ContentLength);
            _fileApp.Add(audioFile);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = issue.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
        }
    }
}
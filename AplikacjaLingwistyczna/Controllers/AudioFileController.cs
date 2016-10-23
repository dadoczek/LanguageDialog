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
        private readonly IIssueApplication _issueApp;
        public AudioFileController(IFactory factory)
        {
            _issueApp = factory.GetIssueApplication;
        }

        [HttpPost]
        public ActionResult Upload(Issue issue, HttpPostedFileBase file)
        {
            issue.AudioFile = new AudioFile
            {
                FileName = file.FileName,
                sufix = ".mp3",
                Data = new byte[file.ContentLength]
            };

            file.InputStream.Read(issue.AudioFile.Data, 0, file.ContentLength);
            _issueApp.Edit(issue);
            return RedirectToAction("Edit", "Dialogue", new { idDialogue = issue.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
        }
    }
}
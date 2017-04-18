using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Web;
using System.Web.Mvc;
using Contract.Enum;

namespace AplikacjaLingwistyczna.Controllers
{
    public class AudioFileController : Controller
    {
        private readonly IFileApplication _fileApp;
        private IFactory _factory;
        public AudioFileController(IFactory factory)
        {
            _factory = factory;
            _fileApp = factory.GetFileApplication;
        }

        [HttpGet]
        public ActionResult RecordAudio(Issue issue)
        {
            return PartialView(issue);
        }

        [HttpPost]
        public bool PostRecordedAudioVideo(int id)
        {
            foreach (string upload in Request.Files)
            {
                var file = Request.Files[upload];
                if (file == null) continue;

                var audioFile = new AudioFile
                {
                    Id = id,
                    FileName = file.FileName,
                    sufix = ".mp3",
                    Data = new byte[file.ContentLength]
                };

                file.InputStream.Read(audioFile.Data, 0, file.ContentLength);
                _fileApp.AddOrEdit(audioFile);
            }
            return true;
        }

        //[HttpPost]
        //public ActionResult Upload(Issue issue, HttpPostedFileBase file)
        //{
        //    var audioFile = new AudioFile
        //    {
        //        Id = issue.Id,
        //        FileName = file.FileName,
        //        sufix = ".mp3",
        //        Data = new byte[file.ContentLength]
        //    };

        //    file.InputStream.Read(audioFile.Data, 0, file.ContentLength);
        //    _fileApp.Add(audioFile);
        //    return RedirectToAction("Edit", "Dialogue", new { idDialogue = issue.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
        //}
    }
}
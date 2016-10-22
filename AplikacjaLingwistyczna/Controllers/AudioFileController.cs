using AplikacjaLingwistyczna.Models;
using System.Web;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class AudioFileController : Controller
    {
        // GET: AudioFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(UploadFileDto model)
        {
            return View();
           // return RedirectToAction("Edit", "Dialogue", new { idDialogue = model.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
        }
    }
}
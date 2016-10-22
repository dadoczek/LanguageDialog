using Model.Models;
using System.Web;

namespace AplikacjaLingwistyczna.Models
{
    public class UploadFileDto
    {
        public HttpPostedFileBase File { get; set; }
        public int IssueId { get; set; }
        public int DialogueId { get; set; }
    }
}

using Model.Models;
using System.Web;

namespace AplikacjaLingwistyczna.Models
{
    public class UploadFileDto
    {
        public HttpPostedFileBase File { get; set; }
        public Issue Issue { get; set; }
    }
}

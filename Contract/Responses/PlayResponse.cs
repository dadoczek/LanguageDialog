using Contract.Dtos;
using Model.Models;

namespace Contract.Responses
{
    public class PlayResponse
    {
        public Dialogue Dialogue { get; set; }
        public PlaySetting Setting { get; set; }
    }
}

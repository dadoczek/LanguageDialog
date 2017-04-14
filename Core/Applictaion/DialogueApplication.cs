using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.EnumType;
using Model.Models;
using Service;
using System.Linq;

namespace Core.Applictaion
{
    internal class DialogueApplication : BaseApplication, IDialogueApplication
    {
        private readonly IDialogueService _service;


        public DialogueApplication(IFactory factory)
        {
            _service = factory.GetDialogueService;
        }

        public BaseResponse Add(Dialogue dialogue)
        {
            return DoSuccess(() =>
            {
                _service.Add(dialogue);
            });
        }

        public BaseResponse Edit(Dialogue dialogue)
        {
            return DoSuccess(() =>
            {
                _service.Edit(dialogue);
            });
        }

        public CollectionDataResponse<Dialogue> GetAll()
        {
            return Do(() => new CollectionDataResponse<Dialogue>
            {
                Data = _service.GetAll()
            });
        }

        public DataResponse<Dialogue> GetOne(int id)
        {
            return Do(() => new DataResponse<Dialogue>
            {
                Data = _service.GetOne(id)
            });
        }

        public PageResponse<Dialogue> GetPage(DialoguePageParams @params)
        {
            return Do(() => new PageResponse<Dialogue>
            {
                PageData = _service.GetPage(@params)
            });
        }

        public PageResponse<Dialogue> GetMyDialoguePage(DialoguePageParams @params)
        {
            return Do(() => new PageResponse<Dialogue>
            {
                PageData = _service.GetPage(@params)
            });
        }
        public BaseResponse PublishDialogue(int dialogueId)
        {
            return Do(() => 
            {
                var dialogue = _service.GetOne(dialogueId);
                var publishStatus = PubishIsAkcept(dialogue);
                if (publishStatus == PublishStatus.Akcept)
                {
                    dialogue.Status = DialogueStatus.Pubish;
                    _service.Edit(dialogue);
                    var result = new BaseResponse
                    {
                        IsValid = true,
                        Status = SerializationStatus.Success,
                        Message = "Publikacja zakończona sukcesem"
                    };
                    return result;
                }
                else
                {
                    var result = new BaseResponse
                    {
                        IsValid = true,
                        Status = SerializationStatus.Warning,
                    };
                    if (publishStatus == PublishStatus.AudioWarning)
                        result.Message = "Brak części nagrań audio";
                    if (publishStatus == PublishStatus.ActorWarning)
                        result.Message = "Brak przynajmniej 2 aktorów";
                    if (publishStatus == PublishStatus.IssueWarnig)
                        result.Message = "Brak choć jednej kwestii dialogowej na aktora";
                    return result;
                }
            });
        }

        private PublishStatus PubishIsAkcept(Dialogue dialogue)
        {
            if(dialogue.Actors.Count < 2)
                return PublishStatus.ActorWarning;
            if(dialogue.Actors.Any(a => !a.Issues.Any()))
                return  PublishStatus.IssueWarnig;
            if(dialogue.Issues.Any(i => i.AudioFile == null))
                return PublishStatus.AudioWarning;
            return PublishStatus.Akcept;
        }

        public BaseResponse Remove(int id)
        {
            return DoSuccess(() =>
            {
                _service.Remove(id);
            });
        }

        private enum PublishStatus
        {
            Akcept,
            ActorWarning,
            IssueWarnig,
            AudioWarning,
        }

        public BaseResponse RemoveEdit(int id, string userId)
        {
            return Do(() =>
            {
                var dialogue = _service.GetOne(id);

                if (dialogue.Status != DialogueStatus.Edit || dialogue.AutorId != userId)
                    return new BaseResponse
                    {
                        Status = SerializationStatus.Warning,
                        IsValid = true,
                        Message = "Brak uprawnień"
                    };

                _service.Remove(id);

                return new BaseResponse
                {
                    Status = SerializationStatus.Success,
                    IsValid = true,
                };
            },false);
        }
    }
}

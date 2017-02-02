using System.Data.Entity;
using System.Linq;
using Contract.Dtos;
using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.EnumType;
using Model.Models;
using Repository.AbstractRepo;

namespace Core.Applictaion
{
    internal class DialogueApplication : BaseApplication, IDialogueApplication
    {
        private readonly IDialogueRepository _dialogueRepository;
        private readonly ILanguageRepository _languageRepository;


        public DialogueApplication(IFactory factory)
        {
            _dialogueRepository = factory.GetDialogueRepository;
            _languageRepository = factory.GetLanguageRepository;
        }

        public BaseResponse Add(Dialogue dialogue)
        {
            return DoSuccess(() =>
            {
                _dialogueRepository.Add(dialogue);
            });
        }

        public BaseResponse Edit(Dialogue dialogue)
        {
            return DoSuccess(() =>
            {
                _dialogueRepository.Edit(dialogue);
            });
        }

        public QueryableDataResponse<Dialogue> GetAll()
        {
            return Do(() => new QueryableDataResponse<Dialogue>
            {
                Data = _dialogueRepository.GetAll()
            });
        }

        public DataResponse<Dialogue> GetOne(int id)
        {
            return Do(() => new DataResponse<Dialogue>
            {
                Data = _dialogueRepository.GetOne(id)
            });
        }

        public DataResponse<DialoguePageDto> GetPage(DialoguePageParams @params)
        {
            return Do(() =>
            {
                var dialogues = _dialogueRepository.GetAll();
                dialogues = QueryPageDialogue(@params, dialogues);

                return new DataResponse<DialoguePageDto>
                {
                    Data = GetDialogeDto(@params,dialogues)
                };
        });
    }

        private IQueryable<Dialogue> QueryPageDialogue(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
            if (@params.Sort.LanguageId.HasValue)
            {
                elements = elements.Where(d => d.LanguageId == @params.Sort.LanguageId);
            }

            elements = elements.Where(d => d.Status == DialogueStatus.Pubish);

            if (!string.IsNullOrWhiteSpace(@params.Sort.Name))
                elements = elements.Where(d => d.Name.ToLower().Contains(@params.Sort.Name.ToLower()));

            return elements;
        }

        private DialoguePageDto GetDialogeDto(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
            var countElement = elements.Count();

            var pagingSystem = @params.Sort.SizePage != null
                ? PagingDto.Create(@params.Page, countElement, (int)@params.Sort.SizePage)
                : PagingDto.Create(@params.Page, countElement);

            elements = elements
                .OrderBy(d => d.Name)
                .Skip(pagingSystem.SkipElement())
                .Take(pagingSystem.SizePage)
                .AsNoTracking();

            return new DialoguePageDto
            {
                Dialogues = elements.ToList(),
                Paging = pagingSystem,
                Sort = @params.Sort
            };
        }

        public DataResponse<DialoguePageDto> GetMyDialoguePage(DialoguePageParams @params)
        {
            return Do(() =>
            {
                var dialogues = _dialogueRepository.GetAll();
                dialogues = QueryMyPageDialogue(@params, dialogues); 

                return new DataResponse<DialoguePageDto>
                {
                    Data = GetDialogeDto(@params, dialogues)
                };
            });
        }

        private IQueryable<Dialogue> QueryMyPageDialogue(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
            if (@params.Sort.LanguageId.HasValue)
            {
                elements = elements.Where(d => d.LanguageId == @params.Sort.LanguageId);
            }
            elements = elements.Where(d => d.AutorId == @params.Sort.IdUser);

            elements = elements.Where(d => d.Status == DialogueStatus.Pubish || d.Status == DialogueStatus.Edit);

            if (!string.IsNullOrWhiteSpace(@params.Sort.Name))
                elements = elements.Where(d => d.Name.ToLower().Contains(@params.Sort.Name.ToLower()));

            return elements;
        }

        public BaseResponse PublishDialogue(int dialogueId)
        {
            return Do(() => 
            {
                var dialogue = _dialogueRepository.GetOne(dialogueId);
                var publishStatus = PubishIsAkcept(dialogue);
                if (publishStatus == PublishStatus.Akcept)
                {
                    dialogue.Status = DialogueStatus.Pubish;
                    _dialogueRepository.Edit(dialogue);
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

        public DataResponse<DialogueViewDto> GetToCreateData()
        {
            return Do(() => new DataResponse<DialogueViewDto>
            {
                Data = new DialogueViewDto
                {
                    Languages = _languageRepository.GetMainAll(),
                    Dialogue = new Dialogue
                    {
                        AutorId = "0"
                    }
                },
            });
        }

        public DataResponse<DialogueViewDto> GetToEditData(DialogueEditWievParams @params)
        {
            return Do(() => new DataResponse<DialogueViewDto>
            {
                Data = new DialogueViewDto
                {
                    Dialogue = _dialogueRepository.GetOne(@params.Id),
                    ActiveDialogueEditWindow = @params.DialogueEditWindow,
                    Languages = _languageRepository.GetMainAll()
                },
            });
        }

        public BaseResponse Remove(int id)
        {
            return DoSuccess(() =>
            {
                _dialogueRepository.Remove(id);
            });
        }

        public DataResponse<DialogueViewDto> SetLanguages(DialogueViewDto data)
        {
            return Do(() =>
            {
                data.Languages = _languageRepository.GetMainAll();
                return new DataResponse<DialogueViewDto>
                {
                    Data = data
                };
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
                var dialogue = _dialogueRepository.GetOne(id);

                if (dialogue.Status != DialogueStatus.Edit || dialogue.AutorId != userId)
                    return new BaseResponse
                    {
                        Status = SerializationStatus.Warning,
                        IsValid = true,
                        Message = "Brak uprawnień"
                    };

                _dialogueRepository.Remove(id);

                return new BaseResponse
                {
                    Status = SerializationStatus.Success,
                    IsValid = true,
                };
            },false);
        }
    }
}

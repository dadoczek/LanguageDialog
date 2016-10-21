using Contract.Dtos;
using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
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
            return Do(() => new DataResponse<DialoguePageDto>
            {
                Data = _dialogueRepository.GetPage(@params)
            });
        }

        public DataResponse<DialogueViewDto> GetToCreateData()
        {
            return Do(() => new DataResponse<DialogueViewDto>
            {
                Data = new DialogueViewDto
                {
                    Languages = _languageRepository.GetMainAll()
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
    }
}

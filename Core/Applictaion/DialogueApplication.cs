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

        public DialogueCollectionResponse GetAll()
        {
            return Do(() => new DialogueCollectionResponse
            {
                Diaogues = _dialogueRepository.GetAll()
            });
        }

        public DialogueResponse GetOne(int id)
        {
            return Do(() => new DialogueResponse
            {
                Dialogue = _dialogueRepository.GetOne(id)
            });
        }

        public DialoguePageResponse GetPage(DialoguePageParams @params)
        {
            return Do(() => new DialoguePageResponse
            {
                Data = _dialogueRepository.GetPage(@params)
            });
        }

        public CreateDialogueResponse GetToCreateData(CreateDialogueDto data)
        {
            return Do(() =>
            {
                data.Languages = _languageRepository.GetMainAll();
                return new CreateDialogueResponse
                {
                    Data = data
                };
            });
        }

        public CreateDialogueResponse GetToCreateData()
        {
            return Do(() => new CreateDialogueResponse
            {
                Data = new CreateDialogueDto
                {
                    Languages = _languageRepository.GetMainAll()
                },
            });
        }

        public EditDialogueResponse GetToEditData(EditDialogueDto data)
        {
            return Do(() =>
            {
                data.Languages = _languageRepository.GetMainAll();
                return new EditDialogueResponse
                {
                    Data = data
                };
            });
        }

        public EditDialogueResponse GetToEditData(DialogueEditWievParams @params)
        {
            return Do(() => new EditDialogueResponse
            {
                Data = new EditDialogueDto
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
    }
}

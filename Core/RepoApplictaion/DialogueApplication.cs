using Contract.Dtos;
using Contract.Params;
using Contract.Responses;
using Core.AbstractRepoApplication;
using Core.Factory;
using Model.Models;
using Repository.AbstractRepo;

namespace Core.RepoApplictaion
{
    internal class DialogueApplication : IDialogueApplication
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
            return BaseResponse.DoSuccess(() =>
            {
                _dialogueRepository.Add(dialogue);
            });
        }

        public BaseResponse Edit(Dialogue dialogue)
        {
            return BaseResponse.DoSuccess(() =>
            {
                _dialogueRepository.Edit(dialogue);
            });
        }

        public DialogueCollectionResponse GetAll()
        {
            return BaseResponse.Do(() => new DialogueCollectionResponse
            {
                Diaogues = _dialogueRepository.GetAll()
            });
        }

        public DialogueResponse GetOne(int id)
        {
            return BaseResponse.Do(() => new DialogueResponse
            {
                Dialogue = _dialogueRepository.GetOne(id)
            });
        }

        public DialoguePageResponse GetPage(DialoguePageParams @params)
        {
            return BaseResponse.Do(() => new DialoguePageResponse
            {
                Data = _dialogueRepository.GetPage(@params)
            });
        }

        public CreateDialogueResponse GetToCreateData(CreateDialogueDto data)
        {
            return BaseResponse.Do(() =>
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
            return BaseResponse.Do(() => new CreateDialogueResponse
            {
                Data = new CreateDialogueDto
                {
                    Languages = _languageRepository.GetMainAll()
                },
            });
        }

        public EditDialogueResponse GetToEditData(EditDialogueDto data)
        {
            return BaseResponse.Do(() =>
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
            return BaseResponse.Do(() => new EditDialogueResponse
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
            return BaseResponse.DoSuccess(() =>
            {
                _dialogueRepository.Remove(id);
            });
        }
    }
}

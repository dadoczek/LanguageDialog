using Contract.Dtos;
using Contract.Params;
using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IDialogueApplication
    {
        BaseResponse Edit(Dialogue dialogue);
        BaseResponse Add(Dialogue dialogue);
        BaseResponse Remove(int id);
        DialoguePageResponse GetPage(DialoguePageParams @params);
        DialogueCollectionResponse GetAll();
        DialogueResponse GetOne(int id);
        EditDialogueResponse GetToEditData(DialogueEditWievParams @params);
        EditDialogueResponse GetToEditData(EditDialogueDto data);
        CreateDialogueResponse GetToCreateData();
        CreateDialogueResponse GetToCreateData(CreateDialogueDto data);
    }
}

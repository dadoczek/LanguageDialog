using Contract.Params;
using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IDialogueApplication
    {
        BaseResponse Edit(Dialogue dialogue);
        BaseResponse PublishDialogue(int dialogueId);
        BaseResponse Add(Dialogue dialogue);
        BaseResponse Remove(int id);
        PageResponse<Dialogue> GetPage(DialoguePageParams @params);
        PageResponse<Dialogue> GetMyDialoguePage(DialoguePageParams @params);
        CollectionDataResponse<Dialogue> GetAll();
        DataResponse<Dialogue> GetOne(int id);
        BaseResponse RemoveEdit(int id, string userId);
    }
}

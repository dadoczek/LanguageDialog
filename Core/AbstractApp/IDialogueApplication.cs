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
        DataResponse<DialoguePageDto> GetPage(DialoguePageParams @params);
        QueryableDataResponse<Dialogue> GetAll();
        DataResponse<Dialogue> GetOne(int id);
        DataResponse<DialogueViewDto> GetToEditData(DialogueEditWievParams @params);
        DataResponse<DialogueViewDto> GetToCreateData();
        DataResponse<DialogueViewDto> SetLanguages(DialogueViewDto data);
    }
}

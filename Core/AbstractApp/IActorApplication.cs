using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IActorApplication
    {
        BaseResponse Add(Actor actor);
        BaseResponse Remove(int id);
        BaseResponse Edit(Actor actor);
        PageResponse<Actor> GetPage(int idDialogue, int page);
        DataResponse<Actor> GetOne(int id);
    }
}

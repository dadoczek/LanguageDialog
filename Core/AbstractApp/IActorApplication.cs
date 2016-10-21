using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IActorApplication
    {
        BaseResponse Add(Actor actor);
        BaseResponse Remove(int id);
        BaseResponse Edit(Actor actor);
        DataResponse<Actor> GetOne(int id);
    }
}

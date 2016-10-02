using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IActorApplication
    {
        BaseResponse Add(Actor actor);
        BaseResponse Remove(int id);
        BaseResponse Edit(Actor actor);
        ActorResponse GetOne(int id);
    }
}

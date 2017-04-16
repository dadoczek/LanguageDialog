using Model.Models;

namespace Service.Abstract
{
    public interface IActorService
    {
        void Add(Actor actor);
        void Remove(int id);
        void Edit(Actor actor);
        Actor GetOne(int id);
    }
}

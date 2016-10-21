using Model.Models;

namespace Repository.AbstractRepo
{
    public interface IActorRepository
    {
        void Add(Actor actor);
        void Remove(int id);
        void Edit(Actor actor);
        Actor GetOne(int id);
    }
}

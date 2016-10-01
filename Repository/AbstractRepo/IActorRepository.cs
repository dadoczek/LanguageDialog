using Model.Models;

namespace Repository.AbstractRepo
{
    public interface IActorRepository
    {
        void Add(Actor newActor);
        void Remove(int removeId);
        void Edit(Actor editActor);
        Actor GetOne(int idActor);
    }
}

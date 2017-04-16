using Model.Models;
using Service.Abstract;
using Service.Helper;
using System.Data.Entity;

namespace Service
{
    public class ActorService : EntityBaseService, IActorService
    {
        public ActorService(IRepositoryProvider provider) : base(provider)
        {
        }

        public void Add(Actor actor)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Add(actor);
            });
        }

        public void Edit(Actor actor)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Edit(actor);
            });
        }

        public Actor GetOne(int id)
        {
            return RepositoryProvider.Do(repo => repo.GetOne<Actor>(id));
        }

        public void Remove(int id)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Remove<Actor>(id);
            });
        }
    }
}

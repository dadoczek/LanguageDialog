using System.Linq;
using Contract.WebModel;
using Model.Models;
using Service.Abstract;
using Service.Helper;

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

        public PageData<Actor> GetPage(int idDialogue, int page)
        {
            return RepositoryProvider.Do(repo =>
            {
                var data = repo.GetCollection<Actor>()
                    .Where(a => a.DialogueId == idDialogue);

                var pageData = PagingService.GetPaging(data, page);

                return pageData;
            });
        }
    }
}

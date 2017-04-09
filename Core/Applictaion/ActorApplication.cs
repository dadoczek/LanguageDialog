using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repo.AbstractRepo;

namespace Core.Applictaion
{
    internal class ActorApplication : BaseApplication, IActorApplication
    {
        private readonly IActorRepository _actorRepository;

        public ActorApplication(IFactory factory)
        {
            _actorRepository = factory.GetActorRepository;
        }

        public BaseResponse Add(Actor actor)
        {
            return DoSuccess(() =>
            {
                _actorRepository.Add(actor);
            });
        }

        public BaseResponse Edit(Actor actor)
        {
            return DoSuccess(() =>
            {
                _actorRepository.Edit(actor);
            });
        }

        public DataResponse<Actor> GetOne(int id)
        {
            return Do(() => new DataResponse<Actor>
            {
                Data = _actorRepository.GetOne(id)
            });
        }

        public BaseResponse Remove(int id)
        {
            return DoSuccess(() =>
            {
                _actorRepository.Remove(id);
            });
        }
    }
}

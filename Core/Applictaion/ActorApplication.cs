using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repo.AbstractRepo;
using Service.Abstract;

namespace Core.Applictaion
{
    internal class ActorApplication : BaseApplication, IActorApplication
    {
        private readonly IActorService _service;

        public ActorApplication(IFactory factory)
        {
            _service = factory.GetActorService;
        }

        public BaseResponse Add(Actor actor)
        {
            return DoSuccess(() =>
            {
                _service.Add(actor);
            });
        }

        public BaseResponse Edit(Actor actor)
        {
            return DoSuccess(() =>
            {
                _service.Edit(actor);
            });
        }

        public DataResponse<Actor> GetOne(int id)
        {
            return Do(() => new DataResponse<Actor>
            {
                Data = _service.GetOne(id)
            });
        }

        public BaseResponse Remove(int id)
        {
            return DoSuccess(() =>
            {
                _service.Remove(id);
            });
        }
    }
}

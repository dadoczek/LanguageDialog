using System;
using Contract.Responses;
using Core.AbstractApp;
using Model.Models;
using Repository.AbstractRepo;
using Core.Factories;

namespace Core.Applictaion
{
    internal class ActorApplication : BaseApplication, IActorApplication
    {
        private readonly IActorRepository _ActorRepository;

        public ActorApplication(IFactory factory)
        {
            _ActorRepository = factory.GetActorRepository;
        }

        public BaseResponse Add(Actor actor)
        {
            return DoSuccess(() =>
            {
                _ActorRepository.Add(actor);
            });
        }

        public BaseResponse Edit(Actor actor)
        {
            return DoSuccess(() =>
            {
                _ActorRepository.Edit(actor);
            });
        }

        public DataResponse<Actor> GetOne(int id)
        {
            return Do(() => new DataResponse<Actor>
            {
                Data = _ActorRepository.GetOne(id)
            });
        }

        public BaseResponse Remove(int Id)
        {
            return DoSuccess(() =>
            {
                _ActorRepository.Remove(Id);
            });
        }
    }
}

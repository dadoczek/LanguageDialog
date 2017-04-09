using System;
using Repo.AbstractRepo;
using Service.Helper;

namespace AplikacjaLingwistyczna.Tests.Helper
{
    public class FakeRepositoryProvider : IRepositoryProvider
    {
        private readonly IRepository _repository;
        public FakeRepositoryProvider(IRepository repository)
        {
            _repository = repository;
        }

        public T Do<T>(Func<IRepository, T> action)
        {
            return action(_repository);
        }

        public void Do(Action<IRepository> action)
        {
            action(_repository);
        }
    }
}

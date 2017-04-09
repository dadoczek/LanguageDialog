using System;
using Model.Context;
using Repo.AbstractRepo;
using Repo.Repositories;

namespace Service.Helper
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly string _connectionString;

        public RepositoryProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T Do<T>(Func<IRepository, T> action)
        {
            using (var context = new EfContext(_connectionString))
            {
                return action(new Repository(context));
            }
        }

        public void Do(Action<IRepository> action)
        {
            using (var context = new EfContext(_connectionString))
            {
                action(new Repository(context));
            }
        }
    }
}

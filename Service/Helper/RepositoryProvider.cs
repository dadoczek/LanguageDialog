using System;
using Model.Context;
using Repo.AbstractRepo;
using Repo.Repositories;

namespace Service.Helper
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly EfContext _context;

        public RepositoryProvider(string connectionString)
        {
            _context = new EfContext(connectionString);
        }

        public T Do<T>(Func<IRepository, T> action)
        {
                return action(new Repository(_context));
        }

        public void Do(Action<IRepository> action)
        {
                action(new Repository(_context));
        }
    }
}

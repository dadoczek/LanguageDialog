using System;
using Repo.AbstractRepo;

namespace Service.Helper
{
    public interface IRepositoryProvider
    {
        T Do<T>(Func<IRepository, T> action);
        void Do(Action<IRepository> action);
    }
}
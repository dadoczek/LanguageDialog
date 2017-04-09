using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repo.AbstractRepo
{
    public interface IRepository
    {
        void Add<T>(params T[] saveObjects) where T : class;
        void Edit<T>(params T[] saveObjects) where T : class;
        void Remove<T>(params T[] saveObjects) where T : class;
        void Remove<T>(params object[] keys) where T : class;
        T GetOne<T>(params object[] keys) where T : class;
        IEnumerable<T> GetCollection<T>(bool isTracing = false) where T : class;
        IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where, bool isTracing = false) where T : class;
    }
}
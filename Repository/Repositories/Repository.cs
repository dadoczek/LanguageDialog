using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Model.Context;
using Repo.AbstractRepo;

[assembly:InternalsVisibleTo("PlayDialogue.Core")]
[assembly:InternalsVisibleTo("AplikacjaLingwistyczna.Tests")]
namespace Repo.Repositories
{
    internal class Repository : IRepository
    {
        private readonly EfContext _context;

        public Repository(EfContext context)
        {
            _context = context;
        }

        public void Add<T>(params T[] saveObjects) where T : class
        {
            foreach (var saveObject in saveObjects)
            {
                _context.Entry(saveObject).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void Edit<T>(params T[] saveObjects) where T : class
        {
            foreach (var saveObject in saveObjects)
            {
                _context.Entry(saveObject).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Remove<T>(params T[] saveObjects) where T : class
        {
            foreach (var saveObject in saveObjects)
            {
                _context.Entry(saveObject).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Remove<T>(params object[] keys) where T : class 
        {
            var deleteObject = _context.Set<T>().Find(keys);
            _context.Set<T>().Remove(deleteObject);
        }

        public T GetOne<T>(params object[] keys) where  T: class
        {
            return _context.Set<T>().Find(keys);
        }

        public IEnumerable<T> GetCollection<T>(Expression<Func<T,bool>> where, bool isTracing = false ) where T : class
        {
            return isTracing ? _context.Set<T>().Where(where) : _context.Set<T>().Where(where).AsNoTracking();
        }

        public IEnumerable<T> GetCollection<T>(bool isTracing = false) where T : class
        {
            return isTracing ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }
    }
}
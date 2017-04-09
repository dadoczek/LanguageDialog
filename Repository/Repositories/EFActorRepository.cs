using System.Data.Entity;
using System.Linq;
using Model.Context;
using Model.Models;
using Repo.AbstractRepo;

namespace Repo.Repositories
{
    public class EfActorRepository : IActorRepository
    {
        private readonly EfContext _context;

        public EfActorRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
        }

        public void Edit(Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Actor GetOne(int id)
        {
            return _context.Actor.FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            var removeActor = _context.Actor.Find(id);
            _context.Actor.Remove(removeActor);
            _context.SaveChanges();
        }
    }
}

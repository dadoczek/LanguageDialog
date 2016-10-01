using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    public class EfActorRepository : IActorRepository
    {
        private readonly EfContext _context;

        public EfActorRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(Actor newActor)
        {
            _context.Actor.Add(newActor);
            _context.SaveChanges();
        }

        public void Edit(Actor editActor)
        {
            _context.Entry(editActor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Actor GetOne(int idActor)
        {
            return _context.Actor.FirstOrDefault(a => a.ActorId == idActor);
        }

        public void Remove(int removeId)
        {
            var removeActor = _context.Actor.Find(removeId);
            _context.Actor.Remove(removeActor);
            _context.SaveChanges();
        }
    }
}

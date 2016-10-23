using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System;
using System.Data.Entity;

namespace Repository.Repositories
{
    internal class EfFileRepository : IFileRepository
    {
        private readonly EfContext _context;

        public EfFileRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(AudioFile newTrack)
        {
            _context.AudioFile.Add(newTrack);
            _context.SaveChanges();
        }

        public void Edit(AudioFile editTrack)
        {
            _context.Entry(editTrack).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }
    }
}

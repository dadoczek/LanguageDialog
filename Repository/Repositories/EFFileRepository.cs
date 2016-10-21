using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System;

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
            throw new NotImplementedException();
        }

        public void Edit(AudioFile editTrack)
        {
            throw new NotImplementedException();
        }

        public void Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }
    }
}

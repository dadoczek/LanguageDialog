using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System;

namespace Repository.Repositories
{
    internal class EfTrackFileInfoRepository : ITrackFileInfoRepository
    {
        private readonly EfContext _context;

        public EfTrackFileInfoRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(TrackFileInfo newTrack)
        {
            throw new NotImplementedException();
        }

        public void Edit(TrackFileInfo editTrack)
        {
            throw new NotImplementedException();
        }

        public void Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }
    }
}

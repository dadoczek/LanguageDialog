using Model.Models;

namespace Repository.AbstractRepo
{
    public interface ITrackFileInfoRepository
    {
        void Add(TrackFileInfo newTrack);
        void Remove(int trackId, int dialogueId);
        void Edit(TrackFileInfo editTrack);
    }
}

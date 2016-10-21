using Model.Models;

namespace Repository.AbstractRepo
{
    public interface IFileRepository
    {
        void Add(AudioFile newTrack);
        void Remove(int trackId, int dialogueId);
        void Edit(AudioFile editTrack);
    }
}

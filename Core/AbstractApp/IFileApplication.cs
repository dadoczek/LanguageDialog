using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IFileApplication
    {
        BaseResponse Add(AudioFile newTrack);
        BaseResponse Remove(int trackId, int dialogueId);
        BaseResponse Edit(AudioFile editTrack);
    }
}

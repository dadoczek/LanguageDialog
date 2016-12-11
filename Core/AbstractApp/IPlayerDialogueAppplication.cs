using Contract.Responses;

namespace Core.AbstractApp
{
    public interface IPlayerDialogueAppplication
    {
        DataResponse<PlayResponse> GetPlayerModel(int idDialogue);
        DataResponse<PlayResponse> ReloadDialogue(PlayResponse playResponse);
        DataResponse<byte[]> GetAudioBytes(int audioId);
    }
}

using Contract.Responses;

namespace Core.AbstractApp
{
    public interface IPlayerDialogueAppplication
    {
        DataResponse<PlayResponse> GetPlayerModel(int idDialogue);
    }
}

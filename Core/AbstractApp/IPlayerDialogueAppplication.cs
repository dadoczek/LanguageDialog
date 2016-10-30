using Contract.Dtos;
using Contract.Responses;

namespace Core.AbstractApp
{
    public interface IPlayerDialogueAppplication
    {
        DataResponse<DialoguePlayDto> GetDialogue(int idDialogue);
    }
}

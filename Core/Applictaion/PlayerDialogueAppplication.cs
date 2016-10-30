using System;
using Contract.Dtos;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;

namespace Core.Applictaion
{
    internal class PlayerDialogueAppplication : BaseApplication, IPlayerDialogueAppplication
    {
        private Factory _factory;

        public PlayerDialogueAppplication(Factory factory)
        {
            _factory = factory;
        }

        public DataResponse<DialoguePlayDto> GetDialogue(int idDialogue)
        {
            return Do(() =>
            {
                var dialogue = _factory.GetDialogueRepository.GetOne(idDialogue);
                var result = new DialoguePlayDto
                {
                    Dialogue = dialogue,
                    VisableMyText = true,
                    VisableOtherText = true
                };
                return new DataResponse<DialoguePlayDto> { Data = result};
            });
            
        }
    }
}

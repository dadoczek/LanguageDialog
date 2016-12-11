﻿using System;
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

        public DataResponse<PlayResponse> GetPlayerModel(int idDialogue)
        {
            return Do(() =>
            {
                var dialogue = _factory.GetDialogueRepository.GetOne(idDialogue);
                var result = new PlayResponse
                {
                    Dialogue = dialogue,
                    Setting = new PlaySetting
                    {
                        VisableMyText = true,
                        VisableOtherText = true
                    }
                };
                return new DataResponse<PlayResponse> { Data = result};
            });
            
        }

        public DataResponse<PlayResponse> ReloadDialogue(PlayResponse playResponse)
        {
            return Do(() =>
            {
                playResponse.Dialogue = _factory.GetDialogueRepository.GetOne(playResponse.Dialogue.DialogueId);
                return new DataResponse<PlayResponse> { Data = playResponse };
            });

        }
    }
}

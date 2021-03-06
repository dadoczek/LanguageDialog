﻿using System.Linq;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Contract.Dtos;
using Service;
using Service.Abstract;

namespace Core.Applictaion
{
    internal class PlayerDialogueAppplication : BaseApplication, IPlayerDialogueAppplication
    {
        private readonly Factory _factory;
        private readonly IDialogueService _service;

        public PlayerDialogueAppplication(Factory factory)
        {
            _factory = factory;
            _service = factory.GetDialogueService;
        }

        public DataResponse<PlayResponse> GetPlayerModel(int idDialogue)
        {
            return Do(() =>
            {
                var dialogue = _service.GetOne(idDialogue);
                var result = new PlayResponse
                {
                    Dialogue = dialogue,
                    Setting = new PlaySetting
                    {
                        VisableMyText = true,
                        VisableOtherText = true,
                        IdNowPlay = -1,
                    }
                };
                return new DataResponse<PlayResponse> { Data = result};
            });
            
        }

        public DataResponse<PlayResponse> ReloadDialogue(PlayResponse playResponse)
        {
            return Do(() =>
            {
                playResponse.Dialogue = _service.GetOne(playResponse.Dialogue.Id);
                return new DataResponse<PlayResponse> { Data = playResponse };
            });

        }

        public DataResponse<byte[]> GetAudioBytes(int audioId)
        {
            return Do(() =>
            {
                var repo = _factory.GetTrackFileInfoRepository;

                var audioFile = repo.GetAudioFile(audioId);

                return new DataResponse<byte[]> { Data = audioFile.Data };
            });
        }

        public int PlayDialogue(int? nr, int idDialogue, int idActor)
        {

            var dialogue = _service.GetOne(idDialogue);
            bool isPlay;

            do
            {
                var issues = dialogue.GetIssues();
                if (nr < 0)
                {
                    nr = issues.OrderBy(i => i.IssueNr).First().IssueNr;
                }
                else
                {
                    var last = issues.OrderBy(i => i.IssueNr).Last().IssueNr;
                    if (nr >= last)
                    {
                        nr = issues.OrderBy(i => i.IssueNr).First().IssueNr;
                    }
                    else
                    {
                        nr++;
                    }
                }

                if (idActor < 0)
                {
                    isPlay = true;
                }
                else
                {
                    var actor = dialogue.Actors.FirstOrDefault(a => a.Id == idActor);
                    isPlay = actor.Issues.All(i => i.IssueNr != nr);
                }

            } while (!isPlay);

            return nr.Value;
        }
    }
}

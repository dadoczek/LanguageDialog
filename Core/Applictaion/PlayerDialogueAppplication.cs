using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using System.Linq;
using Contract.Dtos;

namespace Core.Applictaion
{
    internal class PlayerDialogueAppplication : BaseApplication, IPlayerDialogueAppplication
    {
        private readonly Factory _factory;

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
                playResponse.Dialogue = _factory.GetDialogueRepository.GetOne(playResponse.Dialogue.Id);
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
            var dialogue = _factory.GetDialogueRepository.GetOne(idDialogue);
            bool isPlay;

            do
            {
                if (nr < 0)
                {
                    nr = dialogue.Issues.OrderBy(i => i.IssueNr).First().IssueNr;
                }
                else
                {
                    var last = dialogue.Issues.OrderBy(i => i.IssueNr).Last().IssueNr;
                    if (nr >= last)
                    {
                        nr = dialogue.Issues.OrderBy(i => i.IssueNr).First().IssueNr;
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

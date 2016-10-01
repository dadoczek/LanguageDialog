using Core.AbstractRepoApplication;
using Repository.AbstractRepo;

namespace Core.Factory
{
    public interface IFactory
    {
        IDialogueRepository GetDialogueRepository { get; }
        ILanguageRepository GetLanguageRepository { get; }
        IActorRepository GetActorRepository { get; }
        IIssueRepository GetIssueRepository { get; }
        ITrackFileInfoRepository GetTrackFileInfoRepository { get; }
        IDialogueApplication GetDialogueApplication { get; }
    }
}

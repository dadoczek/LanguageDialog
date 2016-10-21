using Core.AbstractApp;
using Repository.AbstractRepo;

namespace Core.Factories
{
    public interface IFactory
    {
        IDialogueRepository GetDialogueRepository { get; }
        ILanguageRepository GetLanguageRepository { get; }
        IActorRepository GetActorRepository { get; }
        IIssueRepository GetIssueRepository { get; }
        IFileRepository GetTrackFileInfoRepository { get; }
        IDialogueApplication GetDialogueApplication { get; }
        ILanguageApplication GetLanguageApplication { get; }
        IActorApplication GetActorApplication { get; }
        IIssueApplication GetIssueApplication { get; }
    }
}

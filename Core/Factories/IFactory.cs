using Core.AbstractApp;
using Core.Applictaion;
using Repo.AbstractRepo;
using Service.Abstract;

namespace Core.Factories
{
    public interface IFactory
    {
        IActorService GetActorService { get; }
        IIssueService GetIssueService { get; }
        IFileRepository GetTrackFileInfoRepository { get; }
        IDialogueApplication GetDialogueApplication { get; }
        ILanguageApplication GetLanguageApplication { get; }
        IActorApplication GetActorApplication { get; }
        IIssueApplication GetIssueApplication { get; }
        IFileApplication GetFileApplication { get; }
        IViewLanguageApplication GetViewLanguageApplication { get; }
        IFileRepository GetFileRepository { get; }
        IPlayerDialogueAppplication GetPlayerDiaogueApplication { get; }
        IDialogueService GetDialogueService { get; }
        ILanguageService GetLanguageService { get; }
        IViewLanguageService GetViewLanguageService { get; }
    }
}

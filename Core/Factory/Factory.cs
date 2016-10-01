using Core.AbstractRepoApplication;
using Core.RepoApplictaion;
using Model.Context;
using Repository.AbstractRepo;
using Repository.Repositories;

namespace Core.Factory
{
    public class Factory : IFactory
    {
        public IDialogueRepository GetDialogueRepository => new EfDialogueRepository(new EfContext());

        public IActorRepository GetActorRepository => new EfActorRepository(new EfContext());

        public ILanguageRepository GetLanguageRepository => new EfLanguageRepository(new EfContext());

        public IIssueRepository GetIssueRepository => new EfIssueRepository(new EfContext());

        public ITrackFileInfoRepository GetTrackFileInfoRepository => new EfTrackFileInfoRepository(new EfContext());

        public IDialogueApplication GetDialogueApplication => new DialogueApplication(this);
    }
}

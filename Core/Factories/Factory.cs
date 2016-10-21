using Core.AbstractApp;
using Core.Applictaion;
using Model.Context;
using Repository.AbstractRepo;
using Repository.Repositories;

namespace Core.Factories
{
    public class Factory : IFactory
    {
        public IDialogueRepository GetDialogueRepository => new EfDialogueRepository(new EfContext());

        public IActorRepository GetActorRepository => new EfActorRepository(new EfContext());

        public ILanguageRepository GetLanguageRepository => new EfLanguageRepository(new EfContext());

        public IIssueRepository GetIssueRepository => new EfIssueRepository(new EfContext());

        public IFileRepository GetTrackFileInfoRepository => new EfFileRepository(new EfContext());

        public IDialogueApplication GetDialogueApplication => new DialogueApplication(this);

        public ILanguageApplication GetLanguageApplication => new LanguageApplication(this);

        public IActorApplication GetActorApplication => new ActorApplication(this);

        public IIssueApplication GetIssueApplication => new IssueApplication(this);
    }
}

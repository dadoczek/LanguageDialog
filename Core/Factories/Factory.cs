using Core.AbstractApp;
using Core.Applictaion;
using Model.Context;
using Repo.AbstractRepo;
using Repo.Repositories;
using Service;
using Service.Abstract;
using Service.Helper;

namespace Core.Factories
{
    public class Factory : IFactory
    {
        private readonly IRepositoryProvider _provider;
        private const string Database = "Aplikacja_Lingwistyczna_1";

        public Factory()
        {
            _provider = new RepositoryProvider(Database);
        }

        public IActorService GetActorService => new ActorService(_provider);

        public IIssueService GetIssueService => new IssueService(_provider);

        public IFileRepository GetTrackFileInfoRepository => new EfFileRepository(new EfContext());

        public IDialogueApplication GetDialogueApplication => new DialogueApplication(this);

        public ILanguageApplication GetLanguageApplication => new LanguageApplication(this);

        public IActorApplication GetActorApplication => new ActorApplication(this);

        public IIssueApplication GetIssueApplication => new IssueApplication(this);
        public IFileApplication GetFileApplication => new FileApplication(this);

        public IFileRepository GetFileRepository => new EfFileRepository(new EfContext());

        public IPlayerDialogueAppplication GetPlayerDiaogueApplication => new PlayerDialogueAppplication(this);
        public IDialogueService GetDialogueService => new DialogueService(_provider);
        public ILanguageService GetLanguageService => new LanguageService(_provider);
    }
}

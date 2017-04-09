using Core.Factories;
using Repo.AbstractRepo;

namespace AplikacjaLingwistyczna.Tests.Fake
{
    public class FactoryFake : Factory
    {
        public override IDialogueRepository GetDialogueRepository => new FakeDialogueRepository();
    }
}

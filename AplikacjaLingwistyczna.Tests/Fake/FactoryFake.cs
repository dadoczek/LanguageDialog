using Core.Factories;
using Repository.AbstractRepo;

namespace AplikacjaLingwistyczna.Tests.Fake
{
    public class FactoryFake : Factory
    {
        public override IDialogueRepository GetDialogueRepository => new FakeDialogueRepository();
    }
}

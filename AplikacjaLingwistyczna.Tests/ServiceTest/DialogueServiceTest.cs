using AplikacjaLingwistyczna.Tests.Helper;
using Model.Models;
using NSubstitute;
using Ploeh.AutoFixture.Xunit2;
using Repo.AbstractRepo;
using Service;
using Service.Helper;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.ServiceTest
{
    public class DialogueServiceTest
    {
        private readonly IRepositoryProvider _provider;
        private readonly DialogueService _service;
        private IRepository _repository;

        public DialogueServiceTest()
        {
            _repository = Substitute.For<IRepository>();

            _provider = new FakeRepositoryProvider(_repository);

            _service = new DialogueService(_provider);
        }

        [Theory,AutoData]
        public void AddTest(int id,string name)
        {
            var dialogue = new Dialogue
            {
                Name = name,
                Id = id,
            };
            _service.Add(dialogue);
            _repository.Received(1).Add(Arg.Is<Dialogue>(d => d.Name == name && d.Id == id));
        }

        [Theory, AutoData]
        public void EditTest(int id, string name)
        {
            var dialogue = new Dialogue
            {
                Name = name,
                Id = id,
            };
            _service.Edit(dialogue);
            _repository.Received(1).Edit(Arg.Is<Dialogue>(d => d.Name == name && d.Id == id));
        }

        [Theory,AutoData]
        public void GetAllTest(uint lenght)
        {
            var dialogues = new Dialogue[lenght];

            _repository.GetCollection<Dialogue>().Returns(dialogues);

            var result = _service.GetAll();

            _repository.Received(1).GetCollection<Dialogue>();
            Assert.Equal(result.Count, (int)lenght);
        }
    }
}

using System;
using AplikacjaLingwistyczna.Tests.Helper;
using Model.Models;
using NSubstitute;
using Ploeh.AutoFixture.Xunit2;
using Repo.AbstractRepo;
using Service;
using Service.Helper;
using System.Linq;
using Model.EnumType;
using Xunit;
using static AplikacjaLingwistyczna.Tests.Helper.DataProvider;

namespace AplikacjaLingwistyczna.Tests.ServiceTest
{
    public class DialogueServiceTest
    {
        private readonly DialogueService _service;
        private readonly IRepository _repository;

        public DialogueServiceTest()
        {
            _repository = Substitute.For<IRepository>();

            IRepositoryProvider provider = new FakeRepositoryProvider(_repository);

            _service = new DialogueService(provider);
        }

        [Theory, AutoData]
        public void AddTest(int id, string name)
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

        [Theory, AutoData]
        public void GetAllTest(uint lenght)
        {
            var dialogues = new Dialogue[lenght];

            _repository.GetCollection<Dialogue>().Returns(dialogues);

            var result = _service.GetAll();

            _repository.Received(1).GetCollection<Dialogue>();
            Assert.Equal(result.Count, (int) lenght);
        }

        [Fact]
        public void FilterQuery_If_user_id_is_null_get_only_publish_dialogue()
        {
            var dialogues = GetDialogues();
            string userId = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = dialogues.Where(_service.FilterQuery(userId)).ToArray();

            Assert.Equal(result.Length, 2);
            Assert.Equal(result[0].Name, NameDialogue4);
            Assert.Equal(result[0].Status, DialogueStatus.Pubish);
            Assert.Equal(result[0].AutorId, UserId1);
            Assert.Equal(result[1].Name, NameDialogue4);
            Assert.Equal(result[1].Status, DialogueStatus.Pubish);
            Assert.Equal(result[1].AutorId, UserId2);
        }

        [Fact]
        public void FilterQuery_If_user_id_is_exist_get_only_publish_and_edit_dialogue_from_select_user()
        {
            var dialogues = GetDialogues();

            var result = dialogues.Where(_service.FilterQuery(UserId1)).ToArray();

            Assert.Equal(result.Length, 2);
            Assert.Equal(result[0].Name, NameDialogue1);
            Assert.Equal(result[0].Status, DialogueStatus.Edit);
            Assert.Equal(result[0].AutorId, UserId1);
            Assert.Equal(result[1].Name, NameDialogue4);
            Assert.Equal(result[1].Status, DialogueStatus.Pubish);
            Assert.Equal(result[1].AutorId, UserId1);
            Assert.Null(result.FirstOrDefault(d => d.AutorId == UserId2));
        }

        //[Theory]
        //[InlineData(NameDialogue1)]
        //[InlineData(NameDialogue1)]
        //public void FilterQuery_If_Name_filter_is_exist_get_only_dialoge_when_contains_filter_name(string nameFilter)
        //{
        //    var dialogues = GetDialogues();

        //    var result = dialogues.Where(_service.FilterQuery(UserId1)).ToArray();

        //    Assert.Equal(result.Length, 2);
        //    Assert.Equal(result[0].Name, NameDialogue1);
        //    Assert.Equal(result[0].Status, DialogueStatus.Edit);
        //    Assert.Equal(result[0].AutorId, UserId1);
        //    Assert.Equal(result[1].Name, NameDialogue4);
        //    Assert.Equal(result[1].Status, DialogueStatus.Pubish);
        //    Assert.Equal(result[1].AutorId, UserId1);
        //    Assert.Null(result.FirstOrDefault(d => d.AutorId == UserId2));
        //}
    }
}

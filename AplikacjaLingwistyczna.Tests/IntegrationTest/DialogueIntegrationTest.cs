using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using AplikacjaLingwistyczna.Controllers;
using AplikacjaLingwistyczna.Tests.Fake;
using Contract.Dtos;
using Model.EnumType;
using Model.Models;
using Newtonsoft.Json;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.IntegrationTest
{
    public class DialogueIntegrationTest
    {
        public DialogueIntegrationTest()
        {
            FakeDialogueRepository.Dialogues.Clear();
        }

        [Fact]
        public void Get_All_Dialogue_Test()
        {
            FakeDialogueRepository.Dialogues.Add(new Dialogue
            {
                DialogueId = 1,
                Name = "Dialogue 1"
            });

            var factory = new FactoryFake();
            var controller = new DialogueController(factory);
            var serializer = new JavaScriptSerializer();

            var result = controller.GetAll() as ViewResult;


            Assert.NotNull(result);

            var json = serializer.Serialize(result.Model);
            var model = serializer.Deserialize<List<Dialogue>>(json);

            Assert.True(model.Count == 1);
            Assert.True(model[0].DialogueId == 1);
            Assert.True(model[0].Name == "Dialogue 1");
        }

        [Fact]
        public void Get_Page_Dialogue_Test()
        {
            FakeDialogueRepository.Dialogues.AddRange(new[]
            {
                new Dialogue
                {
                    DialogueId = 1,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
                new Dialogue
                {
                    DialogueId = 2,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
                new Dialogue
                {
                    DialogueId = 3,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
                new Dialogue
                {
                    DialogueId = 4,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
                new Dialogue
                {
                    DialogueId = 5,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
                new Dialogue
                {
                    DialogueId = 6,
                    Name = "Dialogue 1",
                    Status = DialogueStatus.Pubish
                },
            });

            var factory = new FactoryFake();
            var controller = new DialogueController(factory);
            var serializer = new JavaScriptSerializer();
            var sort = new DialogueSortDto
            {
                SizePage = 5,
            };

            var result = controller.GetPage(1,sort) as ViewResult;


            Assert.NotNull(result);

            var json = serializer.Serialize(result.Model);
            var model = serializer.Deserialize<DialoguePageDto>(json);

            Assert.Equal(model.Dialogues.Count, 5);
            Assert.True(model.Paging.IsNextPage);
            Assert.False(model.Paging.IsPreviousPage);
        }
    }
}

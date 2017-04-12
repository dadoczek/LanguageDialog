using AplikacjaLingwistyczna.Tests.Helper;
using Model.Context;
using Model.EnumType;
using Repo.Repositories;
using Service;
using Service.Helper;
using System.Linq;
using Xunit;
using static AplikacjaLingwistyczna.Tests.Helper.DataProvider;

namespace AplikacjaLingwistyczna.Tests.ServiceTest
{
    public class DialogueServiceWithDatabaseTest
    {
        private readonly DialogueService _service;
        private readonly EfContext _context;

        public DialogueServiceWithDatabaseTest()
        {
            SetDatabaseEntity();
            _context = new EfContext(Database);

            IRepositoryProvider provider = new FakeRepositoryProvider(new Repository(_context));

            _service = new DialogueService(provider);
        }

        [Fact]
        public void FilterQuery_If_user_id_is_null_get_only_publish_dialogue()
        {
            string userId = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = _context.Dialogue.Where(_service.FilterQuery(userId)).ToArray();

            Assert.Equal(result.Length, 2);
            Assert.Equal(result[0].Name, NameDialogue4);
            Assert.Equal(result[0].Status, DialogueStatus.Pubish);
            Assert.Equal(result[0].Autor.UserName, UserName1);
            Assert.Equal(result[1].Name, NameDialogue4);
            Assert.Equal(result[1].Status, DialogueStatus.Pubish);
            Assert.Equal(result[1].Autor.UserName, UserName2);
        }

        [Fact]
        public void FilterQuery_If_user_id_is_exist_get_only_publish_and_edit_dialogue_from_select_user()
        {
            var userId = _context.Users.First().Id;
            var result = _context.Dialogue.Where(_service.FilterQuery(userId)).ToArray();

            Assert.Equal(result.Length, 2);
            Assert.Equal(result[0].Name, NameDialogue1);
            Assert.Equal(result[0].Status, DialogueStatus.Edit);
            Assert.Equal(result[0].Autor.UserName, UserName1);
            Assert.Equal(result[1].Name, NameDialogue4);
            Assert.Equal(result[1].Status, DialogueStatus.Pubish);
            Assert.Equal(result[1].Autor.UserName, UserName1);
            Assert.Null(result.FirstOrDefault(d => d.Autor.UserName == UserName2));
        }

        [Theory]
        [InlineData(NameDialogue1)]
        [InlineData("DIALOGUE_1")]
        [InlineData("_1")]
        public void FilterQuery_If_Name_filter_is_exist_get_only_dialoge_when_contains_filter_name(string nameFilter)
        {
            var userId = _context.Users.First().Id;
            var result = _context.Dialogue.Where(_service.FilterQuery(userId, nameFilter)).ToArray();

            Assert.Equal(result.Length, 1);
            Assert.Equal(result[0].Name, NameDialogue1);
            Assert.Equal(result[0].Status, DialogueStatus.Edit);
            Assert.Equal(result[0].Autor.UserName, UserName1);
            Assert.Null(result.FirstOrDefault(d => d.Autor.UserName == UserName2));
        }

        [Fact]
        public void FilterQuery_If_IdLanguage_filter_is_exist_get_only_dialoge_selected_Language()
        {
            var languageId = _context.Language.First().Id;

            var result = _context.Dialogue.Where(_service.FilterQuery(languageId: languageId)).ToArray();

            Assert.Equal(result.Length, 1);
            Assert.Equal(result[0].Name, NameDialogue4);
            Assert.Equal(result[0].Status, DialogueStatus.Pubish);
            Assert.Equal(result[0].Autor.UserName, UserName1);
            Assert.Equal(result[0].Language.Name, LanguageName1);
            Assert.Null(result.FirstOrDefault(d => d.Autor.UserName == UserName2));
            Assert.Null(result.FirstOrDefault(d => d.Language.Name == LanguageName2));
        }
    }
}

using AplikacjaLingwistyczna.Tests.Helper;
using Service;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.EntityTest
{
    public class DialogueServiceEntityTest : EntityBaseTest
    {
        private readonly DialogueService _service;

        public DialogueServiceEntityTest()
        {
         //   _service = new DialogueService(TestDb2);
        }

        [Fact]
        public void GetOneTest_element_is_found()
        {
            const int dialogueId = 1;
            const int languageId = 1;
            const string dialogueName = "Dialogue1";
            const string languageName = "Polski";

         //   var result = _service.GetOne(dialogueId);

            //Assert.Equal(result.Id, dialogueId);
            //Assert.Equal(result.Name, dialogueName);
            //Assert.Equal(result.Id, languageId);
            //Assert.NotNull(result.Language);
            //Assert.Equal(result.Language.Id, languageId);
            //Assert.Equal(result.Language.Name, languageName);
        }
    }
}

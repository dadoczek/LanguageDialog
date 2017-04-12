using System.Collections.Generic;
using System.Linq;
using Model.Context;
using Model.EnumType;
using Model.Models;

namespace AplikacjaLingwistyczna.Tests.Helper
{
    public static class DataProvider
    {
        public const string NameDialogue1 = "Dialogue_1";
        public const DialogueStatus StatusDialogue1 = DialogueStatus.Edit;

        public const string NameDialogue2 = "Dialogue_2";
        public const DialogueStatus StatusDialogue2 = DialogueStatus.Archive;

        public const string NameDialogue3 = "Dialogue_3";
        public const DialogueStatus StatusDialogue3 = DialogueStatus.Locked;

        public const string NameDialogue4 = "Dialogue_4";
        public const DialogueStatus StatusDialogue4 = DialogueStatus.Pubish;

        public const string UserId1 = "1";
        public const string UserName1 = "User1@wp.pl";
        public const string UserId2 = "2";
        public const string UserName2 = "User2@wp.pl";

        public const int LanguageId1 = 1;
        public const string LanguageName1 = "Polski";
        public const int LanguageId2 = 2;
        public const string LanguageName2 = "Angielski";

        public const string Database = "DatabaseWithEntities";

        public static IEnumerable<Dialogue> GetDialogues()
        {
            return new List<Dialogue>
            {
                //user 1
                new Dialogue
                {
                    Status = StatusDialogue1,
                    Name = NameDialogue1,
                    AutorId = UserId1,
                    LanguageId = LanguageId1,
                },
                new Dialogue
                {
                    Status = StatusDialogue2,
                    Name = NameDialogue2,
                    AutorId = UserId1,
                    LanguageId = LanguageId1,
                },
                new Dialogue
                {
                    Status = StatusDialogue3,
                    Name = NameDialogue3,
                    AutorId = UserId1,
                    LanguageId = LanguageId1,
                },
                new Dialogue
                {
                    Status = StatusDialogue4,
                    Name = NameDialogue4,
                    AutorId = UserId1,
                    LanguageId = LanguageId1,
                },
                //user 2
                new Dialogue
                {
                    Status = StatusDialogue1,
                    Name = NameDialogue1,
                    AutorId = UserId2,
                    LanguageId = LanguageId2,
                },
                new Dialogue
                {
                    Status = StatusDialogue2,
                    Name = NameDialogue2,
                    AutorId = UserId2,
                    LanguageId = LanguageId2,
                },
                new Dialogue
                {
                    Status = StatusDialogue3,
                    Name = NameDialogue3,
                    AutorId = UserId2,
                    LanguageId = LanguageId2,
                },
                new Dialogue
                {
                    Status = StatusDialogue4,
                    Name = NameDialogue4,
                    AutorId = UserId2,
                    LanguageId = LanguageId2,
                },
            };
        }

        public static void SetDatabaseEntity()
        {
            var context = new EfContext(Database);

            if (!context.Language.Any())
            {
                context.Language.Add(new Language {Name = LanguageName1});
                context.Language.Add(new Language {Name = LanguageName2});
                context.SaveChanges();
            }

            var languagesId = context.Language.Select(l => l.Id).ToArray();

            if (!context.Users.Any())
            {
                context.Users.Add(new User { Email = UserName1, PasswordHash = UserName1, UserName = UserName1});
                context.Users.Add(new User { Email = UserName2, PasswordHash = UserName1, UserName = UserName2});
                context.SaveChanges();
            }

            var usersId = context.Users.Select(l => l.Id).ToArray();

            if (!context.Dialogue.Any())
            {
                for (var i = 0; i < 2; i++)
                {
                    context.Dialogue.Add(new Dialogue { Name = NameDialogue1,AutorId = usersId[i], LanguageId = languagesId[i], Status = DialogueStatus.Edit});
                    context.Dialogue.Add(new Dialogue { Name = NameDialogue2, AutorId = usersId[i], LanguageId = languagesId[i], Status = DialogueStatus.Archive });
                    context.Dialogue.Add(new Dialogue { Name = NameDialogue3, AutorId = usersId[i], LanguageId = languagesId[i], Status = DialogueStatus.Locked });
                    context.Dialogue.Add(new Dialogue { Name = NameDialogue4, AutorId = usersId[i], LanguageId = languagesId[i], Status = DialogueStatus.Pubish });
                    context.SaveChanges();
                }
            }
        }
    }
}

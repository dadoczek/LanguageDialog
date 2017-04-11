using System.Collections.Generic;
using Model.EnumType;
using Model.Models;

namespace AplikacjaLingwistyczna.Tests.Helper
{
    public static class DataProvider
    {
        public static IEnumerable<Dialogue> GetDialogues()
        {
            return new List<Dialogue>
            {
                //user 1
                new Dialogue
                {
                    Status = StatusDialogue1,
                    Name = NameDialogue1,
                    AutorId = UserId1
                },
                new Dialogue
                {
                    Status = StatusDialogue2,
                    Name = NameDialogue2,
                    AutorId = UserId1
                },
                new Dialogue
                {
                    Status = StatusDialogue3,
                    Name = NameDialogue3,
                    AutorId = UserId1
                },
                new Dialogue
                {
                    Status = StatusDialogue4,
                    Name = NameDialogue4,
                    AutorId = UserId1
                },
                //user 2
                new Dialogue
                {
                    Status = StatusDialogue1,
                    Name = NameDialogue1,
                    AutorId = UserId2
                },
                new Dialogue
                {
                    Status = StatusDialogue2,
                    Name = NameDialogue2,
                    AutorId = UserId2
                },
                new Dialogue
                {
                    Status = StatusDialogue3,
                    Name = NameDialogue3,
                    AutorId = UserId2
                },
                new Dialogue
                {
                    Status = StatusDialogue4,
                    Name = NameDialogue4,
                    AutorId = UserId2
                },
            };
        }

        public const string NameDialogue1 = "Dialogue_1";
        public const DialogueStatus StatusDialogue1 = DialogueStatus.Edit;

        public const string NameDialogue2 = "Dialogue_2";
        public const DialogueStatus StatusDialogue2 = DialogueStatus.Archive;

        public const string NameDialogue3 = "Dialogue_3";
        public const DialogueStatus StatusDialogue3 = DialogueStatus.Locked;

        public const string NameDialogue4 = "Dialogue_4";
        public const DialogueStatus StatusDialogue4 = DialogueStatus.Pubish;

        public const string UserId1 = "1";
        public const string UserId2 = "2";
    }
}

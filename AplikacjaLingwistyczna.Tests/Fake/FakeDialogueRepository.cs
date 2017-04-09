using Model.Models;
using System.Collections.Generic;
using System.Linq;
using Repo.AbstractRepo;

namespace AplikacjaLingwistyczna.Tests.Fake
{
    public class FakeDialogueRepository : IDialogueRepository
    {
        public static int Couter = 0;

        public static List<Dialogue> Dialogues = new List<Dialogue>();

        private static int CouterId()
        {
            Couter++;
            return Couter;
        }

        public void Add(Dialogue dialogue)
        {
            dialogue.Id = CouterId();
            Dialogues.Add(dialogue);
        }

        public void Remove(int id)
        {
            var dialogue = Dialogues.FirstOrDefault(d => d.Id == id);
            Dialogues.Remove(dialogue);
        }

        public IQueryable<Dialogue> GetAll()
        {
            return Dialogues.AsQueryable();
        }

        public Dialogue GetOne(int id)
        {
            return Dialogues.FirstOrDefault(d => d.Id == id);
        }

        public void Edit(Dialogue dialogue)
        {
            
        }
    }
}
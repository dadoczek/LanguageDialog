using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using Model.Context;
using Model.EnumType;
using Model.Models;
using Repo.AbstractRepo;

[assembly: InternalsVisibleTo("Core")]
namespace Repo.Repositories
{
    internal class EfDialogueRepository : IDialogueRepository
    {
        private readonly EfContext _context;

        public EfDialogueRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(Dialogue dialogue)
        {
            dialogue.Status = DialogueStatus.Edit;
            _context.Dialogue.Add(dialogue);
            _context.SaveChanges();
        }

        public void Edit(Dialogue dialogue)
        {
            _context.Entry(dialogue).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<Dialogue> GetAll()
        {
            return _context.Dialogue.AsNoTracking();
        }

        public Dialogue GetOne(int id)
        {
            return _context.Dialogue.FirstOrDefault(d => d.Id == id);
        }

        public void Remove(int id)
        {
            var removeDialogue = _context.Dialogue.First(d => d.Id == id);

            var audioFile = removeDialogue.Issues.Select(i => i.AudioFile)
                .Where(a => a != null).ToList();
            if (audioFile.Any())
                _context.AudioFile.RemoveRange(audioFile);

            _context.Issue.RemoveRange(removeDialogue.Issues);
            _context.Actor.RemoveRange(removeDialogue.Actors);

            _context.Dialogue.Remove(removeDialogue);
            _context.SaveChanges();
        }
    }
}

using Contract.Dtos;
using Contract.Params;
using Model.Context;
using Model.EnumType;
using Model.Models;
using Repository.AbstractRepo;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Core")]
namespace Repository.Repositories
{
    internal class EfDialogueRepository : IDialogueRepository
    {
        private readonly EfContext _context;

        public EfDialogueRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(Dialogue addDialogue)
        {
            addDialogue.Status = DialogueStatus.Edit;
            _context.Dialogue.Add(addDialogue);
            _context.SaveChanges();
        }

        public void Edit(Dialogue editDialogue)
        {
            _context.Entry(editDialogue).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<Dialogue> GetAll()
        {
            return _context.Dialogue.AsNoTracking();
        }

        public Dialogue GetOne(int dialogueId)
        {
            return _context.Dialogue.FirstOrDefault(d => d.DialogueId == dialogueId);
        }

        public DialoguePageDto GetPage(DialoguePageParams @params)
        {
            if (@params.Sort == null)
            {
                @params.Sort = new DialogueSortDto
                {
                    SizePage = 2
                };
            }
            IQueryable<Dialogue> elements = _context.Set<Dialogue>();

            if (!string.IsNullOrWhiteSpace(@params.Sort.Name))
                elements = elements.Where(d => d.Name.ToLower().Contains(@params.Sort.Name.ToLower()));

            var countElement = elements.Count();

            var pagingSystem = @params.Sort.SizePage != null 
                ? new PagingDto(@params.Page, countElement, (int)@params.Sort.SizePage) 
                : new PagingDto(@params.Page, countElement);

            elements = elements
                .OrderBy(d => d.Name)
                .Skip(pagingSystem.SkipElement())
                .Take(pagingSystem.SizePage)
                .AsNoTracking();

            return new DialoguePageDto
            {
                Dialogues = elements,
                Paging = pagingSystem
            };
        }

        public void Remove(int removeId)
        {
            var removeDialogue = _context.Dialogue.First(d => d.DialogueId == removeId);
            _context.Dialogue.Remove(removeDialogue);
            _context.SaveChanges();
        }
    }
}

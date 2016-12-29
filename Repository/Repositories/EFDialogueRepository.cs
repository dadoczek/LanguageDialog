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
            return _context.Dialogue.FirstOrDefault(d => d.DialogueId == id);
        }

        public DialoguePageDto GetPage(DialoguePageParams @params)
        {
            IQueryable<Dialogue> elements = _context.Set<Dialogue>();

            elements = QueryPageDialogue(@params, elements);

            return GetDialogeDto(@params, elements);
        }

        private DialoguePageDto GetDialogeDto(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
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

        private IQueryable<Dialogue> QueryPageDialogue(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
            if (@params.Sort.LanguageId.HasValue)
            {
                elements = elements.Where(d => d.LanguageId == @params.Sort.LanguageId);
            }

            elements = elements.Where(d => d.Status == DialogueStatus.Pubish);

            if (!string.IsNullOrWhiteSpace(@params.Sort.Name))
                elements = elements.Where(d => d.Name.ToLower().Contains(@params.Sort.Name.ToLower()));

            return elements;
        }

        public DialoguePageDto GetMyDialoguePage(DialoguePageParams @params)
        {
            IQueryable<Dialogue> elements = _context.Set<Dialogue>();

            elements = QueryMyPageDialogue(@params, elements);

            return GetDialogeDto(@params, elements);
        }

        private IQueryable<Dialogue> QueryMyPageDialogue(DialoguePageParams @params, IQueryable<Dialogue> elements)
        {
            if (@params.Sort.LanguageId.HasValue)
            {
                elements = elements.Where(d => d.LanguageId == @params.Sort.LanguageId);
            }
            elements = elements.Where(d => d.AutorId == @params.Sort.IdUser);

            elements = elements.Where(d => d.Status == DialogueStatus.Pubish || d.Status == DialogueStatus.Edit);

            if (!string.IsNullOrWhiteSpace(@params.Sort.Name))
                elements = elements.Where(d => d.Name.ToLower().Contains(@params.Sort.Name.ToLower()));

            return elements;
        }

        public void Remove(int id)
        {
            var removeDialogue = _context.Dialogue.First(d => d.DialogueId == id);
            _context.Dialogue.Remove(removeDialogue);
            _context.SaveChanges();
        }
    }
}

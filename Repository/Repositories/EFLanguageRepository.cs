using Contract.Dtos;
using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    internal class EfLanguageRepository : ILanguageRepository
    {
        const int PageSize = 10;

        private readonly EfContext _context;

        public EfLanguageRepository(EfContext context)
        {
            _context = context;
        }

        public IQueryable<Language> GetAll()
        {
            return _context.Language.AsQueryable();
        }

        public IQueryable<Language> GetMainAll()
        {
            return _context.Language.Where(language => language.ParentId == null).AsNoTracking();
        }

        public LanguagePageDto GetPage(int page)
        {
            var elementCount = _context.Language.Count(language => language.ParentId == null);

            var pagingSystem = new PagingDto(page, elementCount, PageSize);

            var elements = _context.Language
                .Where(language => language.ParentId == null)
                .OrderBy(language => language.Name)
                .Skip(pagingSystem.SkipElement())
                .Take(pagingSystem.SizePage)
                .AsNoTracking();

            return new LanguagePageDto
            {
                Language = elements,
                Paging = pagingSystem
            };
        }

        public Language GetOne(int id)
        {
            return _context.Language.Find(id);
        }

        public void Remove(int id)
        {
            var language = _context.Language.First(lang => lang.LanguageId == id);
            _context.Language.Remove(language);
            _context.SaveChanges();
        }

        public void Add(Language language)
        {
            if (!ElementNoExist(language)) return;
            _context.Language.Add(language);
            _context.SaveChanges();
        }

        private bool ElementNoExist(Language language)
        {
            if (language.ParentId == null)
            {
                if (_context.Language.Where(lang => lang.ParentId == null).FirstOrDefault(lang => lang.Name == language.Name) != null)
                    return false;
            }
            else
            {
                if (_context.Language.FirstOrDefault(lang => lang.ParentId == language.ParentId && lang.Name == language.Name) != null)
                    return false;
            }
            return true;
        }

        public void Edit(Language language)
        {
            _context.Entry(language).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}

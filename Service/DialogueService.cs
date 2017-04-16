using Model.EnumType;
using Model.Models;
using Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Contract.Params;
using Contract.WebModel;
using Service.Abstract;

[assembly:InternalsVisibleTo("AplikacjaLingwistyczna.Tests")]
namespace Service
{
    public class DialogueService : EntityBaseService, IDialogueService
    {
        public DialogueService(IRepositoryProvider provider) : base(provider) {}


        public void Add(Dialogue dialogue)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Add(dialogue);
            });
        }

        public void Edit(Dialogue dialogue)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Edit(dialogue);
            });
        }

        public Dialogue GetOne(int id)
        {
            return RepositoryProvider.Do(repo => repo.GetOne<Dialogue>(id));
        }

        public void Remove(int id)
        {
            RepositoryProvider.Do(repo => repo.Remove<Dialogue>(id));
        }

        public ICollection<Dialogue> GetAll()
        {
            return RepositoryProvider.Do(repo => repo.GetCollection<Dialogue>().ToList());
        }

        internal Func<Dialogue, bool> FilterQuery(string userId = null, string nameFilter = null, int? languageId = null)
        {
            if (userId == null)
            {
                return d => d.Status == DialogueStatus.Pubish && NameFilter(d, nameFilter) && LanguageFilter(d,languageId);
            }
            else
            {
                return d => AutorFilter(d, userId) && NameFilter(d, nameFilter) && LanguageFilter(d, languageId);
            }
        }

        private static bool NameFilter(Dialogue dialogue, string nameFilter)
        {
            return string.IsNullOrWhiteSpace(nameFilter) || dialogue.Name.ToLower().Contains(nameFilter.ToLower());
        }

        private static bool AutorFilter(Dialogue dialogue, string autorId)
        {
            return dialogue.AutorId == autorId && 
                (dialogue.Status == DialogueStatus.Pubish || dialogue.Status == DialogueStatus.Edit);
        }

        private static bool LanguageFilter(Dialogue dialogue, int? languageId)
        {
            if(languageId != null)
                return dialogue.LanguageId == languageId;
            return true;
        }

        public PageData<Dialogue> GetPage(DialoguePageParams @params)
        {
            return RepositoryProvider.Do(repo =>
            {
                var data = repo.GetCollection<Dialogue>()
                .Where(FilterQuery(@params.IdUser,@params.Name, @params.LanguageId));

                var pageData = PagingService.GetPaging(data,@params.Page, @params.SizePage);

                return pageData;
            });
        }
    }
}

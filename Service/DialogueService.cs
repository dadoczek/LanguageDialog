using Model.EnumType;
using Model.Models;
using Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("AplikacjaLingwistyczna.Tests")]
namespace Service
{
    public class DialogueService : EntityBaseService
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
    }
}

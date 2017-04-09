using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Service.Helper;

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
    }
}

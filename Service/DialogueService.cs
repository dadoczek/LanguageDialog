using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Model.EnumType;
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

        public Func<Dialogue, bool> FilterQuery(string userId)
        {
            if (userId == null)
            {
                return d => d.Status == DialogueStatus.Pubish;
            }
            else
            {
                return d => d.AutorId == userId && (d.Status == DialogueStatus.Pubish || d.Status == DialogueStatus.Edit);
            }
        }
    }
}

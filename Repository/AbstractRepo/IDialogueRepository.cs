using System.Linq;
using Model.Models;

namespace Repo.AbstractRepo
{
    public interface IDialogueRepository
    {
        void Add(Dialogue dialogue);

        void Remove(int id);

        void Edit(Dialogue dialogue);

        IQueryable<Dialogue> GetAll();

        Dialogue GetOne(int id);
    }
}

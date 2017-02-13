using Model.Models;
using System.Linq;

namespace Repository.AbstractRepo
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

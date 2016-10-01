using Contract.Dtos;
using Contract.Params;
using Model.Models;
using System.Linq;

namespace Repository.AbstractRepo
{
    public interface IDialogueRepository
    {
        void Add(Dialogue addDialogue);

        void Remove(int removeId);

        void Edit(Dialogue editDialogue);

        IQueryable<Dialogue> GetAll();

        Dialogue GetOne(int dialogueId);

        DialoguePageDto GetPage(DialoguePageParams @params);
    }
}

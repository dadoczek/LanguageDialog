using Model.Models;

namespace Repository.AbstractRepo
{
    public interface IIssueRepository
    {
        void Add(Issue newIssue);
        void Edit(Issue editIssue);
        void Remove(int dialogueId, int positionId);
        void ChangePosition(int dialogueId, int positionId, int direction);
        Issue GetOne(int positionId, int idDialogue);
    }
}

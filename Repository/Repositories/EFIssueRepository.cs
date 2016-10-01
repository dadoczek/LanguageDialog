using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    internal class EfIssueRepository : IIssueRepository
    {
        private readonly EfContext _context;
        private IQueryable<Issue> _elements;

        public EfIssueRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(Issue newIssue)
        {
            var position = _context.Issue.Count(issue => issue.DialogueId == newIssue.DialogueId) + 1;
            newIssue.IssueNr = position;
            _context.Issue.Add(newIssue);
            _context.SaveChanges();
        }

        public Issue GetOne(int positionId, int idDialogue)
        {
            return _context.Issue.FirstOrDefault(issue => issue.DialogueId == idDialogue && issue.IssueNr == positionId);
        }

        public void ChangePosition(int dialogueId, int positionId, int direction)
        {
            SetElements(dialogueId);

            var coutElements = _elements.Count();

            if (positionId > 0 && positionId <= coutElements)
            {
                UpPosition(positionId, direction);
                DownPosition(positionId, direction);
            }
            _context.SaveChanges();
        }

        private void UpPosition(int position, int direction)
        {
            if (direction != -1) return;

            var element1 = GetOneQuery(position);
            element1.IssueNr--;

            var element2 = GetOneQuery(position - 1);
            element2.IssueNr++;

            Edit(element1);
            Edit(element2);
        }

        private void DownPosition(int position, int direction)
        {
            if (direction != 1) return;

            var element1 = GetOneQuery(position);
            element1.IssueNr++;

            var element2 = GetOneQuery(position + 1);
            element2.IssueNr--;

            Edit(element1);
            Edit(element2);
        }

        public void Edit(Issue editIssue)
        {
            _context.Entry(editIssue).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void Remove(int dialogueId, int positionId)
        {
            SetElements(dialogueId);

            var removeIssue = GetOneQuery(positionId);
            _context.Issue.Remove(removeIssue);

            RebuildPosition(positionId);

            _context.SaveChanges();
        }

        private void RebuildPosition(int position)
        {
            foreach (var issue in _elements.Where(i => i.IssueNr > position))
            {
                issue.IssueNr--;
                _context.Entry(issue).State = EntityState.Modified;
            }
        }

        private Issue GetOneQuery(int position)
        {
            return _elements.First(i => i.IssueNr == position);
        }

        private void SetElements(int dialogueId)
        {
            _elements = _context.Issue.Where(i => i.DialogueId == dialogueId);
        }
    }
}

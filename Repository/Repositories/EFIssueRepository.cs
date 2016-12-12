using Contract.Params;
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

        public void Add(Issue issue)
        {
            var position = _context.Issue.Count(i => issue.DialogueId == i.DialogueId) + 1;
            issue.IssueNr = position;
            _context.Issue.Add(issue);
            _context.SaveChanges();
        }

        public Issue GetOne(IssueParams @params)
        {
            return _context.Issue.FirstOrDefault(issue => issue.DialogueId == @params.DialogueId && issue.IssueNr == @params.PositionId);
        }

        public void ChangePosition(IssueParams @params)
        {
            SetElements(@params.DialogueId);

            var coutElements = _elements.Count();

            if (@params.PositionId > 0 && @params.PositionId <= coutElements)
            {
                UpPosition(@params);
                DownPosition(@params);
            }
            _context.SaveChanges();
        }

        private void UpPosition(IssueParams @params)
        {
            if (@params.Direction != -1) return;

            var element1 = GetOneQuery(@params.PositionId);
            element1.IssueNr--;

            var element2 = GetOneQuery(@params.PositionId - 1);
            element2.IssueNr++;

            Edit(element1);
            Edit(element2);
        }

        private void DownPosition(IssueParams @params)
        {
            if (@params.Direction != 1) return;

            var element1 = GetOneQuery(@params.PositionId);
            element1.IssueNr++;

            var element2 = GetOneQuery(@params.PositionId + 1);
            element2.IssueNr--;

            Edit(element1);
            Edit(element2);
        }

        public void Edit(Issue issue)
        {
            _context.Entry(issue).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void Remove(IssueParams @params)
        {
            SetElements(@params.DialogueId);

            var removeIssue = GetOneQuery(@params.PositionId);
            _context.AudioFile.Remove(removeIssue.AudioFile);
            _context.SaveChanges();
            _context.Issue.Remove(removeIssue);

            RebuildPosition(@params.PositionId);

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

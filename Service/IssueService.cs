using System.Collections.Generic;
using System.Linq;
using Contract.Params;
using Model.Models;
using Repo.AbstractRepo;
using Service.Helper;

namespace Service
{
    public class IssueService : EntityBaseService, IIssueService
    {
        private ICollection<Issue> _elements;

        public IssueService(IRepositoryProvider provider) : base(provider)
        {
        }

        public void Add(Issue issue)
        {
            RepositoryProvider.Do(repo =>
            {
                var position = repo.GetCollection<Issue>().Count(i => issue.DialogueId == i.DialogueId) + 1;
                issue.IssueNr = position;
                repo.Add(issue);
            });
        }

        public Issue GetOne(IssueParams @params)
        {
            return RepositoryProvider.Do(repo =>
            {
                return repo.GetCollection<Issue>()
                    .FirstOrDefault(
                        issue => issue.DialogueId == @params.DialogueId && issue.IssueNr == @params.PositionId);
            });
        }

        public void ChangePosition(IssueParams @params)
        {
            RepositoryProvider.Do(repo =>
            {
                _elements = SetElements(@params.DialogueId, repo);

                var coutElements = _elements.Count;

                if (@params.PositionId > 0 && @params.PositionId <= coutElements)
                {
                    UpPosition(@params, repo);
                    DownPosition(@params, repo);
                }
            });
        }

        private void UpPosition(IssueParams @params, IRepository repo)
        {
            if (@params.Direction != -1) return;

            var element1 = GetOneQuery(@params.PositionId);
            element1.IssueNr--;

            var element2 = GetOneQuery(@params.PositionId - 1);
            element2.IssueNr++;

            repo.Edit(element1,element2);
        }

        private void DownPosition(IssueParams @params, IRepository repo)
        {
            if (@params.Direction != 1) return;

            var element1 = GetOneQuery(@params.PositionId);
            element1.IssueNr++;

            var element2 = GetOneQuery(@params.PositionId + 1);
            element2.IssueNr--;

            repo.Edit(element1, element2);
        }

        public void Edit(Issue issue)
        {
            RepositoryProvider.Do(repo =>
            {
                repo.Edit(issue);
            });
        }


        public void Remove(IssueParams @params)
        {
            RepositoryProvider.Do(repo =>
            {
                _elements = SetElements(@params.DialogueId,repo);

                var removeIssue = GetOneQuery(@params.PositionId);
              
                repo.Remove(removeIssue);

                RebuildPosition(@params.PositionId, repo);
            });
        }

        private void RebuildPosition(int position, IRepository repo)
        {
            foreach (var issue in _elements.Where(i => i.IssueNr > position))
            {
                issue.IssueNr--;
            }
            repo.Edit(_elements);
        }

        private Issue GetOneQuery(int position)
        {
            return _elements.First(i => i.IssueNr == position);
        }

        private ICollection<Issue> SetElements(int dialogueId, IRepository repo)
        {
            return repo.GetCollection<Issue>(i => i.DialogueId == dialogueId,true).ToList();
        }
    }
}

using Contract.Params;
using Model.Models;

namespace Repository.AbstractRepo
{
    public interface IIssueRepository
    {
        void Add(Issue issue);
        void Edit(Issue issue);
        void Remove(IssueParams @params);
        void ChangePosition(IssueParams @params);
        Issue GetOne(IssueParams @params);
    }
}

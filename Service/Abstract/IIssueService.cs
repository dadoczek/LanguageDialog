using Contract.Params;
using Contract.WebModel;
using Model.Models;

namespace Service.Abstract
{
    public interface IIssueService
    {
        void Add(Issue issue);
        void Edit(Issue issue);
        void Remove(IssueParams @params);
        void ChangePosition(IssueParams @params);
        Issue GetOne(IssueParams @params);
        PageData<Issue> GetPage(int dialogueId, int page);
    }
}

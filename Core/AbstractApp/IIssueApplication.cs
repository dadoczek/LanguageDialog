using Contract.Params;
using Contract.Responses;
using Model.Models;

namespace Core.AbstractApp
{
    public interface IIssueApplication
    {
        BaseResponse Add(Issue issue);
        BaseResponse Edit(Issue issue);
        BaseResponse Remove(IssueParams @params);
        BaseResponse ChangePosition(IssueParams @params);
        DataResponse<Issue> GetOne(IssueParams @params);
    }
}

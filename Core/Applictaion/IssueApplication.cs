using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repo.AbstractRepo;

namespace Core.Applictaion
{
    internal class IssueApplication : BaseApplication, IIssueApplication
    {
        private readonly IIssueService _Service;

        public IssueApplication(IFactory factory)
        {
            _Service = factory.GetIssueService;
        }

        public BaseResponse Add(Issue issue)
        {
            return DoSuccess(() =>
            {
                _Service.Add(issue);
            });
        }

        public BaseResponse ChangePosition(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _Service.ChangePosition(@params);
            });
        }

        public BaseResponse Edit(Issue issue)
        {
            return DoSuccess(() =>
            {
                _Service.Edit(issue);
            });
        }

        public DataResponse<Issue> GetOne(IssueParams @params)
        {
            return Do(() => new DataResponse<Issue>
            {
                Data = _Service.GetOne(@params)
            });
        }

        public BaseResponse Remove(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _Service.Remove(@params);
            });
        }
    }
}

using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repository.AbstractRepo;

namespace Core.Applictaion
{
    internal class IssueApplication : BaseApplication, IIssueApplication
    {
        private readonly IIssueRepository _issueRepository;

        public IssueApplication(IFactory factory)
        {
            _issueRepository = factory.GetIssueRepository;
        }

        public BaseResponse Add(Issue issue)
        {
            return DoSuccess(() =>
            {
                _issueRepository.Add(issue);
            });
        }

        public BaseResponse ChangePosition(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _issueRepository.ChangePosition(@params);
            });
        }

        public BaseResponse Edit(Issue issue)
        {
            return DoSuccess(() =>
            {
                _issueRepository.Edit(issue);
            });
        }

        public DataResponse<Issue> GetOne(IssueParams @params)
        {
            return Do(() => new DataResponse<Issue>
            {
                Data = _issueRepository.GetOne(@params)
            });
        }

        public BaseResponse Remove(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _issueRepository.Remove(@params);
            });
        }
    }
}

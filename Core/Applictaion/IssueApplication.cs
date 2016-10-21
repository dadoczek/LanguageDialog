using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repository.AbstractRepo;
using System;

namespace Core.Applictaion
{
    internal class IssueApplication : BaseApplication, IIssueApplication
    {
        private readonly IIssueRepository _IssueRepository;

        public IssueApplication(IFactory factory)
        {
            _IssueRepository = factory.GetIssueRepository;
        }

        public BaseResponse Add(Issue issue)
        {
            return DoSuccess(() =>
            {
                _IssueRepository.Add(issue);
            });
        }

        public BaseResponse ChangePosition(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _IssueRepository.ChangePosition(@params);
            });
        }

        public BaseResponse Edit(Issue issue)
        {
            return DoSuccess(() =>
            {
                _IssueRepository.Edit(issue);
            });
        }

        public DataResponse<Issue> GetOne(IssueParams @params)
        {
            return Do(() => new DataResponse<Issue>
            {
                Data = _IssueRepository.GetOne(@params)
            });
        }

        public BaseResponse Remove(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _IssueRepository.Remove(@params);
            });
        }
    }
}

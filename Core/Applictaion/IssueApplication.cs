using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Service.Abstract;

namespace Core.Applictaion
{
    internal class IssueApplication : BaseApplication, IIssueApplication
    {
        private readonly IIssueService _service;

        public IssueApplication(IFactory factory)
        {
            _service = factory.GetIssueService;
        }

        public BaseResponse Add(Issue issue)
        {
            return DoSuccess(() =>
            {
                _service.Add(issue);
            });
        }

        public BaseResponse ChangePosition(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _service.ChangePosition(@params);
            });
        }

        public BaseResponse Edit(Issue issue)
        {
            return DoSuccess(() =>
            {
                _service.Edit(issue);
            });
        }

        public DataResponse<Issue> GetOne(IssueParams @params)
        {
            return Do(() => new DataResponse<Issue>
            {
                Data = _service.GetOne(@params)
            });
        }

        public BaseResponse Remove(IssueParams @params)
        {
            return DoSuccess(() =>
            {
                _service.Remove(@params);
            });
        }

        public PageResponse<Issue> GetPage(int dialogueId, int page)
        {
            return Do(() => new PageResponse<Issue>
            {
                PageData = _service.GetPage(dialogueId, page)
            });
        }
    }
}

using Contract.WebModel;

namespace Contract.Responses
{
    public class PageResponse<T> : BaseResponse where T : class 
    {
        public PageData<T> PageData { get; set; }
    }
}

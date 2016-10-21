using System.Linq;

namespace Contract.Responses
{
    public class QueryableDataResponse<T> : BaseResponse
    {
        public IQueryable<T> Data { get; set; }
    }
}

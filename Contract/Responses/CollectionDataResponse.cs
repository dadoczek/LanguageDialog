using System.Collections.Generic;

namespace Contract.Responses
{
    public class CollectionDataResponse<T> : BaseResponse where T : class 
    {
        public ICollection<T> Data { get; set; }
    }
}

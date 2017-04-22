using System.Collections.Generic;

namespace Contract.Responses
{
    public class DictionaryResponse<TKey,TValue> : BaseResponse
    {
        public IDictionary<TKey,TValue> Dictionary { get; set; }
    }
}

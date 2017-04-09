using System.Collections.Generic;

namespace Contract.WebModel
{
    public class PageData<T> where T : class 
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public bool NextPage { get; set; }
        public bool PreviousPage { get; set; }
        public int PageSize { get; set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using Contract.WebModel;
using Service.Exception;

namespace Service
{
    public class PagingService
    {
        public PageData<T> GetPaging<T>(IEnumerable<T> inputElements, int page = 1, int pageSize = 20) where T : class 
        {
            if(inputElements == null)
                throw new PagingExeption("Collection data is not exist");
            if (page <= 0)
                throw new PagingExeption("Page is not be zero or smaller");

            // ReSharper disable once PossibleMultipleEnumeration
            var count = inputElements.Count();
            var skip = pageSize * (page - 1);

            if(skip >= count && count > 0)
                throw new PagingExeption("Page is too large");

            return new PageData<T>
            {
                Count = count,
                Page = page,
                // ReSharper disable once PossibleMultipleEnumeration
                Data = inputElements.Skip(skip).Take(pageSize).ToList(),
                NextPage = pageSize * page < count,
                PageSize = pageSize,
                PreviousPage = page > 1,
            };  
        }
    }
}
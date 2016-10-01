using System;

namespace Contract.Dtos
{
    public class PagingDto
    {
        private const int DefoultSizePage = 20;

        public int Page { get; }
        public int SizePage { get; }
        public int CountPage { get; }
        public int CountElement { get; }
        public bool IsNextPage { get; private set; }
        public bool IsPreviousPage { get; private set; }

        public PagingDto(int page, int countElement, int sizePage = DefoultSizePage)
        {
            Page = page;
            CountElement = countElement;
            SizePage = sizePage;
            CountPage = (int)Math.Ceiling(((decimal)CountElement / (decimal)SizePage));
            IsPreviousPage = (page > 1) ? true : false;
            IsNextPage = (page < CountPage) ? true : false;
        }

        public int SkipElement()
        {
            return ((Page - 1) * SizePage);
        }
    }
}

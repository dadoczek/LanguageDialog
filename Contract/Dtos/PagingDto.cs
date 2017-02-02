using System;

namespace Contract.Dtos
{
    public class PagingDto
    {
        private const int DefoultSizePage = 20;

        public int Page { get; set; }
        public int SizePage { get; set; }
        public int CountPage { get; set; }
        public int CountElement { get; set; }
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }

        public static PagingDto Create(int page, int countElement, int sizePage = DefoultSizePage)
        {
            if ((page - 1) * sizePage > countElement || page <= 0)
                throw new Exception("Numer Strony nie istnieje");

            var coutPage = (int) Math.Ceiling(countElement / (decimal) sizePage);

            var paging = new PagingDto
            {
                Page = page,
                CountElement = countElement,
                SizePage = sizePage,
                CountPage = coutPage,
                IsPreviousPage = page > 1,
                IsNextPage = page < coutPage,
            };
            return paging;

        }

        public int SkipElement()
        {
            return ((Page - 1) * SizePage);
        }
    }
}

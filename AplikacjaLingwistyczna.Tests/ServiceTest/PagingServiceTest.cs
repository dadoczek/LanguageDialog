using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Service;
using Service.Exception;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.ServiceTest
{
    public class PagingServiceTest
    {
        private readonly IEnumerable<Dialogue> _inputDialogues;

        public PagingServiceTest()
        {
            _inputDialogues = new []
            {
                new Dialogue
                {
                    Id = 1,
                    Name = "Name1"
                },
                new Dialogue
                {
                    Id = 2,
                    Name = "Name2"
                },
                new Dialogue
                {
                    Id = 3,
                    Name = "Name3"
                },
                new Dialogue
                {
                    Id = 4,
                    Name = "Name4"
                },
                new Dialogue
                {
                    Id = 5,
                    Name = "Name5"
                },
                new Dialogue
                {
                    Id = 6,
                    Name = "Name6"
                },
                new Dialogue
                {
                    Id = 7,
                    Name = "Name7"
                },
                new Dialogue
                {
                    Id = 8,
                    Name = "Name8"
                },
                new Dialogue
                {
                    Id = 9,
                    Name = "Name9"
                },
                new Dialogue
                {
                    Id = 10,
                    Name = "Name10"
                },
            };
        }

        [Fact]
        public void GetPagingTest()
        {
            var paging = new PagingService();
            var result = paging.GetPaging(_inputDialogues);

            Assert.True(result.Data.Count() == _inputDialogues.Count());
            Assert.True(result.Count == _inputDialogues.Count() );
            Assert.True(result.Page == 1);
            Assert.False(result.NextPage);
            Assert.False(result.PreviousPage);
            Assert.True(result.PageSize == 20);
        }

        [Theory]
        [InlineData(10,10, false)]
        [InlineData(15,10, false)]
        [InlineData(100,10, false)]
        [InlineData(8,8, true)]
        public void GetPagingTest_changeSizePage(int sizePage, int dataCount, bool nextPage)
        {
            var paging = new PagingService();
            var result = paging.GetPaging(_inputDialogues, pageSize: sizePage);

            Assert.True(result.Data.Count() == dataCount);
            Assert.True(result.Count == _inputDialogues.Count());
            Assert.True(result.Page == 1);
            Assert.True(result.NextPage == nextPage);
            Assert.False(result.PreviousPage);
            Assert.True(result.PageSize == sizePage);
        }

        [Theory]
        [InlineData(1,3, true, false, "Name1", "Name3")]
        [InlineData(2,3, true, true, "Name4", "Name6")]
        [InlineData(3,3, true, true, "Name7", "Name9")]
        [InlineData(4,1, false, true, "Name10", "Name10")]
        public void GetPagingTest_changePage(int page, int sizeData, bool nextPage, bool previousPage, string firstElementName, string lastElementName)
        {
            const int sizePage = 3;

            var paging = new PagingService();
            var result = paging.GetPaging(_inputDialogues, page, sizePage);

            Assert.Equal(result.Data.Count(), sizeData);
            Assert.Equal(result.Data.First().Name, firstElementName);
            Assert.Equal(result.Data.Last().Name, lastElementName);
            Assert.Equal(result.Count, _inputDialogues.Count());
            Assert.Equal(result.Page, page);
            Assert.Equal(result.NextPage, nextPage);
            Assert.Equal(result.PreviousPage, previousPage);
            Assert.Equal(result.PageSize, 3);
        }

        [Fact]
        public void GetPagingTest_If_collectio_is_null_should_be_returns_throws()
        {
            var paging = new PagingService();

            Exception ex = Assert.Throws<PagingExeption>(() => paging.GetPaging((IEnumerable<Dialogue>)null));

            Assert.Equal(ex.Message, "Collection data is not exist");
        }

        [Fact]
        public void GetPagingTest_If_page_is_too_large_returns_throws()
        {
            var paging = new PagingService();

            Exception ex = Assert.Throws<PagingExeption>(() => paging.GetPaging(_inputDialogues,2));

            Assert.Equal(ex.Message, "Page is too large");
        }

        [Fact]
        public void GetPagingTest_If_page_is_zero_or_smaller_returns_throws()
        {
            var paging = new PagingService();

            Exception ex = Assert.Throws<PagingExeption>(() => paging.GetPaging(_inputDialogues, 0));

            Assert.Equal(ex.Message, "Page is not be zero or smaller");
        }
    }
}

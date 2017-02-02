using System;
using Contract.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace AplikacjaLingwistyczna.Tests.Contract
{
    public class PagingDtoTest
    {
        [Fact]
        public void PagingDto_Set_Parametrs_In_Constructor_Middle_Page_Shuld_Be_Next_And_Privios_Page()
        {
            const int nrPage = 4;
            const int elementCount = 200;
            const int sizePage = 20;

            var pagingDto = PagingDto.Create(nrPage, elementCount, sizePage);

            Assert.True(pagingDto.IsNextPage);
            Assert.True(pagingDto.IsPreviousPage);
        }

        [Fact]
        public void PagingDto_Set_Parametrs_In_Constructor_First_Page_Shuld_Be_Not_Privios_Page()
        {
            const int nrPage = 1;
            const int elementCount = 200;
            const int sizePage = 20;

            var pagingDto = PagingDto.Create(nrPage, elementCount, sizePage);

            Assert.True(pagingDto.IsNextPage);
            Assert.False(pagingDto.IsPreviousPage);
        }

        [Fact]
        public void PagingDto_Set_Parametrs_In_Constructor_Last_Page_Shuld_Be_not_Next_Page()
        {
            const int nrPage = 10;
            const int elementCount = 200;
            const int sizePage = 20;

            var pagingDto = PagingDto.Create(nrPage, elementCount, sizePage);

            Assert.False(pagingDto.IsNextPage);
            Assert.True(pagingDto.IsPreviousPage);
        }

        [Fact]
        public void PagingDto_Set_Parametrs_In_Constructor_Page_Is_No_Exist_Shuld_Be_Exception()
        {
            const int nrPage = 20;
            const int elementCount = 200;
            const int sizePage = 20;

            Exception ex = Assert.Throws<Exception>(() => PagingDto.Create(nrPage, elementCount, sizePage));

            Assert.Equal("Numer Strony nie istnieje", ex.Message);
        }

    }
}

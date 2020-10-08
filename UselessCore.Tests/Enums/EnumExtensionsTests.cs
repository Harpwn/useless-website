using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using static UselessCore.Enums.EnumExtensions;

namespace UselessCore.Tests.Enums
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void EnumsFromCSV_ReturnsEmptyList_WhenInputNull()
        {
            //ARRANGE
            string input = null;

            //ACT
            var result = EnumsFromCSV<TestEnum>(input);

            //ASSERT
            Assert.Equal(new List<TestEnum>(), result);
        }

        [Fact]
        public void EnumsFromCSV_ReturnsValues()
        {
            //ARRANGE
            string input = "0,4";

            //ACT
            var result = EnumsFromCSV<TestEnum>(input);

            //ASSERT
            Assert.Equal(new List<TestEnum> { TestEnum.A, TestEnum.E }, result);
        }

        [Fact]
        public void EnumsFromCSV_ReturnsEmptyList_WhenInputInvalid()
        {
            string input = "5,6";

            //ACT
            var result = EnumsFromCSV<TestEnum>(input);

            //ASSERT
            Assert.Equal(new List<TestEnum>(), result);
        }

        [Fact]
        public void CSVFromEnums_ReturnsEmptyList_WhenInputEmpty()
        {
            var enumsList = new List<TestEnum> { };

            //ACT
            var result = CSVFromEnums(enumsList);

            //ASSERT
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void CSVFromEnums_ReturnsList()
        {
            var enumsList = new List<TestEnum> { TestEnum.A, TestEnum.E };

            //ACT
            var result = CSVFromEnums(enumsList);

            //ASSERT
            Assert.Equal("0,4", result);
        }

        [Fact]
        public void GetDisplayName_ReturnsName()
        {
            //ACT
            var result = TestEnum.A.GetDisplayName();
            var result2 = TestEnum.B.GetDisplayName();

            //ASSERT
            Assert.Equal("Test", result);
            Assert.Equal("B", result2);
        }

        [Fact]
        public void GetDescription_ReturnsDescription()
        {
            //ACT
            var result = TestEnum.A.GetDescription();
            var result2 = TestEnum.B.GetDescription();

            //ASSERT
            Assert.Equal("Test Desc", result);
            Assert.Equal("B", result2);
        }

        [Fact]
        public void GetListForEnum_ReturnsList()
        {
            //ACT
            var result = TestEnum.A.GetListForEnum();

            //ASSERT
            Assert.Equal(5, result.Count());
        }

    }

    public enum TestEnum
    {
        [Display(Name  = "Test", Description = "Test Desc")]
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4
    }
}

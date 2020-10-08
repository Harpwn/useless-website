using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Services;
using Xunit;

namespace UselessCore.Tests.Services
{
    public class ServiceActionResultTests
    {
        [Fact]
        public void GetErrorsMessage_ReturnsError()
        {
            //ARRANGE
            var actionResult = new ServiceActionResult() { Succeeded = false, Errors = new List<string> { "test error" } };
            var actionResult2 = new ServiceActionResult() { Succeeded = false, Errors = new List<string> { "test error", "test error 2" } };

            //ACT
            var result1 = actionResult.GetErrorsMessage();
            var result2 = actionResult2.GetErrorsMessage();

            //ASSERT
            Assert.False(string.IsNullOrEmpty(result1));
            Assert.False(string.IsNullOrEmpty(result2));

        }

        [Fact]
        public void GetErrorsMessage_ReturnsEmpty_WhenNoError()
        {
            //ARRANGE
            var actionResult = new ServiceActionResult() { Succeeded = false };

            //ACT
            var result1 = actionResult.GetErrorsMessage();

            //ASSERT
            Assert.Equal(string.Empty, result1);
        }

        [Fact]
        public void GetErrorsMessage_ReturnsEmpty_WhenSuccess()
        {
            //ARRANGE
            var actionResult = new ServiceActionResult() { Succeeded = true, Errors = new List<string> { "test error", "test error 2" } };

            //ACT
            var result1 = actionResult.GetErrorsMessage();

            //ASSERT
            Assert.Equal(string.Empty, result1);
        }
    }
}

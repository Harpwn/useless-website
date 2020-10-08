using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UselessCore.Extensions;
using Xunit;

namespace UselessCore.Tests.Extensions
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddCoreServices_AddServices()
        {
            //ARRANGE
            var serviceCollection = new ServiceCollection();

            //ACT
            serviceCollection.AddCoreServices();

            //ASSERT
            Assert.True(serviceCollection.Any());
        }
    }
}

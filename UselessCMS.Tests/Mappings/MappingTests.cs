using AutoMapper;
using Xunit;

namespace UselessCMS.Tests.Mappings
{
    public class MappingTests
    {
        [Fact]
        public void AssertConfigurationIsValid()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );

            configuration.AssertConfigurationIsValid();
        }
    }
}

using AutoMapper;
using System.Threading.Tasks;
using Xunit;

namespace UselessCore.Tests.Mappings
{
    public class MappingTests
    {
        [Fact]
        public void AssertConfigurationIsValid()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            configuration.AssertConfigurationIsValid();
        }
    }
}

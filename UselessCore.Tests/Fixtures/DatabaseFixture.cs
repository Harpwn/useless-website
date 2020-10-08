using Microsoft.EntityFrameworkCore;
using System;
using UselessCore.Enums.Entries;
using UselessCore.Model;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Images;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;

namespace UselessCore.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<UselessContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            Context = new UselessContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public UselessContext Context { get; private set; }
    }
}

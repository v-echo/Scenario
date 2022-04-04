using Implementation2.Db;
using Microsoft.EntityFrameworkCore;
using System;

namespace Implementation2.Tests
{
    /// <summary>
    /// Serves as a shared context for tests using a database. Generates a new test database, deploys it and deletes it after the tests are finished.
    /// </summary>
    public class DatabaseFixture : IDisposable
    {
        public I2Context Context { get; }

        public DatabaseFixture()
        {
            var id = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<I2Context>()
                .UseSqlServer($@"Server=(localdb)\MSSQLLocalDB;Database=Test_{id};Trusted_Connection=True;")
                .Options;
            Context = new I2Context(options);
            Context.Database.Migrate();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

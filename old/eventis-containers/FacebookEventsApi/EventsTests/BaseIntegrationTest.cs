using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Persistence;

namespace EventsTests
{
    public abstract class BaseIntegrationTest
    {
        protected virtual bool UseSqlServer => false;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            DestroyDatabase();
            CreateDatabase();
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            DestroyDatabase();
        }

        protected void RunOnDatabase(Action<DatabaseContext> action)
        {
            if (UseSqlServer)
            {
                RunOnSqlServer(action);
            }
            else
            {
                RunOnMemory(action);
            }
        }

        private void RunOnSqlServer(Action<DatabaseContext> databaseAction)
        {
            var connection = @"Server = .\SQLEXPRESS; Database = Events.Development.Test; Trusted_Connection = true;";
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connection).Options;

            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void RunOnMemory(Action<DatabaseContext> databaseAction)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("Events").Options;

            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void CreateDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureCreated());
        }

        private void DestroyDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureDeleted());
        }
    }

}


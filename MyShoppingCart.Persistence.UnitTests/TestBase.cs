using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyShoppingCart.Persistence.UnitTests
{
    public class TestBase : IDisposable
    {
        protected readonly InMemoryDbContext Context;
        protected readonly IFixture Fixture;

        public TestBase()
        {
            Context = CreateInMemoryContext();
            Fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        private InMemoryDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new InMemoryDbContext(options);


            context.Database.EnsureCreated();

            // Seed
            context.SaveChanges();

            return context;
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

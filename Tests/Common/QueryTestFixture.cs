using AutoMapper;
using Infrastructure.Persistence.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public OrdersDbContext context;

        public QueryTestFixture()
        {
            context = OrderContextFactory.Create();
        }

        public void Dispose()
        {
            OrderContextFactory.Destroy(context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

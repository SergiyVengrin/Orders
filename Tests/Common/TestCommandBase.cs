using Infrastructure.Persistence.EntityContext;

namespace Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly OrdersDbContext context;

        public TestCommandBase()
        {
            context = OrderContextFactory.Create();
        }

        public void Dispose()
        {
            OrderContextFactory.Destroy(context);
        }
    }
}

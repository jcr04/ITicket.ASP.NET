using ITicket.Domain.Repositories;

namespace ITicket.Infra.Factory
{
    public class EventRepositoryFactory : IEventRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EventRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IEventRepository CreateInstance()
        {
            return _serviceProvider.GetRequiredService<IEventRepository>();
        }
    }

    public interface IEventRepositoryFactory
    {
        IEventRepository CreateInstance();
    }
}
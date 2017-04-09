using Service.Helper;

namespace Service
{
    public class EntityBaseService
    {
        protected readonly PagingService PagingService;
        protected IRepositoryProvider RepositoryProvider;

        public EntityBaseService(IRepositoryProvider provider)
        {
            RepositoryProvider = provider;
            PagingService = new PagingService();
        }
    }
}

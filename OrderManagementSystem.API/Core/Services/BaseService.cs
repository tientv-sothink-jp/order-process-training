namespace OrderManagementSystem.API.Core.Services
{
    public class BaseService
    {
        protected IIdentityService identityService;

        public BaseService(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
    }
}

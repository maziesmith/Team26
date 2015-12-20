namespace UpgradeYourself.Api.Controllers
{
    using System.Web.Http;
    using UpgradeYourself.Data.Contracts;

    public abstract class BaseApiController : ApiController
    {
        protected IUpgradeYourselfData data;

        protected BaseApiController(IUpgradeYourselfData data)
        {
            this.data = data;
        }
    }
}
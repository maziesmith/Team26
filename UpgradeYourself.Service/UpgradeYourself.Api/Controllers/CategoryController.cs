namespace UpgradeYourself.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using UpgradeYourself.Api.Models;
    using UpgradeYourself.Data;
    using UpgradeYourself.Data.Contracts;

    public class CategoryController : BaseApiController
    {
        public CategoryController()
            : this(new UpgradeYourselfData(new UpgradeYourselfDbContext()))
        {
        }

        public CategoryController(IUpgradeYourselfData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var categories = this.data
                .Categories
                .All()
                .Select(CategoryViewModel.FromCategory);

            return this.Ok(categories);
        }
    }
}
namespace UpgradeYourself.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using UpgradeYourself.Data;
    using UpgradeYourself.Data.Contracts;
    using UpgradeYourself.Api.Models;

    public class QuestionController : BaseApiController
    {
        public QuestionController()
            : this(new UpgradeYourselfData(new UpgradeYourselfDbContext()))
        {
        }

        public QuestionController(IUpgradeYourselfData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var questions = this.data
                .Questions
                .All()
                .Select(QuestionViewModel.FromQuestion);

            return this.Ok(questions);
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            var questions = this.data
                .Questions
                .All()
                .Where(q => q.Category.Name.ToLower() == category.ToLower())
                .Select(QuestionViewModel.FromQuestion);

            return this.Ok(questions);
        }

        [HttpGet]
        public IHttpActionResult Get(string category, int difficulty)
        {
            var questions = this.data
                .Questions
                .All()
                .Where(q => q.Category.Name.ToLower() == category.ToLower() && q.Difficulty == difficulty)
                .Select(QuestionViewModel.FromQuestion);

            return this.Ok(questions);
        }
    }
}
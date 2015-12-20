
namespace UpgradeYourself.Windows.Services
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class SkillService
    {
        private const string SkillApiUrl = "http://localhost:53906/api/Category/Get";

        public IEnumerable<SkillViewModel> GetSkills()
        {
            var jsonResponse = this.GetSkillsFromApi();
            var parsedResponse = JArray.Parse(jsonResponse);

            var result = this.ParseJsonResponse(parsedResponse);
            return result;
        }

        private string GetSkillsFromApi()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(SkillApiUrl).Result;
            Task<string> result = null;

            try
            {
                result = response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                // TODO: log
            }

            return result.Result;
        }

        private IEnumerable<SkillViewModel> ParseJsonResponse(JArray parsedResponse)
        {
            return parsedResponse.Select(q => new SkillViewModel
            {
                Name = q["Name"].ToString(),
                Description = q["Description"].ToString(),
                ImageUrl = q["ImageUrl"].ToString()
            })
            .ToList();
        }
    }
}

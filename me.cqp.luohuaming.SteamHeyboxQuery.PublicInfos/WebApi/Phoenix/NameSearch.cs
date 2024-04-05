using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json;
using System.Linq;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.Phoenix
{
    public class NameSearch
    {
        private static string BaseURL = "https://m.fhyx.com/app/api/searchlist?keyword={{name}}&page=1";

        private string GameName { get; set; } = "";

        public NameSearch(string name)
        {
            GameName = name;
        }

        private NameSearch GetNameSearchFullJson(string name)
        {
            string url = BaseURL.Replace("{{name}}", name);
            string json = CommonHelper.DownloadString(url);
            return JsonConvert.DeserializeObject<NameSearch>(json);
        }

        public ApiResult Get()
        {
            var result = GetNameSearchFullJson(GameName);
            return result.search != null && result.search.Length > 0
                ? new ApiResult()
                {
                    IsSuccess = true,
                    Data = result.search.First().id
                }
                : new ApiResult()
                {
                    IsSuccess = false,
                    Data = null
                };
        }

        public int allpage { get; set; }

        public Search[] search { get; set; }

        public class Search
        {
            public string name { get; set; }

            public int id { get; set; }
        }
    }
}

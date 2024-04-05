using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.ErBing
{
    public class NameSearch
    {
        private static string BaseURL = "https://v2.diershoubing.com/eb/combine_game/search/?search_name={{name}}";

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
            return result.combine_games != null && result.combine_games.Length > 0
                ? new ApiResult()
                {
                    IsSuccess = true,
                    Data = result.combine_games.First().game_id
                }
                : new ApiResult()
                {
                    IsSuccess = false,
                    Data = null
                };
        }

        public Combine_Games[] combine_games { get; set; }

        public int ret { get; set; }

        public class Combine_Games
        {
            public int game_id { get; set; }
        }
    }
}

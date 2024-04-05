using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.ErBing
{
    public class GameIDDetail
    {
        private static string BaseURL = "https://v2.diershoubing.com/eb/combine_game/detail/{{id}}/?src=ios&version=9.52&pf=1";

        private string ID { get; set; } = "";

        public GameIDDetail(string id)
        {
            ID = id;
        }

        private GameIDDetail GetGameIDDetailFullJson(string id)
        {
            string url = BaseURL.Replace("{{id}}", id);
            string json = CommonHelper.DownloadString(url);
            return JsonConvert.DeserializeObject<GameIDDetail>(json);
        }

        public ApiResult GetSteamId()
        {
            var result = GetGameIDDetailFullJson(ID);
            if (result != null
                && result.ext_actions != null
                && result.ext_actions.Length > 0)
            {
                var id = result.ext_actions.FirstOrDefault(x => x.show_label.Contains("配置"));
                if (id != null)
                {
                    string steamId = id.content.Split('?').Last().Split('=').Last();
                    int intId = int.TryParse(steamId, out int value) ? value : 0;
                    return new ApiResult
                    {
                        IsSuccess = intId != 0,
                        Data = intId
                    };
                }
            }
            return new ApiResult
            {
                IsSuccess = false,
                Data = null
            };
        }

        public Ext_Actions[] ext_actions { get; set; }

        public class Ext_Actions
        {
            public string content { get; set; }

            public string show_label { get; set; }
        }
    }
}

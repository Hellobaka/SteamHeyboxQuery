using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi
{
    public class SearchGame
    {
        private static string baseURL = "https://api.xiaoheihe.cn/bbs/app/api/general/search/v1?search_type=game&q={{gamename}}";
        private string targetName {get;set;}

        public SearchGame(string gamename)
        {
            targetName = gamename;
        }
        private SearchResult GetGameInfoFullJson()
        {
            string url = baseURL.Replace("{{gamename}}", targetName);
            return JsonConvert.DeserializeObject<SearchResult>(CommonHelper.DownloadString(url));
        }

        public ApiResult Get()
        {
            var result = GetGameInfoFullJson();
            ApiResult apiResult = new ApiResult();
            if (result.result.items.Count > 0)
            {
                apiResult.IsSuccess = true;
                apiResult.Data = result.result.items;
            }
            else
            {
                apiResult.IsSuccess = false;
                apiResult.Data = null;
            }

            return apiResult;
        }
    }
}
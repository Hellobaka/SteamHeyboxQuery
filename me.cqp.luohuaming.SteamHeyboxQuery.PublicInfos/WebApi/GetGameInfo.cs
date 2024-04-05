using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi
{
    public class GetGameInfo
    {
        private static string BaseURL = "https://api.xiaoheihe.cn/game/get_game_detail/?h_src=game_rec_a&appid={{appid}}";
        private int AppID { get; set; }

        public GetGameInfo(int appId)
        {
            AppID = appId;
        }
        private GameInfo GetGameInfoFullJson(int appid)
        {
            string url = BaseURL.Replace("{{appid}}", appid.ToString());
            string json = CommonHelper.DownloadString(url);
            MainSave.CQLog.Debug("HeyboxJson", json);
            return JsonConvert.DeserializeObject<GameInfo>(json);
        }
        public ApiResult Get()
        {
            var result = GetGameInfoFullJson(AppID);
            if (result.result.steam_appid != 0)
            {
                return new ApiResult()
                {
                    IsSuccess = true,
                    Data = result.result
                };
            }
            else
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Data = null
                };
            }
        }
    }
}
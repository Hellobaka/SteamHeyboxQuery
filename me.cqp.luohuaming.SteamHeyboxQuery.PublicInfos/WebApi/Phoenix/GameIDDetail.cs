using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.Phoenix
{
    public class GameIDDetail
    {
        private static string BaseURL = "https://m.fhyx.com/app/api/detail?version=4&id={{id}}&token=";

        private string ID { get; set; } = "";

        public GameIDDetail(string id)
        {
            ID = id;
        }

        private JObject GetGameIDDetailFullJson(string id)
        {
            string url = BaseURL.Replace("{{id}}", id);
            string json = CommonHelper.DownloadString(url);
            return JObject.Parse(json);
        }

        public ApiResult GetSteamId()
        {
            var result = GetGameIDDetailFullJson(ID);
            if (result != null
                && result["product"] is JObject product
                && product.HasValues
                && product.Values().Count() > 0)
            {
                var id = product.Values().First();
                if (id != null)
                {
                    return new ApiResult
                    {
                        IsSuccess = true,
                        Data = int.TryParse(id["appid"].ToString(), out int value) ? value : 0,
                    };
                }
            }
            return new ApiResult
            {
                IsSuccess = false,
                Data = null
            };
        }
    }
}

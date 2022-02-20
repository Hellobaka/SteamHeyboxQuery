using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using me.cqp.luohuaming.SteamHeyboxQuery.Sdk.Cqp.EventArgs;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi;
using System.IO;

namespace me.cqp.luohuaming.SteamHeyboxQuery.Code.OrderFunctions
{
    public class NameQuery : IOrderModel
    {
        public bool ImplementFlag { get; set; } = true;
        
        public string GetOrderStr() => "#steam查询";

        public bool Judge(string destStr) => destStr.ToLower().Replace("＃", "#").StartsWith(GetOrderStr());//这里判断是否能触发指令

        public FunctionResult Progress(CQGroupMessageEventArgs e)//群聊处理
        {
            FunctionResult result = new FunctionResult
            {
                Result = true,
                SendFlag = true,
            };
            SendText sendText = new SendText
            {
                SendID = e.FromGroup,
            };
            string targetName = e.Message.Text.ToLower().Replace(GetOrderStr(), "").Trim();
            if (CommonHelper.SteamIdCache.ContainsKey(targetName))
            {
                sendText = CallGameInfo(CommonHelper.SteamIdCache[targetName], sendText);
            }
            else
            {
                sendText = CallSearch(targetName, sendText);
            }
            result.SendObject.Add(sendText);
            return result;
        }

        public FunctionResult Progress(CQPrivateMessageEventArgs e)//私聊处理
        {
            FunctionResult result = new FunctionResult
            {
                Result = true,
                SendFlag = true,
            };
            SendText sendText = new SendText
            {
                SendID = e.FromQQ,
            };
            string targetName = e.Message.Text.ToLower().Replace(GetOrderStr(), "").Trim();
            if (CommonHelper.SteamIdCache.ContainsKey(targetName))
            {
                sendText = CallGameInfo(CommonHelper.SteamIdCache[targetName], sendText);
            }
            else
            {
                sendText = CallSearch(targetName, sendText);
            }
            result.SendObject.Add(sendText);
            return result;
        }

        public static SendText CallSearch(string targetName, SendText sendText)
        {
            SearchGame searchgame = new SearchGame(targetName);
            var searchResult = searchgame.Get();
            if (searchResult.IsSuccess)
            {
                int appID = (searchResult.Data as List<SearchResult.Item>)[0].info.steam_appid;
                CommonHelper.SteamIdCache.Add(targetName, appID);
                MainSave.CQLog.Info("游戏查询",$"缓存成功，{targetName} -> steamID: {appID}");
                sendText = CallGameInfo(appID, sendText);
            }
            else
            {
                MainSave.CQLog.Info("游戏查询",$"查询失败，{targetName} 未找到关键词词条");
                sendText.MsgToSend.Add("未找到相关关键词的游戏Σ(っ°Д°;)っ");
            }

            return sendText;
        }

        public static SendText CallGameInfo(int appId, SendText sendText)
        {
            GetGameInfo gameInfo = new GetGameInfo(appId);
            var gameInfoResult = gameInfo.Get();
            if (gameInfoResult.IsSuccess)
            {
                var data = gameInfoResult.Data as GameInfo.Result;
                sendText.MsgToSend.Add(data.ToString());
                if (string.IsNullOrWhiteSpace(data.image) is false)
                {
                    string folderPath = Path.Combine(MainSave.ImageDirectory, "SteamHeyboxQuery");
                    Directory.CreateDirectory(folderPath);
                    string filename = $"{data.steam_appid}.jpg";
                    if (File.Exists(Path.Combine(folderPath, filename)) is false)
                    {
                        using (var http = new System.Net.WebClient())
                        {
                            http.DownloadFile(data.image, Path.Combine(folderPath, filename));
                        }
                    }
                    sendText.MsgToSend.Add($"[CQ:image,file=SteamHeyboxQuery\\{filename}]");
                }
            }
            else
            {
                sendText.MsgToSend.Add($"查询失败，{appId} 未找到AppID");
            }

            return sendText;
        }
    }
}

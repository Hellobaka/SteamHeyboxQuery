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
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.ErBing;

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
            var phoenixId = new NameSearch(targetName).Get();
            if (!phoenixId.IsSuccess)
            {
                MainSave.CQLog.Info("游戏查询", $"查询失败，{targetName} 未找到关键词词条：获取主ID");
                sendText.MsgToSend.Add("未找到相关关键词的游戏Σ(っ°Д°;)っ");
                return sendText;
            }
            var steamId = new GameIDDetail(phoenixId.Data.ToString()).GetSteamId();
            if (!steamId.IsSuccess)
            {
                MainSave.CQLog.Info("游戏查询", $"查询失败，{targetName} 未找到关键词词条：获取SteamID");
                sendText.MsgToSend.Add("未找到相关关键词的游戏Σ(っ°Д°;)っ");
                return sendText;
            }

            int appID = (int)steamId.Data;
            if (appID == 0)
            {
                MainSave.CQLog.Info("游戏查询", $"查询失败，{targetName} 未找到关键词词条：转换SteamID");
                sendText.MsgToSend.Add("未找到相关关键词的游戏Σ(っ°Д°;)っ");
                return sendText;
            }
            CommonHelper.SteamIdCache.Add(targetName, appID);
            MainSave.CQLog.Info("游戏查询", $"缓存成功，{targetName} -> steamID: {appID}");
            sendText = CallGameInfo(appID, sendText);

            return sendText;
        }

        public static SendText CallGameInfo(int appId, SendText sendText)
        {
            GetGameInfo gameInfo = new GetGameInfo(appId);
            var gameInfoResult = gameInfo.Get();
            if (gameInfoResult.IsSuccess)
            {
                var data = gameInfoResult.Data as GameInfo.Result;
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                data.DrawSteamImg().Save(Path.Combine(MainSave.ImageDirectory, "SteamHeyboxQuery", filename));
                sendText.MsgToSend.Add($"[CQ:image,file=SteamHeyboxQuery\\{filename}]");
            }
            else
            {
                sendText.MsgToSend.Add($"查询失败，{appId} 未找到AppID");
            }

            return sendText;
        }
    }
}

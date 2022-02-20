using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using me.cqp.luohuaming.SteamHeyboxQuery.Sdk.Cqp.EventArgs;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi;

namespace me.cqp.luohuaming.SteamHeyboxQuery.Code.OrderFunctions
{
    public class ListQuery : IOrderModel
    {
        public bool ImplementFlag { get; set; } = true;
        
        public string GetOrderStr() => "#steam列表查询";

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
            sendText = CallListQuery(targetName, sendText);
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
            sendText = CallListQuery(targetName, sendText);
            
            result.SendObject.Add(sendText);
            return result;
        }

        public SendText CallListQuery(string targetName, SendText sendText)
        {
            SearchGame searchgame = new SearchGame(targetName);
            var searchResult = searchgame.Get();
            if (searchResult.IsSuccess)
            {
                StringBuilder sb = new StringBuilder();
                var list = searchResult.Data as List<SearchResult.Item>;
                sb.AppendLine($"共有{list.Count}个结果");
                for (int i = 0; i < 5; i++)
                {
                    sb.AppendLine($"{list[i].info.name} - {list[i].info.steam_appid}");
                }
                sendText.MsgToSend.Add(sb.ToString());
            }
            else
            {
                MainSave.CQLog.Info("游戏查询",$"查询失败，{targetName} 未找到关键词词条");
                sendText.MsgToSend.Add("未找到相关关键词的游戏Σ(っ°Д°;)っ");
            }

            return sendText;
        } 
    }
}
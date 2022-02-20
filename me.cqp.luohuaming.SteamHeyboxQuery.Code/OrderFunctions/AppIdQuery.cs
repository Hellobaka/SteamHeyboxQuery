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
    public class AppIdQuery : IOrderModel
    {
        public bool ImplementFlag { get; set; } = true;
        
        public string GetOrderStr() => "#steamid查询";

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
            int appId = Convert.ToInt32(e.Message.Text.ToLower().Replace(GetOrderStr(), "").Trim());
            sendText = CallIdQuery(appId, sendText);
            
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
            int appId = Convert.ToInt32(e.Message.Text.ToLower().Replace(GetOrderStr(), "").Trim());
            sendText = CallIdQuery(appId, sendText);
            result.SendObject.Add(sendText);
            return result;
        }
        public static SendText CallIdQuery(int appId, SendText sendText)
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
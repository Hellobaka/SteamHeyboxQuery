using Microsoft.VisualStudio.TestTools.UnitTesting;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model;
using System.IO;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.WebApi.Tests
{
    [TestClass()]
    public class SearchGameTests
    {
        [TestMethod()]
        public void SearchGameTest()
        {
            string targetName = "我的世界";
            SearchGame searchgame = new SearchGame(targetName);
            var searchResult = searchgame.Get();
            if (searchResult.IsSuccess)
            {
                int appID = (searchResult.Data as List<SearchResult.Item>)[0].info.steam_appid;
                CommonHelper.SteamIdCache.Add(targetName, appID);
                Console.WriteLine($"缓存成功，{targetName} -> steamID: {appID}");
                GetGameInfo gameInfo = new GetGameInfo(appID);
                var gameInfoResult = gameInfo.Get();
                if(gameInfoResult.IsSuccess)
                {
                    var data = gameInfoResult.Data as GameInfo.Result;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                    data.DrawSteamImg().Save(Path.Combine("SteamHeyboxQuery", filename));
                }
            }
            else
            {
                Console.WriteLine("未找到相关关键词的游戏Σ(っ°Д°;)っ");
            }

        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }
    }
}
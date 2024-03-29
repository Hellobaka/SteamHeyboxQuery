﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using me.cqp.luohuaming.SteamHeyboxQuery.Sdk.Cqp.Model;
using me.cqp.luohuaming.SteamHeyboxQuery.Tool.IniConfig;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos
{
    public static class CommonHelper
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
        /// <summary>
        /// 获取CQ码中的图片网址
        /// </summary>
        /// <param name="imageCQCode">需要解析的图片CQ码</param>
        /// <returns></returns>
        public static string GetImageURL(string imageCQCode)
        {
            string path = MainSave.ImageDirectory + CQCode.Parse(imageCQCode)[0].Items["file"] + ".cqimg";
            IniConfig image = new IniConfig(path);
            image.Load();
            return image.Object["image"]["url"].ToString();
        }
        public static string GetAppImageDirectory()
        {
            var ImageDirectory = Path.Combine(Environment.CurrentDirectory, "data", "image\\");
            return ImageDirectory;
        }

        public static Dictionary<string, int> SteamIdCache { get; set; } = new Dictionary<string, int>();
        public static string DownloadString(string url) {
            using(var client = new System.Net.WebClient()) {
                string json = client.DownloadString(url);
                json = Regex.Replace(json, "heybox:\\/\\/.*\"", "\"");
                return json;
            }
        }
    }
}

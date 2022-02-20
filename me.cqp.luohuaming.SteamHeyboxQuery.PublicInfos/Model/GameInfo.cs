using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model
{
    public class GameInfo
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string version { get; set; }
        public Result result { get; set; }
        public class PeakValue
        {
            public int peak_value { get; set; }
            public int time { get; set; }
        }

        public class GameData
        {
            public string rank { get; set; }
            public string value { get; set; }
            public int num { get; set; }
            public IList<PeakValue> peak_values { get; set; }
            public string delta { get; set; }
            public string desc { get; set; }
        }

        public class UserNum
        {
            public IList<GameData> game_data { get; set; }
            public string current_online_url { get; set; }
        }

        public class MenuV2
        {
            public string type { get; set; }
            public object value { get; set; }
            public string title { get; set; }
            public string key { get; set; }
            public string color { get; set; }
        }

        public class Screenshot
        {
            public string url { get; set; }
            public string type { get; set; }
            public string thumbnail { get; set; }
        }

        public class CouponInfo
        {
            public string coupon_desc { get; set; }
            public int available_coupon_num { get; set; }
            public string title { get; set; }
            public string sub_title { get; set; }
            public int max_reduce { get; set; }
            public int primary_id { get; set; }
            public string coupon_protocol { get; set; }
            public string price_desc { get; set; }
        }

        public class HeyboxPrice
        {
            public CouponInfo coupon_info { get; set; }
            public bool has_sl { get; set; }
            public int is_lowest { get; set; }
            public int discount { get; set; }
            public int original_coin { get; set; }
            public int cost_coin { get; set; }
            public string end_time { get; set; }
            public bool super_lowest { get; set; }
        }

        public class CommentStats
        {
            public int expect_num { get; set; }
            public string extra_desc { get; set; }
            public string star_2 { get; set; }
            public string star_1 { get; set; }
            public string star_5 { get; set; }
            public string star_4 { get; set; }
            public string star_3 { get; set; }
            public int score_comment { get; set; }
        }

        public class Hb2style
        {
            public string bg_color { get; set; }
            public string bg_pic { get; set; }
        }

        public class TopicDetail
        {
            public int has_bbs { get; set; }
            public Hb2style hb2style { get; set; }
            public string pic_url { get; set; }
            public string name { get; set; }
            public int topic_id { get; set; }
        }

        public class Publisher
        {
            public string value { get; set; }
            public string key { get; set; }
        }

        public class MinimumPrice
        {
            public string name { get; set; }
            public string cc { get; set; }
            public string image { get; set; }
            public string initial { get; set; }
            public string value { get; set; }
            public string current { get; set; }
            public int discount { get; set; }
        }

        public class Price
        {
            public int is_lowest { get; set; }
            public int deadline_timestamp { get; set; }
            public string initial { get; set; }
            public string current { get; set; }
            public int discount { get; set; }
            public string deadline_date { get; set; }
            public string lowest_price_raw { get; set; }
            public int lowest_price { get; set; }
            public int new_lowest { get; set; }
            public bool super_lowest { get; set; }
            public int lowest_discount { get; set; }
        }

        public class GenresList
        {
            public string img { get; set; }
            public int key { get; set; }
            public string desc { get; set; }
        }

        public class SpecialTagsV2
        {
            public string protocol { get; set; }
            public string key { get; set; }
            public string desc { get; set; }
        }

        public class GameAward
        {
            public string detail_name { get; set; }
            public string collection_id { get; set; }
            public string desc { get; set; }
        }

        public class Price2
        {
            public string current { get; set; }
            public int discount { get; set; }
            public string initial { get; set; }
            public object lowest_price { get; set; }
            public int lowest_discount { get; set; }
            public int? is_lowest { get; set; }
            public int? deadline_timestamp { get; set; }
            public string deadline_date { get; set; }
            public string lowest_price_raw { get; set; }
            public int? new_lowest { get; set; }
        }

        public class CouponInfo2
        {
            public string coupon_desc { get; set; }
            public string title { get; set; }
            public int available_coupon_num { get; set; }
            public string sub_title { get; set; }
            public int max_reduce { get; set; }
            public int primary_id { get; set; }
            public string coupon_protocol { get; set; }
        }

        public class HeyboxPrice2
        {
            public CouponInfo2 coupon_info { get; set; }
            public int is_lowest { get; set; }
            public int discount { get; set; }
            public int original_coin { get; set; }
            public int cost_coin { get; set; }
            public string end_time { get; set; }
        }

        public class Dlc
        {
            public int game_count { get; set; }
            public string name { get; set; }
            public IList<object> platforms_url { get; set; }
            public string image { get; set; }
            public IList<object> platforms { get; set; }
            public int bundle_id { get; set; }
            public string type { get; set; }
            public Price2 price { get; set; }
            public HeyboxPrice2 heybox_price { get; set; }
        }

        public class HotTag
        {
            public string filter_head { get; set; }
            public int key { get; set; }
            public string desc { get; set; }
        }

        public class PlatformsList
        {
            public string platf { get; set; }
            public string img_url { get; set; }
            public string name { get; set; }
            public int appid { get; set; }
        }

        public class Result
        {
            public int steam_appid { get; set; }
            public UserNum user_num { get; set; }
            public string share_desc { get; set; }
            public IList<string> platforms_url { get; set; }
            public string deadline_desc { get; set; }
            public string image { get; set; }
            public IList<MenuV2> menu_v2 { get; set; }
            public int comment_change { get; set; }
            public IList<string> platforms { get; set; }
            public string heybox_download { get; set; }
            public int is_official { get; set; }
            public IList<Screenshot> screenshots { get; set; }
            public IList<string> genres { get; set; }
            public HeyboxPrice heybox_price { get; set; }
            public IList<object> menu { get; set; }
            public CommentStats comment_stats { get; set; }
            public int deadline_timestamp { get; set; }
            public int has_game_detail { get; set; }
            public int has_unfinished_order { get; set; }
            public string share_url { get; set; }
            public string about_the_game { get; set; }
            public string score { get; set; }
            public string share_title { get; set; }
            public string appicon { get; set; }
            public TopicDetail topic_detail { get; set; }
            public string type { get; set; }
            public string positive_desc { get; set; }
            public IList<object> publishers { get; set; }
            public string platf { get; set; }
            public MinimumPrice minimum_price { get; set; }
            public Price price { get; set; }
            public string purchase_url { get; set; }
            public IList<GenresList> genres_list { get; set; }
            public bool is_free { get; set; }
            public IList<SpecialTagsV2> special_tags_v2 { get; set; }
            public IList<GameAward> game_award { get; set; }
            public string name_en { get; set; }
            public IList<Dlc> dlcs { get; set; }
            public string desc { get; set; }
            public string name { get; set; }
            public string share_img { get; set; }
            public int comment_state { get; set; }
            public string game_type { get; set; }
            public IList<HotTag> hot_tags { get; set; }
            public IList<PlatformsList> platforms_list { get; set; }
            public int support_chinese { get; set; }
            public int appid { get; set; }
            public string game_review_summary { get; set; }
            public string follow_state { get; set; }
            
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"名称: {name}");
                sb.AppendLine($"{menu_v2[0].title}{menu_v2[0].value}");
                if (publishers[0] is string)
                {
                    sb.AppendLine($"开发商：{publishers[0]}");
                }
                else
                {
                    sb.AppendLine($"{menu_v2[1].title}{menu_v2[1].value}");
                }
                sb.AppendLine($"tag: {string.Join(" ",hot_tags.Select(x=>x.desc).ToList())}");
                if (user_num != null)
                {
                    string commonStr = "Steam好评率: {steam_rate} 小黑盒评分: {heybox_rate}\n当前在线: {online_count} 月活用户: {monthly_count} 平均时长: {avg_time}";
                    foreach (var item in user_num.game_data)
                    {
                        if (item.desc == "Steam好评率")
                        {
                            commonStr = commonStr.Replace("{steam_rate}", item.value);
                        }
                        else if (item.desc == "当前在线")
                        {
                            commonStr = commonStr.Replace("{online_count}", item.value);
                        }
                        else if (item.desc == "本月平均在线")
                        {
                            commonStr = commonStr.Replace("{monthly_count}", item.value);
                        }
                        else if (item.desc == "平均游戏时间")
                        {
                            commonStr = commonStr.Replace("{avg_time}", item.value);
                        }
                    }
                    commonStr = commonStr.Replace("{heybox_rate}", score);
                    sb.AppendLine(commonStr);
                }
                else
                {
                    sb.AppendLine($"小黑盒评分: {score} 平台: {platf}");
                }
                if (is_free)
                {
                    sb.AppendLine($"价格: 免费");
                }
                else
                {
                    string priceStr = "国区史低: {lowest_price} 最低价: {lowest_area_price}\n当前价格: {now_price} 小黑盒价格: {heybox_price}";
                    priceStr = priceStr.Replace("{now_price}", $"￥{price?.current}{(price?.discount == 0 ? " " : $" -{price?.discount}%")}");
                    priceStr = priceStr.Replace("{lowest_price}", $"￥{(price?.lowest_price == 0 ? price?.current : price?.lowest_price.ToString())}");
                    priceStr = priceStr.Replace("{lowest_area_price}", $"{minimum_price?.name} {minimum_price?.value}");
                    priceStr = priceStr.Replace("{heybox_price}", $"￥{heybox_price?.cost_coin/1000}");
                    sb.AppendLine(priceStr);
                }
                return sb.ToString();
            }
        }
    }
}
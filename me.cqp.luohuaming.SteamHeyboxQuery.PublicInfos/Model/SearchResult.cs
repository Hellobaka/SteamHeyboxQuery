using System;
using System.Collections.Generic;

namespace me.cqp.luohuaming.SteamHeyboxQuery.PublicInfos.Model
{
    public class SearchResult
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string version { get; set; }
        public Result result { get; set; }

        public class CouponInfo
        {
            public string coupon_desc { get; set; }
            public string title { get; set; }
            public int available_coupon_num { get; set; }
            public string sub_title { get; set; }
            public int max_reduce { get; set; }
            public int primary_id { get; set; }
            public string coupon_protocol { get; set; }
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
            public int? deadline_timestamp { get; set; }
        }

        public class Price
        {
            public string current { get; set; }
            public int deadline_timestamp { get; set; }
            public string initial { get; set; }
            public int is_lowest { get; set; }
            public int discount { get; set; }
            public string deadline_date { get; set; }
            public string lowest_price_raw { get; set; }
            public float lowest_price { get; set; }
            public float new_lowest { get; set; }
            public float lowest_discount { get; set; }
        }

        public class Price2
        {
            public bool is_free { get; set; }
            public int? is_lowest { get; set; }
            public string region_name { get; set; }
            public int? discount { get; set; }
            public string region { get; set; }
            public string initial { get; set; }
            public string discount_desc { get; set; }
            public string final_amount { get; set; }
            public string current { get; set; }
            public string initial_amount { get; set; }
            public string deadline_date { get; set; }
            public int? deadline_timestamp { get; set; }
            public int? new_lowest { get; set; }
            public int? plus_discount { get; set; }
            public string lowest_price { get; set; }
            public string image { get; set; }
        }

        public class PlatformInfo
        {
            public string img_url { get; set; }
            public string key { get; set; }
            public Price2 price { get; set; }
        }

        public class Info
        {
            public int steam_appid { get; set; }
            public IList<object> genres { get; set; }
            public string name { get; set; }
            public string h_src { get; set; }
            public IList<string> platforms_url { get; set; }
            public string hidden_type { get; set; }
            public string image { get; set; }
            public string game_type { get; set; }
            public bool is_free { get; set; }
            public IList<string> platforms { get; set; }
            public int is_owned { get; set; }
            public string score { get; set; }
            public IList<string> platforms_icon { get; set; }
            public string appicon { get; set; }
            public HeyboxPrice heybox_price { get; set; }
            public string type { get; set; }
            public Price price { get; set; }
            public IList<PlatformInfo> platform_infos { get; set; }
            public string is_bundle { get; set; }
            public string score_desc { get; set; }
            public bool? is_release { get; set; }
            public string bundle_id { get; set; }
            public int? hs_inventory { get; set; }
            public int? online_player { get; set; }
            public int? has_achievement { get; set; }
            public string release_date { get; set; }
            public string peak_user_num { get; set; }
        }

        public class Item
        {
            public Info info { get; set; }
            public string type { get; set; }
            public string report_id { get; set; }
        }

        public class GameTypeList
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Result
        {
            public IList<Item> items { get; set; }
            public IList<object> sort_filter_list { get; set; }
            public IList<GameTypeList> game_type_list { get; set; }
            public IList<object> time_range_list { get; set; }
        }
    }
}
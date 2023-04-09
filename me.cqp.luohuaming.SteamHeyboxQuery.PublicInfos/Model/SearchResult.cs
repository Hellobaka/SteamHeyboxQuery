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

        public class Result
        {
            public Item[] items { get; set; }
            public object[] sort_filter_list { get; set; }
            public Game_Type_List[] game_type_list { get; set; }
            public object[] time_range_list { get; set; }
        }

        public class Item
        {
            public Info info { get; set; }
            public string type { get; set; }
            public string weight { get; set; }
            public string report_id { get; set; }
        }

        public class Info
        {
            public int steam_appid { get; set; }
            public string[] platforms_url { get; set; }
            public string image { get; set; }
            public string[] platforms { get; set; }
            public Heybox_Price heybox_price { get; set; }
            public object[] genres { get; set; }
            public string hidden_type { get; set; }
            public string score { get; set; }
            public string appicon { get; set; }
            public string type { get; set; }
            public string h_src { get; set; }
            public Price price { get; set; }
            public bool is_free { get; set; }
            public string name { get; set; }
            public string game_type { get; set; }
            public string[] platforms_icon { get; set; }
            public int is_owned { get; set; }
            public Platform_Infos[] platform_infos { get; set; }
            public object is_bundle { get; set; }
            public string name_en { get; set; }
            public string score_desc { get; set; }
            public string peak_user_num { get; set; }
            public int online_player { get; set; }
            public int has_achievement { get; set; }
            public string[] free_types { get; set; }
            public Rich_Tags[] rich_tags { get; set; }
            public int hs_inventory { get; set; }
            public string release_date { get; set; }
            public int expect_num { get; set; }
            public string protocol { get; set; }
            public string vertical_img_bg { get; set; }
            public string download_url_android { get; set; }
            public bool is_release { get; set; }
            public string download_url_ios { get; set; }
            public string bundle_id { get; set; }
        }

        public class Heybox_Price
        {
            public bool has_sl { get; set; }
            public int is_lowest { get; set; }
            public int discount { get; set; }
            public int original_coin { get; set; }
            public int cost_coin { get; set; }
            public object end_time { get; set; }
        }

        public class Price
        {
            public object current { get; set; }
            public string initial { get; set; }
            public int is_lowest { get; set; }
            public int discount { get; set; }
            public string lowest_price_raw { get; set; }
            public object lowest_price { get; set; }
            public int new_lowest { get; set; }
            public int lowest_discount { get; set; }
            public string current_v { get; set; }
            public string region_name { get; set; }
            public string initial_amount { get; set; }
            public string region { get; set; }
            public string final_amount { get; set; }
            public string deadline_date { get; set; }
            public int deadline_timestamp { get; set; }
            public int plus_discount { get; set; }
        }

        public class Platform_Infos
        {
            public Price1 price { get; set; }
            public string img_url { get; set; }
            public string key { get; set; }
        }

        public class Price1
        {
            public int is_lowest { get; set; }
            public string current_v { get; set; }
            public string region_name { get; set; }
            public string initial_amount { get; set; }
            public string region { get; set; }
            public string initial { get; set; }
            public string deadline_date { get; set; }
            public bool is_free { get; set; }
            public string final_amount { get; set; }
            public string current { get; set; }
            public int discount { get; set; }
            public string discount_desc { get; set; }
            public object deadline_timestamp { get; set; }
            public int new_lowest { get; set; }
            public int plus_discount { get; set; }
            public string lowest_price { get; set; }
            public string image { get; set; }
            public string purchase_protocol { get; set; }
        }

        public class Rich_Tags
        {
            public int text_alignment { get; set; }
            public string border_color { get; set; }
            public int height { get; set; }
            public int corner_radius { get; set; }
            public Inset inset { get; set; }
            public Attr[] attrs { get; set; }
            public string border_width { get; set; }
            public string background_color { get; set; }
        }

        public class Inset
        {
            public int top { get; set; }
            public int right { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
        }

        public class Attr
        {
            public int width { get; set; }
            public string image { get; set; }
            public string type { get; set; }
            public int height { get; set; }
            public int font_size { get; set; }
            public string color { get; set; }
            public string text { get; set; }
            public int line_height { get; set; }
            public string font_name { get; set; }
        }

        public class Game_Type_List
        {
            public string name { get; set; }
            public string value { get; set; }
        }
    }

}
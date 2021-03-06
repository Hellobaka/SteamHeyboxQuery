using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                sb.AppendLine($"??????: {name}");
                sb.AppendLine($"{menu_v2[0].title}{menu_v2[0].value}");
                if (publishers[0] is string)
                {
                    sb.AppendLine($"????????????{publishers[0]}");
                }
                else
                {
                    sb.AppendLine($"{menu_v2[1].title}{menu_v2[1].value}");
                }
                sb.AppendLine($"tag: {string.Join(" ", hot_tags.Select(x => x.desc).ToList())}");
                if (user_num != null)
                {
                    string commonStr = "Steam?????????: {steam_rate} ???????????????: {heybox_rate}\n????????????: {online_count} ????????????: {monthly_count} ????????????: {avg_time}";
                    foreach (var item in user_num.game_data)
                    {
                        if (item.desc == "Steam?????????")
                        {
                            commonStr = commonStr.Replace("{steam_rate}", item.value);
                        }
                        else if (item.desc == "????????????")
                        {
                            commonStr = commonStr.Replace("{online_count}", item.value);
                        }
                        else if (item.desc == "??????????????????")
                        {
                            commonStr = commonStr.Replace("{monthly_count}", item.value);
                        }
                        else if (item.desc == "??????????????????")
                        {
                            commonStr = commonStr.Replace("{avg_time}", item.value);
                        }
                    }
                    commonStr = commonStr.Replace("{heybox_rate}", score);
                    sb.AppendLine(commonStr);
                }
                else
                {
                    sb.AppendLine($"???????????????: {score} ??????: {platf}");
                }
                if (is_free)
                {
                    sb.AppendLine($"??????: ??????");
                }
                else
                {
                    string priceStr = "????????????: {lowest_price} ?????????: {lowest_area_price}\n????????????: {now_price} ???????????????: {heybox_price}";
                    priceStr = priceStr.Replace("{now_price}", $"???{price?.current}{(price?.discount == 0 ? " " : $" -{price?.discount}%")}");
                    priceStr = priceStr.Replace("{lowest_price}", $"???{(price?.lowest_price == 0 ? price?.current : price?.lowest_price.ToString())}");
                    priceStr = priceStr.Replace("{lowest_area_price}", $"{minimum_price?.name} {minimum_price?.value}");
                    priceStr = priceStr.Replace("{heybox_price}", $"???{heybox_price?.cost_coin / 1000}");
                    sb.AppendLine(priceStr);
                }
                return sb.ToString();
            }
            public Bitmap DrawSteamImg()
            {
                #region ???????????????

                string name = this.name,
                    releaseDate = "--", //
                    publisher = "--",//
                    steam = "0%",
                    heybox = score,
                    online = "--",
                    onlineRank = "",
                    month = "--",
                    monthRank = "",
                    avg = "--",
                    avgRank = "",
                    lowest = "--",
                    lowestArea = "--",
                    lowestAreaPrice = "--",
                    nowPrice = "--",
                    discount = "",
                    heyboxPlayer = "--",
                    heyboxPlayerRank = "",
                    heyboxPrice = "--";
                string[] tags = hot_tags.Select(x => x.desc).ToArray();
                releaseDate = menu_v2[0].value.ToString();
                if (publishers.Count > 0)
                {
                    if(publishers[0] is string)
                    {
                        publisher = publishers[0] as string;
                    }
                    else
                    {
                        publisher = menu_v2[1].value.ToString();
                    }
                }
                
                if (user_num != null)
                {
                    foreach (var item in user_num.game_data)
                    {
                        if (item.desc == "Steam?????????")
                        {
                            steam = item.value;
                        }
                        else if (item.desc == "????????????")
                        {
                            online = item.value;
                            onlineRank = item.rank;
                        }
                        else if (item.desc == "??????????????????")
                        {
                            month = item.value;
                            monthRank = item.rank;
                        }
                        else if (item.desc == "??????????????????")
                        {
                            avg = item.value;
                            avgRank = item.rank;
                        }
                        else if (item.desc == "??????????????????")
                        {
                            heyboxPlayer = item.value;
                            heyboxPlayerRank = item.rank;
                        }
                    }
                }
                else
                {
                    name += $" ({platf})";
                }
                if (positive_desc.Contains("?????????"))
                {
                    steam = positive_desc.Replace("Steam????????????", "");
                }
                if (is_free)
                {
                    nowPrice = "??????";
                }
                else
                {
                    if (price != null)
                    {
                        nowPrice = "???" + price.current;
                        discount = price.discount == 0 ? "" : $"-{price.discount}%";
                        lowest = price.lowest_price == 0 ? "???" + price.current : "???" + price.lowest_price.ToString();
                        lowestArea = heybox_price == null ? "--" : minimum_price.name;
                        lowestAreaPrice = heybox_price == null ? "--" : minimum_price.value;
                        heyboxPrice = heybox_price == null ? "--" : $"???{heybox_price.cost_coin / 1000}";
                    }
                }
                #endregion
                string headPic = "";
                if (string.IsNullOrWhiteSpace(image) is false)
                {
                    string folderPath = Path.Combine(MainSave.ImageDirectory, "SteamHeyboxQuery");
                    Directory.CreateDirectory(folderPath);
                    string filename = $"{steam_appid}.jpg";
                    headPic = Path.Combine(folderPath, filename);
                    if (File.Exists(headPic) is false)
                    {
                        using (var http = new System.Net.WebClient())
                        {
                            http.DownloadFile(image, Path.Combine(folderPath, filename));
                        }
                    }
                }

                Bitmap bitmap = new Bitmap(580, 490);
                int padding = 10;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    g.FillRectangle(new SolidBrush(Color.FromArgb(27, 40, 56)), new Rectangle(new Point(0, 0), bitmap.Size));
                    Font font = new Font("????????????", 24);
                    font = AdjustFontSize(g, name, font, bitmap.Width - 2 * padding);

                    Point point = new Point(padding, padding);
                    Size size = new Size(375, 182);
                    g.DrawString(name, font, Brushes.White, point);
                    point = new Point(padding, 58);
                    if (File.Exists(headPic))
                    {
                        Bitmap head = (Bitmap)Image.FromFile(headPic);
                        if (head.Width >= 375)
                        {
                            double range = 375 / (double)head.Width;
                            if (head.Height * range > 182)
                            {
                                range = 182 / (double)head.Height;
                                size = new Size((int)(head.Width * range), 182);
                            }
                            else
                            {
                                size = new Size(375, (int)(head.Height * range));
                            }
                        }
                        else if (head.Height >= 182)
                        {
                            double range = 182 / (double)head.Height;
                            if (head.Width * range > 375)
                            {
                                range = 375 / (double)head.Width;
                                size = new Size(375, (int)(head.Height * range));
                            }
                            else
                            {
                                size = new Size((int)(head.Width * range), 182);
                            }
                        }
                        g.DrawImage(head, new Rectangle(point, size));
                    }
                    else
                    {
                        g.DrawString("????????????", new Font("????????????", 30), Brushes.White, new Point(10, 120));
                    }

                    Font smallFont = new Font("????????????", 12);
                    font = new Font("????????????", 14);

                    point = new Point(400, 58);
                    g.DrawString("????????????", smallFont, Brushes.White, point);
                    point = new Point(400, 82);
                    font = AdjustFontSize(g, publisher, font, 180);
                    g.DrawString(publisher, font, Brushes.White, point);

                    point = new Point(400, 110);
                    font = new Font("????????????", 14);
                    g.DrawString("???????????????", smallFont, Brushes.White, point);
                    point = new Point(400, 134);
                    font = AdjustFontSize(g, releaseDate, font, 180);
                    g.DrawString(releaseDate, font, Brushes.White, point);

                    point = new Point(padding, 247);
                    foreach (var tag in tags)
                    {
                        font = new Font("????????????", 10);
                        var tmp = g.MeasureString(tag, font);
                        g.DrawImage(DrawRoundRect((int)tmp.Width + 6, (int)tmp.Height + 4, 2, new SolidBrush(Color.FromArgb(33, 57, 74))), point);
                        g.DrawString(tag, font, new SolidBrush(Color.FromArgb(103, 193, 245)), new Point(point.X + 4, point.Y + 2));
                        point = new Point(point.X + (int)tmp.Width + 6 + 4, point.Y);
                    }
                    font = new Font("????????????", 28);
                    int containerWidth = 100, containerHeight = 100;
                    Bitmap container = DrawRoundRect(containerWidth, containerHeight, 5, new LinearGradientBrush(new Point(0, 0), new Point(60, 120), Color.FromArgb(44, 60, 73), Color.FromArgb(88, 103, 117)));

                    int containerPostionY = 275, gap = containerWidth + 5;
                    //int startX = (int)(300 - (containerWidth * 0.5) - gap);
                    int startX = padding;

                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, online, font, containerWidth);
                    var stringSize = g.MeasureString(online, font);
                    g.DrawString(online, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);
                    DrawRank(onlineRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("???????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, month, font, containerWidth);
                    stringSize = g.MeasureString(month, font);
                    g.DrawString(month, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);
                    DrawRank(monthRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, avg, font, containerWidth);
                    stringSize = g.MeasureString(avg, font);
                    g.DrawString(avg, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);
                    DrawRank(avgRank, g, startX, containerPostionY, containerWidth);


                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("???????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, heyboxPlayer, font, containerWidth);
                    stringSize = g.MeasureString(heyboxPlayer, font);
                    g.DrawString(heyboxPlayer, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);
                    DrawRank(heyboxPlayerRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("Steam?????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString("Steam?????????", smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, steam, font, containerWidth);
                    stringSize = g.MeasureString(steam, font);
                    g.DrawString(steam, font, new SolidBrush(GetSteamColor(steam)), new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);

                    containerPostionY = 380;
                    startX = padding;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, nowPrice, font, containerWidth);
                    stringSize = g.MeasureString(nowPrice, font);
                    g.DrawString(nowPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("????????????", 30);
                    DrawRank(discount, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, lowest, font, containerWidth);
                    stringSize = g.MeasureString(lowest, font);
                    g.DrawString(lowest, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));

                    startX += gap;
                    font = new Font("????????????", 20);
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("?????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 3), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, lowestArea, font, containerWidth);
                    stringSize = g.MeasureString(lowestArea, font);
                    g.DrawString(lowestArea, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 15));
                    font = AdjustFontSize(g, lowestAreaPrice, font, containerWidth);
                    stringSize = g.MeasureString(lowestAreaPrice, font);
                    g.DrawString(lowestAreaPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 + 5));
                    font = new Font("????????????", 30);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("???????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, heyboxPrice, font, containerWidth);
                    stringSize = g.MeasureString(heyboxPrice, font);
                    g.DrawString(heyboxPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));

                    startX += gap;
                    font = new Font("????????????", 30);
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("???????????????", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('???', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, heybox, font, containerWidth);
                    stringSize = g.MeasureString(heybox, font);
                    g.DrawString(heybox, font, new SolidBrush(GetHeyboxColor(heybox)), new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                }
                return bitmap;
            }
            public static void DrawRank(string rank, Graphics g, int containerX, int containerY, int containerWidth)
            {
                if (string.IsNullOrWhiteSpace(rank) is false)
                {
                    Font font = new Font("????????????", 10);
                    g.DrawString(rank, font, Brushes.White, new Point(containerX + containerWidth - (int)g.MeasureString(rank, font).Width - 2, containerY + 2));
                }
            }

            public static Font AdjustFontSize(Graphics g, string text, Font origin, int maxWidth)
            {
                if (g.MeasureString(text, origin).Width > maxWidth)
                {
                    while (g.MeasureString(text, origin).Width > maxWidth)
                    {
                        origin = new Font(origin.FontFamily, origin.Size - 1);
                    }
                }
                return origin;
            }
            public static Color GetSteamColor(string steam)
            {
                if (int.TryParse(steam.Replace("%", ""), out int score) is false)
                    return Color.White;
                if (score < 30)
                    return Color.FromArgb(163, 76, 37);
                else if (score < 70)
                    return Color.FromArgb(225, 196, 138);
                else
                    return Color.FromArgb(102, 192, 244);
            }
            public static Color GetHeyboxColor(string heybox)
            {
                double score = Convert.ToDouble(heybox);
                if (score < 4)
                    return Color.FromArgb(99, 208, 28);
                else if (score < 6)
                    return Color.FromArgb(57, 171, 244);
                else if (score < 9)
                    return Color.FromArgb(232, 88, 251);
                else
                    return Color.FromArgb(252, 138, 38);
            }
            public static Bitmap DrawRoundRect(int width, int height, int borderRadius, Brush fill)
            {
                Bitmap bitmap = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    GraphicsPath path = new GraphicsPath();
                    //left top
                    path.AddArc(new Rectangle(new Point(0, 0), new Size(borderRadius * 2, borderRadius * 2)), 180, 90);
                    path.AddLine(new Point(borderRadius - 1, 0), new Point(width - borderRadius + 1, 0));

                    //right top
                    path.AddArc(new Rectangle(new Point(width - borderRadius * 2, 0), new Size(borderRadius * 2, borderRadius * 2)), 270, 90);
                    path.AddLine(new Point(width, borderRadius - 1), new Point(width, height - borderRadius + 1));

                    //right bottom
                    path.AddArc(new Rectangle(new Point(width - borderRadius * 2, height - borderRadius * 2), new Size(borderRadius * 2, borderRadius * 2)), 0, 90);
                    path.AddLine(new Point(borderRadius - 1, height), new Point(width - borderRadius + 1, height));

                    //left bottom
                    path.AddArc(new Rectangle(new Point(0, height - borderRadius * 2), new Size(borderRadius * 2, borderRadius * 2)), 90, 90);
                    path.AddLine(new Point(0, borderRadius - 1), new Point(0, height - borderRadius + 1));

                    g.FillPath(fill, path);
                }
                return bitmap;
            }

        }
    }
}
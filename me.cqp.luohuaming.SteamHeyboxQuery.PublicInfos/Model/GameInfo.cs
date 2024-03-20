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
        public Result result { get; set; }

        public class GameData
        {
            public string rank { get; set; }
            public string value { get; set; }
            public string desc { get; set; }
        }

        public class UserNum
        {
            public IList<GameData> game_data { get; set; }
        }

        public class MenuV2
        {
            public object value { get; set; }
            public string title { get; set; }
        }

        public class HeyboxPrice
        {
            public int cost_coin { get; set; }
        }

        public class MinimumPrice
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Price
        {
            public string current { get; set; }
            public int discount { get; set; }
            public int lowest_price { get; set; }
        }

        public class HotTag
        {
            public string desc { get; set; }
        }

        public class Result
        {
            public int steam_appid { get; set; }
            public UserNum user_num { get; set; }
            public string image { get; set; }
            public IList<MenuV2> menu_v2 { get; set; }
            public HeyboxPrice heybox_price { get; set; }           
            public string score { get; set; }
            public string positive_desc { get; set; }
            public IList<object> publishers { get; set; }
            public string platf { get; set; }
            public MinimumPrice minimum_price { get; set; }
            public Price price { get; set; }
            public bool is_free { get; set; }            
            public string name { get; set; }
            public IList<HotTag> hot_tags { get; set; }

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
                sb.AppendLine($"tag: {string.Join(" ", hot_tags.Select(x => x.desc).ToList())}");
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
                    priceStr = priceStr.Replace("{heybox_price}", $"￥{heybox_price?.cost_coin / 1000}");
                    sb.AppendLine(priceStr);
                }
                return sb.ToString();
            }
            public Bitmap DrawSteamImg()
            {
                #region 数据初始化

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
                        if (item.desc == "Steam好评率")
                        {
                            steam = item.value;
                        }
                        else if (item.desc == "当前在线")
                        {
                            online = item.value;
                            onlineRank = item.rank;
                        }
                        else if (item.desc == "本月平均在线")
                        {
                            month = item.value;
                            monthRank = item.rank;
                        }
                        else if (item.desc == "平均游戏时间")
                        {
                            avg = item.value;
                            avgRank = item.rank;
                        }
                        else if (item.desc == "小黑盒玩家数")
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
                if (positive_desc != null && positive_desc.Contains("好评率"))
                {
                    steam = positive_desc.Replace("Steam好评率：", "");
                }
                if (is_free)
                {
                    nowPrice = "免费";
                }
                else
                {
                    if (price != null)
                    {
                        nowPrice = "￥" + price.current;
                        discount = price.discount == 0 ? "" : $"-{price.discount}%";
                        lowest = price.lowest_price == 0 ? "￥" + price.current : "￥" + price.lowest_price.ToString();
                        lowestArea = heybox_price == null ? "--" : minimum_price.name;
                        lowestAreaPrice = heybox_price == null ? "--" : minimum_price.value;
                        heyboxPrice = heybox_price == null ? "--" : $"￥{heybox_price.cost_coin / 1000}";
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
                    Font font = new Font("微软雅黑", 30, GraphicsUnit.Pixel);
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
                        g.DrawString("暂无图片", new Font("微软雅黑", 36, GraphicsUnit.Pixel), Brushes.White, new Point(10, 120));
                    }
                    Font smallFont = new Font("微软雅黑", 16, GraphicsUnit.Pixel);
                    font = new Font("微软雅黑", 20, GraphicsUnit.Pixel);

                    point = new Point(400, 58);
                    g.DrawString("开发商：", smallFont, Brushes.White, point);
                    point = new Point(400, 82);
                    font = AdjustFontSize(g, publisher, font, 180);
                    g.DrawString(publisher, font, Brushes.White, point);

                    point = new Point(400, 110);
                    font = new Font("微软雅黑", 20, GraphicsUnit.Pixel);
                    g.DrawString("发行日期：", smallFont, Brushes.White, point);
                    point = new Point(400, 134);
                    font = AdjustFontSize(g, releaseDate, font, 180);
                    g.DrawString(releaseDate, font, Brushes.White, point);

                    point = new Point(padding, 247);
                    foreach (var tag in tags)
                    {
                        font = new Font("微软雅黑", 13, GraphicsUnit.Pixel);
                        var tmp = g.MeasureString(tag, font);
                        g.DrawImage(DrawRoundRect((int)tmp.Width + 6, (int)tmp.Height + 4, 2, new SolidBrush(Color.FromArgb(33, 57, 74))), point);
                        g.DrawString(tag, font, new SolidBrush(Color.FromArgb(103, 193, 245)), new Point(point.X + 4, point.Y + 2));
                        point = new Point(point.X + (int)tmp.Width + 6 + 4, point.Y);
                    }
                    font = new Font("微软雅黑", 32, GraphicsUnit.Pixel);
                    int containerWidth = 100, containerHeight = 100;
                    Bitmap container = DrawRoundRect(containerWidth, containerHeight, 5, new LinearGradientBrush(new Point(0, 0), new Point(60, 120), Color.FromArgb(44, 60, 73), Color.FromArgb(88, 103, 117)));

                    int containerPostionY = 275, gap = containerWidth + 5;
                    //int startX = (int)(300 - (containerWidth * 0.5) - gap);
                    int startX = padding;

                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("在线人数", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, online, font, containerWidth);
                    var stringSize = g.MeasureString(online, font);
                    g.DrawString(online, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    DrawRank(onlineRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("月活跃人数", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, month, font, containerWidth);
                    stringSize = g.MeasureString(month, font);
                    g.DrawString(month, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    DrawRank(monthRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("平均时长", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, avg, font, containerWidth);
                    stringSize = g.MeasureString(avg, font);
                    g.DrawString(avg, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    DrawRank(avgRank, g, startX, containerPostionY, containerWidth);


                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("小黑盒玩家", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, heyboxPlayer, font, containerWidth);
                    stringSize = g.MeasureString(heyboxPlayer, font);
                    g.DrawString(heyboxPlayer, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    DrawRank(heyboxPlayerRank, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("Steam好评率", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString("Steam好评率", smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, steam, font, containerWidth);
                    stringSize = g.MeasureString(steam, font);
                    g.DrawString(steam, font, new SolidBrush(GetSteamColor(steam)), new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);

                    containerPostionY = 380;
                    startX = padding;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("当前价格", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, nowPrice, font, containerWidth);
                    stringSize = g.MeasureString(nowPrice, font);
                    g.DrawString(nowPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    DrawRank(discount, g, startX, containerPostionY, containerWidth);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("国区史低", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 4), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, lowest, font, containerWidth);
                    stringSize = g.MeasureString(lowest, font);
                    g.DrawString(lowest, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));

                    startX += gap;
                    font = new Font("微软雅黑", 26, GraphicsUnit.Pixel);
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("最低价", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 3), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, lowestArea, font, containerWidth);
                    stringSize = g.MeasureString(lowestArea, font);
                    g.DrawString(lowestArea, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 15));
                    font = AdjustFontSize(g, lowestAreaPrice, font, containerWidth);
                    stringSize = g.MeasureString(lowestAreaPrice, font);
                    g.DrawString(lowestAreaPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 + 5));
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);

                    startX += gap;
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("小黑盒价格", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 5), smallFont).Width) / 2, containerPostionY + 70));
                    font = AdjustFontSize(g, heyboxPrice, font, containerWidth);
                    stringSize = g.MeasureString(heyboxPrice, font);
                    g.DrawString(heyboxPrice, font, Brushes.White, new Point(startX + (containerWidth - (int)stringSize.Width) / 2, containerPostionY + (containerHeight - (int)stringSize.Height) / 2 - 5));

                    startX += gap;
                    font = new Font("微软雅黑", 36, GraphicsUnit.Pixel);
                    g.DrawImage(container, new Point(startX, containerPostionY));
                    g.DrawString("小黑盒评分", smallFont, Brushes.White, new Point(startX + (containerWidth - (int)g.MeasureString(new string('啊', 5), smallFont).Width) / 2, containerPostionY + 70));
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
                    Font font = new Font("微软雅黑", 16, GraphicsUnit.Pixel);
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
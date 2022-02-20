# BotDevelopmentFramework

## 介绍
CQ机器人开发白框架

## 使用流程
1. Clone项目
2. 使用`VSCode`打开项目目录
3. 全局替换文本 `me.cqp.luohuaming.SteamHeyboxQuery.` 到 `me.cqp.luohuaming.需要的插件英文.`
4. 全局替换文本 `SteamHeyboxQuery.` 到 `需要的插件英文.`
5. 重命名文件夹 `me.cqp.luohuaming.SteamHeyboxQuery.Core` `me.cqp.luohuaming.SteamHeyboxQuery.Sdk` `me.cqp.luohuaming.SteamHeyboxQuery.Tool` 的 `me.cqp.luohuaming.SteamHeyboxQuery.` 到 `me.cqp.luohuaming.需要的插件英文`
6. 进入这些文件夹, 对其中的 `me.cqp.luohuaming.SteamHeyboxQuery.Core.csporj`等文件 的 `me.cqp.luohuaming.SteamHeyboxQuery.` 进行同理替换
7. 重命名`me.cqp.luohuaming.SteamHeyboxQuery.PublicInfo`的程序集名称
8. 对Core项目的属性-程序集名称进行替换
7. 使用`VS2019`打开项目
8. 所有项目的引用重新引用一遍
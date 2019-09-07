
备忘：
2019-09-02
时间长了，FineUI的Razor代码真Tama的不是一般的乱，尤其是队伍里一群虎逼一起开发的时候，破笔括号、点号各种换行，代码可读性急剧降低，因此：

1、VS需要安装Visual Studio SDK
2、新建“Empty VSIX Project”
3、添加“Custom Command”
4、修改vsct文件内的ButtonText，该名字是VS“工具”菜单里面显示的名字。
5、在cs文件Execute函数中，通过Package.GetGlobalService获取到DTE，然后对当前活动的text文件执行源码格式化。

2019-09-07

几乎重写了格式化规则的代码，增加一个WinForm，便于调试
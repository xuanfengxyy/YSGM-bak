using System.Configuration;
using YSGM;

Console.WriteLine(@"
██╗   ██╗███████╗ ██████╗ ███╗   ███╗
╚██╗ ██╔╝██╔════╝██╔════╝ ████╗ ████║
 ╚████╔╝ ███████╗██║  ███╗██╔████╔██║
  ╚██╔╝  ╚════██║██║   ██║██║╚██╔╝██║
   ██║   ███████║╚██████╔╝██║ ╚═╝ ██║
   ╚═╝   ╚══════╝ ╚═════╝ ╚═╝     ╚═╝
                                     
");
CommandMap.RegisterAll();

// 创建提示界面

while (true)
{
    Console.Write("> ");
    var userInput = Console.ReadLine();
    string[] split = userInput!.Split(' ');
    string cmd = split[0];
    // 如果用户输入了有效的命令，执行它
    if (CommandMap.handlers.ContainsKey(cmd))
    {
        var handler = CommandMap.handlers[cmd];
        var arguments = split.Skip(1).ToArray();
        Console.WriteLine(handler.Execute(arguments));
    }
    else
    {
        Console.WriteLine("无效指令");//"Invalid command."
    }
}
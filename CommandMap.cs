using YSGM.Handlers;

namespace YSGM
{
    public class CommandMap
    {
        public static Dictionary<string, BaseCommand> handlers = new();

        public static void RegisterAll()
        {
            handlers.Add("shell", new ShellCommand()); // SSH shell
            handlers.Add("sql", new SQLCommand()); // SQL 查询
            handlers.Add("gm", new GMCommand()); // GM 命令
            handlers.Add("mail", new MailCommand()); // 发送邮件
            handlers.Add("muip", new MUIPCommand()); // 原始 MUIP 查询 raw MUIP query

            // 退出app
            handlers.Add("exit", new ExitCommand());
            handlers.Add("quit", new ExitCommand());

            // 玩家数据
            handlers.Add("pull", new PullCommand());
            handlers.Add("push", new PushCommand());
        }
    }
}

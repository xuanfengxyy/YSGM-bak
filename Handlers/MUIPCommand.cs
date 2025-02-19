﻿namespace YSGM.Handlers
{
    public class MUIPCommand : BaseCommand
    {
        public string Execute(string[] args)
        {
            if (args.Length < 2)
            {
                return "用法: muip <cmd_id> [key=value,key2=value2]";
            }
            int cmd = Convert.ToInt32(args[0]);
            string msg = string.Join(" ", args.Skip(1));
            // 解析到字典中
            Dictionary<string, string> param = new();
            foreach (string pair in msg.Split(','))
            {
                string[] split = pair.Split('=');
                param.Add(split[0], split[1]);
            }
            return MUIPManager.Instance.GET(cmd, param);
        }
    }
}

﻿namespace YSGM.Handlers
{
    public class SQLCommand : BaseCommand
    {
        public string Execute(string[] args)
        {
            if (args.Length < 2)
            {
                return "用法: sql <db> <query>";
            }
            var a = SQLManager.Instance.Execute(args[0], args.Skip(1).Aggregate((x, y) => x + " " + y));
            return a.InnerXml;
        }
    }
}

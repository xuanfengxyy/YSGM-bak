﻿using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YSGM
{
    public class MUIPManager
    {
        public static MUIPManager Instance = new();

        private MUIPManager() { }

        public string GM(string uid, string cmd)
        {
            return GET(1116, new Dictionary<string, string>()
            {
                { "uid", uid },
                { "msg", cmd }
            });
        }

        public string FetchPlayerBin(string uid)
        {
            return GET(1004, new Dictionary<string, string>()
            {
                { "uid", uid }
            });
        }

        public string GET(int cmd, Dictionary<string, string> param) // 这两个都是数字，但为了方便起见，类型是字符串
        {
#if DEBUG
            var builder = new UriBuilder("http://gs-console.moeyy.cn/api");//("http://hk4e-storage.mihoyo.com:14311/api");
#else
            var builder = new UriBuilder(ConfigurationManager.AppSettings.Get("MUIP_HOST")!);
#endif
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach(KeyValuePair<string, string> entry in param) {
                query[entry.Key] = entry.Value;
            }
            query["cmd"] = cmd.ToString();
            query["region"] = ConfigurationManager.AppSettings.Get("MUIP_TARGET_REGION");
            query["ticket"] = $"YSGM@{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            query["sign"] = SHA($"{query.ToString()}1d8z98SAKF98bdf878skswa8kdjfy1m9dses");
            builder.Query = query.ToString();

            var client = new HttpClient();

            string url = builder.ToString();
            url = url.Replace("%2c", ",");
            url = url.Replace("%3d", "=");
            url = url.Replace("%3a", ":");

            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.Send(webRequest);

            using var reader = new StreamReader(response.Content.ReadAsStream());

            return reader.ReadToEnd();
        }

        private string SHA(string str)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(str));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}

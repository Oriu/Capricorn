using Microsoft.Extensions.Configuration;
using System.IO;

namespace Capricorn.Util
{
    /// <summary>
    /// 描 述：Config文件操作
    /// </summary>
    public class Config
    {
        private static IConfiguration _configuration;

        static Config()
        {
            BuildConfiguration();
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false).AddJsonFile("appsettings.Development.json", true);
            _configuration = builder.Build();
        }

        /// <summary>
        /// 读取指定节点信息
        /// </summary>
        /// <param name="key">节点名称，多节点以:分隔</param>
        public static string Get(string key)
        {
            return _configuration[key];
        }
    }
}

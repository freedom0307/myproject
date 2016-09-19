using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace serialization.IO
{
    public  class MyIO
    {
        /// <summary>
        /// 配置绝对路径
        /// </summary>
        public static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        /// <summary>
        /// 获取当前程序路径
        /// </summary>
        public static string LogPathCurrent = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 读取文件夹，文件信息
        /// </summary>
        public static void show()
        {
            ///Directory
            {
                bool isExist = Directory.Exists(LogPath);
                Directory.Move(LogPath, LogMovePath);
                Directory.Delete(LogMovePath);
            }
        }
    }
}

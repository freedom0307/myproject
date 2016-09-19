using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace serialization
{
    class Program
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
                if (!isExist)
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);
                    Directory.Move(LogPath, LogMovePath);
                    Directory.Delete(LogMovePath);
                }

            }
        }
        static void Main(string[] args)
        {
            ///Directory
            {
                bool isExist = Directory.Exists(LogPath);
                if (!isExist)
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);
                    Directory.Move(LogPath, LogMovePath);
                    Directory.Delete(LogMovePath);
                }

            }
            //fiile
            {
                string fileName = Path.Combine(LogPath, " Log.txt");
                string fileNameCopy = Path.Combine(LogPath, " LogCopy.txt");
                string fileNameMove = Path.Combine(LogPath, " LogMove.txt");
                bool isExist = File.Exists(fileName);
                if (!isExist)
                {
                    Directory.CreateDirectory(LogPath);
                    using (FileStream stream = File.Create(fileName))
                    {
                        byte[] bytes = new byte[10] { (byte)1, (byte)2, (byte)3, (byte)4, (byte)5, (byte)6, (byte)7, (byte)8, (byte)9, (byte)29 };
                        stream.Write(bytes, 0, 10);
                        stream.Flush();
                    }
                    string msg = "今天是eleven老师的课，上课的有200人";
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(msg);
                        sw.Flush();
                    }
                    foreach (string str in File.ReadAllLines(fileName)) 
                    {
                        Console.WriteLine(str);
                    }

                    using (FileStream stream = File.OpenRead(fileName ))
                    {
                        int L = 5, result = 0;
                        do
                        {
                            byte[] bytes = new byte[L];
                            result = stream.Read(bytes, 0, L);
                            for (int i=0;i<result;i++)
                            {
                                Console.WriteLine(bytes [i ].ToString ());
                            }
                        }
                        while (L == result);
                    }
                    File.Copy(fileName, fileNameCopy);
                    File.Move(fileName, fileNameMove);
                    File.Delete(fileNameCopy);
                    File.Delete(fileNameMove);
                }
            }
        }
    }
}


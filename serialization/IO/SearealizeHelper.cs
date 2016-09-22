using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serialization.IO
{
    public  class SearealizeHelper
    {
        public static List<Programmer > GetProgrammerList()
        {
            List<Programmer> Plist = new List<IO.Programmer>();
            Plist.Add(new IO.Programmer() { name = "快乐阳光",sex = "男"} );
            Plist.Add(new IO.Programmer() { name = "荼蘼", sex = "女" });
            Plist.Add(new IO.Programmer() { name = "笑对人生", sex = "男" });
            Plist.Add(new IO.Programmer() { name = "萌萌的", sex = "男" });
            Plist.Add(new IO.Programmer() { name = "红领巾", sex = "男" });
            return Plist;
        }
        public static string CurrentDataPath = ConfigurationManager.AppSettings["CurrentDataPath"];

        public static void BinarySerialize()
        {
            string filename = Path.Combine(CurrentDataPath, @"BinarySerialization.txt");
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<Programmer> Plsit = GetProgrammerList();
                bf.Serialize(fs, Plsit );
            }
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<Programmer> Plsit = GetProgrammerList();
                Plsit.Clear();
                fs.Position = 0;
                Plsit =(List <Programmer >) bf.Deserialize (fs );
            }
        }

    }
}

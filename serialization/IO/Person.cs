using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialization.IO
{
    [Serializable ]
    public  class Person
    {
        public int  ID=1;
        public string name { get; set; }
        public string sex { get; set; }

    }
    [Serializable]
    public class Programmer:Person
    {
        public string language { get; set; }
    }
}

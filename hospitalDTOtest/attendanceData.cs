using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalDTO
{
    public class attendanceData
    {
        public int attTime { get; set; }
        public string attPri { get; set; }
        public int[] attArr { get; set; } = new int[62];
        public int remainTime { get; set; }
        public bool success { get; set; }
    }
}

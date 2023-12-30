using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Utils
{
    internal class Automation
    {
        public static string MaBN()
        {
            string maBN = "BN" + DateTime.Now.ToString("yyMMdd00HHmmss");
            return maBN;
        }
    }
}

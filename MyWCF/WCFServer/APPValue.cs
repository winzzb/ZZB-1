using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    static class AppValue
    {
//
        public static AppParam _appParam = new AppParam();
        static public AppParam GetParam()
        {
            return _appParam;
        }
    }
}

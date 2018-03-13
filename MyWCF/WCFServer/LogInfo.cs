using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class LogInfo
    {
        public string _info;
        public string _time;

        public LogInfo()
        {
        }

        public LogInfo(string info, string time)
        {
            this._info = info;
            this._time = time;
        }

        public void InitLogMsg(string msgContent)
        {

            LogInfo _info = new LogInfo
            {
                _info = msgContent,
                _time = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };
            Program.Get_ILog().Log(_info);
        }

    }
}

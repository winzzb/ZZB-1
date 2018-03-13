using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFServer
{
    static class Program
    {
        static WcfServer _trForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _trForm = new WcfServer();
            Application.Run(_trForm);
        }

        /// <summary>
        /// 应用程序日志
        /// </summary>
        /// <returns></returns>
        public static ILog Get_ILog()
        {
            return _trForm;
        }
    }
}

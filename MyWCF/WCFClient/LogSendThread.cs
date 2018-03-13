using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileInterface;

namespace WCFClient
{
    class LogSendThread
    {
        public string _logMsg;
        public ITransfer _proxy;

        public void SendLog()
        {
            try
            {
                _proxy.TransferLog(_logMsg);
            }
            catch (Exception ex)
            {
            }
            finally
            {
               
            }
        }
    }
}

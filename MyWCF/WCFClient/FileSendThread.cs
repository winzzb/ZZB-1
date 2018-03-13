using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileInterface;

namespace WCFClient
{
    class FileSendThread
    {
        public FileTransferMessage _file;
        public ITransfer _proxy;
        public void SendFile()
        {
            try
            {
                _proxy.TransferFile(_file);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (_file.FileData != null)
                {
                    _file.FileData.Close();
                }
            }
        }
    }
}

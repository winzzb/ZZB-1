using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileInterface
{
    [ServiceContract]
    public interface ITransfer
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="request"></param>
        [OperationContract(Action = "UploadFile")]
        void TransferFile(FileTransferMessage request);//文件传输

        /// <summary>
        /// 获取文件列表
        /// </summary>
        [OperationContract]
        string[] GetFilesList();
        /// <summary>
        /// 下载文件
        /// </summary>
        [OperationContract]
        DownFileResult DownLoadFile(DownFile downfile);

        /// <summary>
        /// 日志传输
        /// </summary>
        /// <param name="request"></param>
        [OperationContract(Action = "LogView")]
        void TransferLog(string request);

    }


    [MessageContract]
    public class FileTransferMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string SavePath;//文件保存路径

        [MessageHeader(MustUnderstand = true)]
        public string FileName;//文件名称

        [MessageBodyMember(Order = 1)]
        public Stream FileData;//文件传输时间
    }

    [MessageContract]
    public class DownFile
    {
        [MessageHeader]
        public string FileName { get; set; }
    }

    [MessageContract]
    public class DownFileResult
    {
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public bool IsSuccess { get; set; }
        [MessageHeader]
        public string Message { get; set; }
        [MessageBodyMember]
        public Stream FileStream { get; set; }
    }
}

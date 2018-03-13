using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FileInterface;

namespace WCFServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Transfer : ITransfer
    {
        private readonly LogInfo _info = new LogInfo();
        private string _msgContent;
        /// <summary>3
        /// 服务器地图文件保存路径
        /// </summary>
        private string savePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["TransferFilePath"];

        public void TransferFile(FileTransferMessage request)
        {
            _msgContent = string.Format("开始接收文件,name={0}", request.FileName);

            //打印日志
            _info.InitLogMsg(_msgContent);


            //文件信息
            string uploadFolder = AppValue.GetParam()._saveDir;
            string savaPath = request.SavePath;
            string fileName = request.FileName;
            Stream sourceStream = request.FileData;
            //判断文件是否可读
            if (!sourceStream.CanRead)
            {
                throw new Exception("数据流不可读!");
            }
            if (savaPath == null) savaPath = @"文件传输\";
            if (!savaPath.EndsWith("\\")) savaPath += "\\";
            if (!uploadFolder.EndsWith("\\")) uploadFolder += "\\";

            uploadFolder = uploadFolder + savaPath;
            //创建保存文件夹
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            int fileSize = 0;
            string filePath = Path.Combine(uploadFolder, fileName);//Combine合并两个路径
            try
            {
                //文件流传输
                FileStream targetStream;
                using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //定义文件缓冲区
                    const int bufferLen = 4096;
                    var buffer = new byte[bufferLen];
                    int count;

                    while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                    {
                        targetStream.Write(buffer, 0, count);
                        fileSize += count;
                    }
                    targetStream.Close();
                    sourceStream.Close();
                }
            }
            catch (Exception ex)
            {
                //打印日志
                _info.InitLogMsg(ex.Message);
            }

            //打印日志
            _msgContent = string.Format("接收文件完毕 name={0},filesize={1}", request.FileName, fileSize);
            _info.InitLogMsg(_msgContent);
           
        }

        public string[] GetFilesList()
        {
            if (!Directory.Exists(savePath))//判断文件夹路径是否存在11111
            {
                return null;
            }
            DirectoryInfo myDirInfo = new DirectoryInfo(savePath);
            FileInfo[] myFileInfoArray = myDirInfo.GetFiles("*.*");
            string[] myFileList = new string[myFileInfoArray.Length];
            //文件排序
            for (int i = 0; i < myFileInfoArray.Length - 1; i++)
            {
                for (int j = i + 1; j < myFileInfoArray.Length; j++)
                {
                    if (myFileInfoArray[i].LastWriteTime > myFileInfoArray[j].LastWriteTime)
                    {
                        FileInfo myTempFileInfo = myFileInfoArray[i];
                        myFileInfoArray[i] = myFileInfoArray[j];
                        myFileInfoArray[j] = myTempFileInfo;
                    }
                }
            }
            for (int i = 0; i < myFileInfoArray.Length; i++)
            {
                myFileList[i] = myFileInfoArray[i].Name;
            }
            return myFileList;
        }

        public DownFileResult DownLoadFile(DownFile downfile)
        {
            DownFileResult result = new DownFileResult();

            string path = savePath + @"\" + downfile.FileName;

            if (!File.Exists(path))
            {
                result.IsSuccess = false;
                result.FileSize = 0;
                result.Message = "服务器不存在此文件";
                result.FileStream = new MemoryStream();
                return result;
            }
            Stream ms = new MemoryStream();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.CopyTo(ms);
            ms.Position = 0;  //重要，不为0的话，客户端读取有问题
            result.IsSuccess = true;
            result.FileSize = ms.Length;
            result.FileStream = ms;

            fs.Flush();
            fs.Close();

            //打印日志
            _msgContent = string.Format("接收文件完毕 name={0},filesize={1}", downfile.FileName, result.FileSize);
            _info.InitLogMsg(_msgContent);
            return result;
        }



        public void TransferLog(string request)
        {
            //打印日志
            _info.InitLogMsg(request);
        }
    }
}

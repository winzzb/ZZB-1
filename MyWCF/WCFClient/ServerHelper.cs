using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    static class ServerHelper
    {
        public static string ServerFilePath
        {
            get
            {
                // 获取客户端中定义的服务器地址111
                ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
                if (clientSection == null)
                {
                    return "";
                }
                ChannelEndpointElementCollection collection = clientSection.Endpoints;
                Uri uri = collection[0].Address;
                return "http://" + uri.Authority + "//UpLoadFile";
            }
        }

        /// <summary>
        /// 服务器存放文件的文件夹地址
        /// </summary>
        public static string ServerFolderPath
        {
            //get { return @"E:\WCFCESHI1\UpLoadFile"; }
            get { return @"C:\Test"; }
        }
    }
}

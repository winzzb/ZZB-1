using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInformation
{
    public static class HardwareInfo
    {
        #region 硬件属性
        /// <summary> 
        /// 获取主机名 
        /// </summary> 
        /// <returns></returns> 
        public static string HostName
        {
            get
            {
                string hostname = Dns.GetHostName();
                return hostname;
            }
        }

        /// <summary>
        /// CPU编号
        /// </summary>
        public static string CPUID
        {
            get { return GetCpuID(); }
        }

        /// <summary>
        /// 硬盘编号
        /// </summary>
        public static string HardDiskID
        {
            get { return GetHardDiskID(); }
        }

        /// <summary>
        /// 网卡MAC
        /// </summary>
        public static string NetMac
        {
            get { return GetMac(); }
        }

        /// <summary>
        /// IPAddress
        /// </summary>
        public static string IPAddress
        {
            get { return GetIPAddress(); }
        }

        /// <summary>
        /// 系统标识符和版本号 
        /// </summary>
        public static string OSVersion
        {
            get { return Environment.OSVersion.ToString(); }
        }

        /// <summary>
        /// 获取映射到进程上下文的物理内存量 
        /// </summary>
        public static string WorkingSet
        {
            get { return Environment.WorkingSet.ToString(); }
        }

        /// <summary>
        /// 获取系统启动后经过的毫秒数 
        /// </summary>
        public static int TickCount
        {
            get { return Environment.TickCount/60000; }
        }

        /// <summary>
        /// 系统目录的完全限定路径 
        /// </summary>
        public static string SystemDirectory
        {
            get { return Environment.SystemDirectory; }
        }

        /// <summary>
        /// 获取此本地计算机的 NetBIOS 名称 
        /// </summary>
        public static string MachineName
        {
            get { return Environment.MachineName; }
        }

        /// <summary>
        /// 获取与当前用户关联的网络域名
        /// </summary>
        public static string UserDomainName
        {
            get { return Environment.UserDomainName; }
        }

        /// <summary>
        /// 获取与当前用户关联的网络域名
        /// </summary>
        public static string[] LogicalDrives
        {
            get { return System.IO.Directory.GetLogicalDrives(); }
        }
        #endregion

        #region 获取硬件信息的方法
        /// <summary>
        /// 获得CPU编号
        /// </summary>
        /// <returns></returns>
        private static string GetCpuID()
        {
            string result = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    result = mo.Properties["ProcessorId"].Value.ToString();
                }
            }
            catch
            {
                return "获取CPUID失败";
            }
            return result;
        }

        /// <summary>
        /// 获得硬盘编号
        /// </summary>
        /// <returns></returns>
        private static string GetHardDiskID()
        {
            string result = "";
            try
            {
                ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                ManagementObjectCollection mocHD = mcHD.GetInstances();
                foreach (ManagementObject m in mocHD)
                {
                    if (m["DeviceID"].ToString() == "C:")
                    {
                        result = m["VolumeSerialNumber"].ToString().Trim();
                    }
                }
            }
            catch
            {
                return "获取硬盘ID失败";
            }
            return result;
        }

        /// <summary>
        /// 获得网卡MAC
        /// </summary>
        /// <returns></returns>
        private static string GetMac()
        {
            string result = "";
            try
            {
                ManagementClass mcMAC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection mocMAC = mcMAC.GetInstances();
                foreach (ManagementObject m in mocMAC)
                {
                    if ((bool)m["IPEnabled"])
                    {
                        result = m["MacAddress"].ToString();
                    }
                }
            }
            catch
            {
                return "获取MAC失败";
            }
            return result;
        }


        /// <summary> 
        /// 获取IP地址 
        /// </summary> 
        /// <returns></returns> 
        public static string GetIPAddress()
        {
            try
            {
                //获取IP地址 
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        System.Array ar;
                        ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }
        #endregion
    }
}

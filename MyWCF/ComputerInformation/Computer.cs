using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInformation
{
    public static class Computer
    {
        //主机名
        public static string HostName = HardwareInfo.HostName;
        //CPU编号
        public static string CPUID = HardwareInfo.CPUID;
        //硬盘编号
        public static string HardDiskID = HardwareInfo.HardDiskID;
        //网卡MAC
        public static string NetMac = HardwareInfo.NetMac;
        //IPAddress
        public static string IPAddress = HardwareInfo.IPAddress;



    }
}

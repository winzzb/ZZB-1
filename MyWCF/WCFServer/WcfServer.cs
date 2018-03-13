using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFServer
{
    public partial class WcfServer : Form, ILog
    {
        #region 初始化变量
        public ServiceHost MyServiceHost;//使用 ServiceHost 对象加载服务、配置终结点、应用安全设置并启用侦听程序来处理传入的请求。
        public delegate bool FormAddLog(LogInfo info);

        private LogInfo info = new LogInfo();

        readonly FormAddLog _formAddLog;
        AppParam _appParam;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化构造函数
        /// </summary>
        public WcfServer()
        {
            InitializeComponent();

            _formAddLog = Log;  //初始化一个日志实例
        }

        /// <summary>
        /// 记录上传文件信息，将文件信息显示在ListBox
        /// </summary>
        /// <param name="info">文件路径</param>
        /// <returns></returns>
        public bool Log(LogInfo info)
        {
            if (InvokeRequired)
            {
                Invoke(_formAddLog, info);
                return true;
            }
            var sbInfo = new StringBuilder();
            sbInfo.Append("运行时间: ");
            sbInfo.Append(info._time);

            sbInfo.Append("    ");

            sbInfo.Append("运行信息: ");
            sbInfo.Append(info._info);

            sbInfo.Append("\n");

            rtLog.AppendText(sbInfo.ToString());
            return true;
        }
        #endregion


        #region 控件事件
        private void WcfServer_Load(object sender, EventArgs e)
        {
            InitLog();
        }

        void InitLog()
        {
            btnWCFClose.Enabled = false;
            _appParam = AppValue.GetParam();
            AppParam.Load(ref _appParam);
            _appParam._saveDir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["TransferFilePath"];
            var dirPath = "上传地址:" + _appParam._saveDir;

            info.InitLogMsg("界面开启");
            info.InitLogMsg(dirPath);
        }

        private void btnWCFStart_Click(object sender, EventArgs e)
        {
            if (MyServiceHost == null)
            {
                var threadRead = new Thread(ServerStart);
                threadRead.Start();
                btnWCFStart.Enabled = false;
                btnWCFClose.Enabled = true;
                lblMsg.Text = @"服务已经开启";
                SocketStart();
            }
            else
            {
                MyServiceHost.Close();
                MyServiceHost = null;
                btnWCFStart.Enabled = true;

                info.InitLogMsg("停止服务");

                lblMsg.Text = @"服务已经停止";
            }
        }

        void ServerStart()
        {
            try
            {
                MyServiceHost = new ServiceHost(typeof(Transfer));//实例化WCF服务对象
                MyServiceHost.Open();
                lblMsg.Text = @"服务已经开启";
            }
            catch (Exception ex)
            {
                info.InitLogMsg(ex.Message);
                return;
            }
            info.InitLogMsg("启动成功");
        }

        private void btnWCFClose_Click(object sender, EventArgs e)
        {
            MyServiceHost.Close();
            MyServiceHost = null;
            btnWCFStart.Enabled = true;
            btnWCFClose.Enabled = false;
            lblMsg.Text = @"服务已经停止";
            info.InitLogMsg("停止服务");
        }
        #endregion



        #region 函数

        Thread threadWatch = null;// 负责监听客户端的线程
        Socket socketWatch = null;// 负责监听客户端的套接字
        Socket clientConnection = null;// 负责和客户端通信的套接字

       

        void SocketStart()
        {
            var listerIP = ConfigurationManager.AppSettings["ListerIP"];
            var listerPort = ConfigurationManager.AppSettings["ListerPort"];

            if (string.IsNullOrEmpty(listerIP))
            {
                MessageBox.Show("监听ip地址不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(listerPort))
            {
                MessageBox.Show("监听端口不能为空！");
                return;
            }
            // 定义一个套接字用于监听客户端发来的消息，包含三个参数（ipv4寻址协议，流式连接，tcp协议）
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 服务端发送消息需要一个ip地址和端口号
            IPAddress ip = IPAddress.Parse(listerIP);
            // 把ip地址和端口号绑定在网路节点endport上
            IPEndPoint endPort = new IPEndPoint(ip, int.Parse(listerPort));

            // 监听绑定的网路节点
            socketWatch.Bind(endPort);
            // 将套接字的监听队列长度设置限制为0，0表示无限
            socketWatch.Listen(0);
            // 创建一个监听线程
            threadWatch = new Thread(WatchConnecting);
            threadWatch.IsBackground = true;
            threadWatch.Start();
            rtLog.AppendText("成功启动监听！ip：" + ip + "，端口：" + listerPort + "\r\n");
 
        }

        /// <summary>
        ///  监听客户端发来的请求
        /// </summary>
        private void WatchConnecting()
        {
            //持续不断监听客户端发来的请求
            while (true)
            {
                clientConnection = socketWatch.Accept();
                rtLog.AppendText("客户端连接成功！" + "\r\n");
                // 创建一个通信线程
                ParameterizedThreadStart pts = new ParameterizedThreadStart(acceptMsg);
                Thread thr = new Thread(pts);
                thr.IsBackground = true;
                thr.Start(clientConnection);
            }
        }

        /// <summary>
        ///  接收客户端发来的消息
        /// </summary>
        /// <param name="socket">客户端套接字对象</param>
        private void acceptMsg(object socket)
        {
            Socket socketServer = socket as Socket;
            while (true)
            {
                //创建一个内存缓冲区 其大小为1024*1024字节  即1M
                byte[] recMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度
                int length = socketServer.Receive(recMsg);
                //将机器接受到的字节数组转换为人可以读懂的字符串
                string msg = Encoding.UTF8.GetString(recMsg, 0, length);
                rtLog.AppendText("客户端(" + GetCurrentTime() + "):" + msg + "\r\n");
            }
        }

        /// <summary>
        /// 获取当前系统时间的方法
        /// </summary>
        /// <returns>当前时间</returns>
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        /// <summary>
        ///  发送消息到客户端
        /// </summary>
        /// <param name="msg"></param>
        private void serverSendMsg(string msg)
        {
            byte[] sendMsg = Encoding.UTF8.GetBytes(msg);
            clientConnection.Send(sendMsg);
            rtLog.AppendText("服务端(" + GetCurrentTime() + "):" + msg + "\r\n");
        }
        #endregion 

        private void btnSendClient_Click(object sender, EventArgs e)
        {
            serverSendMsg("12312312");
        }

        private void WcfServer_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

       
    }
}

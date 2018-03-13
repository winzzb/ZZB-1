using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using ComputerInformation;
using FileInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class FrmTransferFile : Form
    {
        #region 初始化变量

        private const string MSG_INFO_LINK = @"连接";
        private const string MSG_INFO_UNLINK = @"停止";
        private const string GRID_COLUMN_FILEPATH = @"文件路径";
        ITransfer _proxy;
        readonly DataTable _uploadfiles = new DataTable();
        readonly DataTable _downloadfiles = new DataTable();
        private readonly string _serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
        private readonly string _savePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["TransferFilePath"];
        #endregion 

        #region 构造函数
        public FrmTransferFile()
        {
            InitializeComponent();

            _uploadfiles.Columns.Add(new DataColumn(GRID_COLUMN_FILEPATH, typeof(string)));
            this.dgUploadList.DataSource = _uploadfiles;
            this.dgUploadList.Columns[0].Width = 500;

            _downloadfiles.Columns.Add(new DataColumn(GRID_COLUMN_FILEPATH, typeof(string)));
            this.dgDownloadList.DataSource = _downloadfiles;
            this.dgDownloadList.Columns[0].Width = 500;

            AddUrl();
        }
        #endregion


        #region 控件事件
        private void FrmTransferFile_Load(object sender, EventArgs e)
        {
            Connect();
            SocketStart();
        }

        /// <summary>
        /// 连接文件传输服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            SocketStart();
        }

        /// <summary>
        /// 获取服务端文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetServerDownloadList_Click(object sender, EventArgs e)
        {
            GetServerDownloadList();
        }


        /// <summary>
        /// 选择要发送的文件,添加到DataTable中
        /// </summary>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dialog.FileNames.Length; i++)
                    {
                        DataRow type = _uploadfiles.NewRow();
                        type["文件路径"] = dialog.FileNames[i];
                        try
                        {
                            _uploadfiles.Rows.Add(type);
                        }
                        catch { continue; }
                    }
                }
            }
        }

        /// <summary>
        /// 传输文件
        /// </summary>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string filePath = "";
            for (int i = 0; i < dgUploadList.Rows.Count - 1; i++)
            {
                filePath = dgUploadList.Rows[i].Cells[0].Value.ToString();

                if (filePath == string.Empty)
                {
                    MessageBox.Show(@"请选择要传输的文件");
                    return;
                }
                if (_proxy == null)
                {
                    MessageBox.Show(@"服务已经断开");
                    return;
                }

                FileTransferMessage file = null;
                try
                {
                    file = new FileTransferMessage
                    {
                        FileName = Path.GetFileName(filePath),
                        FileData = new FileStream(filePath, FileMode.Open)
                    };

                    //IContextChannel obj = _proxy as IContextChannel;

                    var sendThread = new FileSendThread {_file = file, _proxy = _proxy};
                    var threadRead = new Thread(new ThreadStart(sendThread.SendFile));
                    threadRead.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            MessageBox.Show(@"文件传输成功");
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoseDownloadFile_Click(object sender, EventArgs e)
        {
            if (dgDownloadList.Rows.Count > 0)
            {
                var _selectRowsCount = dgDownloadList.SelectedRows.Count;
                if (_selectRowsCount > 0)
                {
                    var fileName = dgDownloadList.SelectedRows[0].Cells[0].Value.ToString();

                    DownFile(fileName);
                    MessageBox.Show(@"下载成功！");

                }
                else
                {
                    MessageBox.Show(@"未选中列表内行！");
                }
            }
            else
            {
                MessageBox.Show(@"服务器文件列表无数据！");
            }
        }


        private void btnAllDownloadFile_Click(object sender, EventArgs e)
        {
            DataTable _dt = (DataTable)dgDownloadList.DataSource;
            if (_dt.Rows.Count > 0)
            {
                var fileName = "";
                foreach (DataRow _dr in _dt.Rows)
                {
                    fileName = _dr[0].ToString();
                    DownFile(fileName);
                }
                MessageBox.Show(@"下载成功！");
            }
            else
            {
                MessageBox.Show(@"服务器文件列表无数据！");
            }
        }
        #endregion


        #region 函数
        void Connect()
        {
            if (_proxy == null)
            {
                try
                {
                    NetTcpBinding binding = new NetTcpBinding();
                    binding.TransferMode = TransferMode.Streamed;
                    binding.SendTimeout = new TimeSpan(0, 30, 0);
                    //利用通道创建客户端代理
                    _proxy = ChannelFactory<ITransfer>.CreateChannel(binding, new EndpointAddress(texServerPath.Text));
                    //IContextChannel obj = _proxy as IContextChannel;
                    //string s = obj.SessionId;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                try
                {
                    var strLink = string.Format("客户机 [主机名:{0}, IP地址:{1}, 网卡MAC: {2}, CPU编号:{3}, 硬盘编号{4}] {5}"
                        , Computer.HostName
                        , Computer.IPAddress
                        , Computer.NetMac
                        , Computer.CPUID
                        , Computer.HardDiskID
                        , MSG_INFO_LINK);
                    var logSendThread = new LogSendThread { _logMsg = strLink, _proxy = _proxy };
                    var threadLog = new Thread(new ThreadStart(logSendThread.SendLog));
                    threadLog.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                btnServerLink.Text = MSG_INFO_UNLINK;
            }
            else
            {
                try
                {
                    var strLink = string.Format("客户机 [主机名:{0}, IP地址:{1}, 网卡MAC: {2}, CPU编号:{3}, 硬盘编号{4}] {5}"
                        , Computer.HostName
                        , Computer.IPAddress
                        , Computer.NetMac
                        , Computer.CPUID
                        , Computer.HardDiskID
                        , MSG_INFO_UNLINK);
                    var logSendThread = new LogSendThread { _logMsg = strLink, _proxy = _proxy };
                    var threadLog = new Thread(new ThreadStart(logSendThread.SendLog));
                    threadLog.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                btnServerLink.Text = MSG_INFO_LINK;

                _proxy = null;
            }
        }

        void DownFile(string filename)
        {
            if (_proxy != null)
            {
                DownFile dfPath = new DownFile { FileName = filename };

                long filesize = 0;
                bool issuccess = false;
                string message = "";
                Stream filestream = new MemoryStream();
                DownFileResult dfresult = _proxy.DownLoadFile(dfPath);
                filesize = dfresult.FileSize;
                issuccess = dfresult.IsSuccess;
                message = dfresult.Message;
                filestream = dfresult.FileStream;

                //, out issuccess, out message, out filestream
                if (issuccess)
                {
                    if (!Directory.Exists(_savePath))
                    {
                        Directory.CreateDirectory(_savePath);
                    }

                    byte[] buffer = new byte[filesize];
                    FileStream fs = new FileStream(_savePath + @"\" + filename, FileMode.Create, FileAccess.Write);
                    int count = 0;
                    while ((count = filestream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, count);
                    }

                    //清空
                    fs.Flush();
                    //关闭流
                    fs.Close();

                }
                else
                {
                    MessageBox.Show(message);

                }
            }
        }

        /// <summary>
        /// WCF服务地址
        /// </summary>
        private void AddUrl()
        {
            texServerPath.Text = _serverUrl;
        }

        /// <summary>
        /// 获取服务文件列表
        /// </summary>
        private void GetServerDownloadList()
        {
            if (_proxy != null)
            {
                string[] strFile = _proxy.GetFilesList();

                for (int i = 0; i < strFile.Length; i++)
                {
                    DataRow type = _downloadfiles.NewRow();
                    type["文件路径"] = strFile[i];
                    try
                    {
                        _downloadfiles.Rows.Add(type);
                    }
                    catch { continue; }
                }
            }
        }
        #endregion


        // 创建一个客户端套接字
        Socket clientSocket = null;
        // 创建一个监听服务端的线程
        Thread threadServer = null;

        private void btnSendServer_Click(object sender, EventArgs e)
        {
            clientSendMsg("222222222222");
        }

        void SocketStart()
        {
            var listerIP = ConfigurationManager.AppSettings["ListerIP"];
            var listerPort = ConfigurationManager.AppSettings["ListerPort"];

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            IPAddress ip = IPAddress.Parse(listerIP);
            IPEndPoint endpoint = new IPEndPoint(ip, int.Parse(listerPort));

            try
            {   //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                clientSocket.Connect(endpoint);
            }
            catch
            {
                MessageBox.Show("连接失败！");

            }

            // 创建一个线程监听服务端发来的消息
            threadServer = new Thread(recMsg);
            threadServer.IsBackground = true;
            threadServer.Start();
        }

        /// <summary>
        ///  接收服务端发来的消息
        /// </summary>
        private void recMsg()
        {

            while (true) //持续监听服务端发来的消息
            {
                //定义一个1M的内存缓冲区 用于临时性存储接收到的信息
                byte[] arrRecMsg = new byte[1024 * 1024];
                int length = 0;
                try
                {
                    //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                    length = clientSocket.Receive(arrRecMsg);
                }
                catch
                {
                    return;

                }

                //将套接字获取到的字节数组转换为人可以看懂的字符串
                string strRecMsg = Encoding.UTF8.GetString(arrRecMsg, 0, length);
                //将发送的信息追加到聊天内容文本框中
                MessageBox.Show("服务端(" + GetCurrentTime() + "):" + strRecMsg + "\r\n");


                //右下角
                //FrmMsgBox frmShowWarning = new FrmMsgBox();//Form1为要弹出的窗体（提示框），
                //Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height);
                //frmShowWarning.PointToScreen(p);
                //frmShowWarning.Location = p;
                //frmShowWarning.Show();
                //for (int i = 0; i <= frmShowWarning.Height; i++)
                //{
                //    frmShowWarning.Location = new Point(p.X, p.Y - i);
                //    Thread.Sleep(10);//将线程沉睡时间调的越小升起的越快
                //}
            }
        }


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    timer1.Enabled = false;
        //    for (int i = 0; i <= this.Height; i++)
        //    {
        //        Point p = new Point(this.Location.X, this.Location.Y + i);//弹出框向下移动消失
        //        this.PointToScreen(p);//即时转换成屏幕坐标
        //        this.Location = p;// new Point(this.Location.X, this.Location.Y + i);
        //        System.Threading.Thread.Sleep(10);//线程睡眠时间调的越小向下消失的速度越快。

        //    }
        //    this.Close();//记得关闭此弹出框哦。OK
        //}

        /// <summary>
        /// 发送消息到服务端
        /// </summary>
        /// <param name="msg"></param>
        private void clientSendMsg(string msg)
        {
            byte[] sendMsg = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(sendMsg);
            MessageBox.Show("客户端(" + GetCurrentTime() + "):" + msg + "\r\n");
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
        /// 
        /// 判断鼠标是不是还在弹出框上，如果不是则timer1又可以开始工作了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;//timer1停止工作
            this.Opacity = 1;//弹出窗透明度设置为1，完全不透明
            if (System.Windows.Forms.Control.MousePosition.X < this.Location.X && System.Windows.Forms.Control.MousePosition.Y < this.Location.Y)//如下
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// 判断鼠标是不是还在弹出框上，如果不是则timer1又可以开始工作了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;//停止timer2计时器，
            if (this.Opacity > 0 && this.Opacity <= 1)//开始执行弹出窗渐渐透明
            {
                this.Opacity = this.Opacity - 0.05;//透明频度0.05
            }
            if (System.Windows.Forms.Control.MousePosition.X >= this.Location.X && System.Windows.Forms.Control.MousePosition.Y >= this.Location.Y)//每次都判断鼠标是否是在弹出窗上，使用鼠标在屏幕上的坐标跟弹出窗体的屏幕坐标做比较。
            {
                timer2.Enabled = true;//如果鼠标在弹出窗上的时候，timer2开始工作
                timer1.Enabled = false;//timer1停止工作。
            }
            if (this.Opacity == 0)//当透明度==0的时候，关闭弹出窗以释放资源。
            {
                this.Close();
            }
        }


    }
}

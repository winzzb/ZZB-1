namespace WCFClient
{
    partial class FrmTransferFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSerPath = new System.Windows.Forms.Label();
            this.btnServerLink = new System.Windows.Forms.Button();
            this.texServerPath = new System.Windows.Forms.TextBox();
            this.btnChoseUploadFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabUpload = new System.Windows.Forms.TabPage();
            this.dgUploadList = new System.Windows.Forms.DataGridView();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.btnAllDownloadFile = new System.Windows.Forms.Button();
            this.btnGetServerDownloadList = new System.Windows.Forms.Button();
            this.dgDownloadList = new System.Windows.Forms.DataGridView();
            this.btnChoseDownloadFile = new System.Windows.Forms.Button();
            this.btnSendServer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tabUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUploadList)).BeginInit();
            this.tabDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDownloadList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendServer);
            this.panel1.Controls.Add(this.lblSerPath);
            this.panel1.Controls.Add(this.btnServerLink);
            this.panel1.Controls.Add(this.texServerPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 65);
            this.panel1.TabIndex = 0;
            // 
            // lblSerPath
            // 
            this.lblSerPath.AutoSize = true;
            this.lblSerPath.Location = new System.Drawing.Point(21, 30);
            this.lblSerPath.Name = "lblSerPath";
            this.lblSerPath.Size = new System.Drawing.Size(59, 12);
            this.lblSerPath.TabIndex = 2;
            this.lblSerPath.Text = "服务地址:";
            // 
            // btnServerLink
            // 
            this.btnServerLink.Location = new System.Drawing.Point(426, 25);
            this.btnServerLink.Name = "btnServerLink";
            this.btnServerLink.Size = new System.Drawing.Size(75, 23);
            this.btnServerLink.TabIndex = 1;
            this.btnServerLink.Text = "连接";
            this.btnServerLink.UseVisualStyleBackColor = true;
            this.btnServerLink.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // texServerPath
            // 
            this.texServerPath.Location = new System.Drawing.Point(86, 27);
            this.texServerPath.Name = "texServerPath";
            this.texServerPath.Size = new System.Drawing.Size(322, 21);
            this.texServerPath.TabIndex = 0;
            // 
            // btnChoseUploadFile
            // 
            this.btnChoseUploadFile.Location = new System.Drawing.Point(19, 350);
            this.btnChoseUploadFile.Name = "btnChoseUploadFile";
            this.btnChoseUploadFile.Size = new System.Drawing.Size(195, 23);
            this.btnChoseUploadFile.TabIndex = 3;
            this.btnChoseUploadFile.Text = "选择要传输的文件";
            this.btnChoseUploadFile.UseVisualStyleBackColor = true;
            this.btnChoseUploadFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 417);
            this.panel2.TabIndex = 1;
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabUpload);
            this.tabPanel.Controls.Add(this.tabDownload);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(602, 417);
            this.tabPanel.TabIndex = 3;
            // 
            // tabUpload
            // 
            this.tabUpload.Controls.Add(this.btnChoseUploadFile);
            this.tabUpload.Controls.Add(this.dgUploadList);
            this.tabUpload.Controls.Add(this.btnSendFile);
            this.tabUpload.Location = new System.Drawing.Point(4, 22);
            this.tabUpload.Name = "tabUpload";
            this.tabUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpload.Size = new System.Drawing.Size(594, 391);
            this.tabUpload.TabIndex = 0;
            this.tabUpload.Text = "上传";
            this.tabUpload.UseVisualStyleBackColor = true;
            // 
            // dgUploadList
            // 
            this.dgUploadList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgUploadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUploadList.Location = new System.Drawing.Point(19, 24);
            this.dgUploadList.Name = "dgUploadList";
            this.dgUploadList.RowTemplate.Height = 23;
            this.dgUploadList.Size = new System.Drawing.Size(544, 317);
            this.dgUploadList.TabIndex = 1;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(488, 350);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 0;
            this.btnSendFile.Text = "传输";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.btnAllDownloadFile);
            this.tabDownload.Controls.Add(this.btnGetServerDownloadList);
            this.tabDownload.Controls.Add(this.dgDownloadList);
            this.tabDownload.Controls.Add(this.btnChoseDownloadFile);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(594, 391);
            this.tabDownload.TabIndex = 1;
            this.tabDownload.Text = "下载";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // btnAllDownloadFile
            // 
            this.btnAllDownloadFile.Location = new System.Drawing.Point(392, 350);
            this.btnAllDownloadFile.Name = "btnAllDownloadFile";
            this.btnAllDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnAllDownloadFile.TabIndex = 5;
            this.btnAllDownloadFile.Text = "所有下载";
            this.btnAllDownloadFile.UseVisualStyleBackColor = true;
            this.btnAllDownloadFile.Click += new System.EventHandler(this.btnAllDownloadFile_Click);
            // 
            // btnGetServerDownloadList
            // 
            this.btnGetServerDownloadList.Location = new System.Drawing.Point(19, 350);
            this.btnGetServerDownloadList.Name = "btnGetServerDownloadList";
            this.btnGetServerDownloadList.Size = new System.Drawing.Size(195, 23);
            this.btnGetServerDownloadList.TabIndex = 4;
            this.btnGetServerDownloadList.Text = "获取服务端文件";
            this.btnGetServerDownloadList.UseVisualStyleBackColor = true;
            this.btnGetServerDownloadList.Click += new System.EventHandler(this.btnGetServerDownloadList_Click);
            // 
            // dgDownloadList
            // 
            this.dgDownloadList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgDownloadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDownloadList.Location = new System.Drawing.Point(19, 24);
            this.dgDownloadList.MultiSelect = false;
            this.dgDownloadList.Name = "dgDownloadList";
            this.dgDownloadList.RowTemplate.Height = 23;
            this.dgDownloadList.Size = new System.Drawing.Size(544, 317);
            this.dgDownloadList.TabIndex = 3;
            // 
            // btnChoseDownloadFile
            // 
            this.btnChoseDownloadFile.Location = new System.Drawing.Point(488, 350);
            this.btnChoseDownloadFile.Name = "btnChoseDownloadFile";
            this.btnChoseDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnChoseDownloadFile.TabIndex = 2;
            this.btnChoseDownloadFile.Text = "选中下载";
            this.btnChoseDownloadFile.UseVisualStyleBackColor = true;
            this.btnChoseDownloadFile.Click += new System.EventHandler(this.btnChoseDownloadFile_Click);
            // 
            // btnSendServer
            // 
            this.btnSendServer.Location = new System.Drawing.Point(507, 25);
            this.btnSendServer.Name = "btnSendServer";
            this.btnSendServer.Size = new System.Drawing.Size(75, 23);
            this.btnSendServer.TabIndex = 3;
            this.btnSendServer.Text = "发送服务端";
            this.btnSendServer.UseVisualStyleBackColor = true;
            this.btnSendServer.Click += new System.EventHandler(this.btnSendServer_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FrmTransferFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTransferFile";
            this.Text = "FrmTransferFile";
            this.Load += new System.EventHandler(this.FrmTransferFile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPanel.ResumeLayout(false);
            this.tabUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUploadList)).EndInit();
            this.tabDownload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDownloadList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChoseUploadFile;
        private System.Windows.Forms.Label lblSerPath;
        private System.Windows.Forms.Button btnServerLink;
        private System.Windows.Forms.TextBox texServerPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.DataGridView dgUploadList;
        private System.Windows.Forms.Button btnChoseDownloadFile;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabUpload;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.DataGridView dgDownloadList;
        private System.Windows.Forms.Button btnGetServerDownloadList;
        private System.Windows.Forms.Button btnAllDownloadFile;
        private System.Windows.Forms.Button btnSendServer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
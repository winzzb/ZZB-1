namespace WCFServer
{
    partial class WcfServer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnWCFService = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWCFStart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWCFClose = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSendClient = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWCFService});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnWCFService
            // 
            this.btnWCFService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWCFStart,
            this.btnWCFClose});
            this.btnWCFService.Name = "btnWCFService";
            this.btnWCFService.Size = new System.Drawing.Size(94, 21);
            this.btnWCFService.Text = "WCF传输服务";
            // 
            // btnWCFStart
            // 
            this.btnWCFStart.Name = "btnWCFStart";
            this.btnWCFStart.Size = new System.Drawing.Size(152, 22);
            this.btnWCFStart.Text = "开启服务";
            this.btnWCFStart.Click += new System.EventHandler(this.btnWCFStart_Click);
            // 
            // btnWCFClose
            // 
            this.btnWCFClose.Name = "btnWCFClose";
            this.btnWCFClose.Size = new System.Drawing.Size(152, 22);
            this.btnWCFClose.Text = "关闭服务";
            this.btnWCFClose.Click += new System.EventHandler(this.btnWCFClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtLog);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 350);
            this.panel1.TabIndex = 1;
            // 
            // rtLog
            // 
            this.rtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtLog.Location = new System.Drawing.Point(0, 0);
            this.rtLog.Name = "rtLog";
            this.rtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtLog.Size = new System.Drawing.Size(612, 285);
            this.rtLog.TabIndex = 1;
            this.rtLog.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendClient);
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 285);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(612, 65);
            this.panel3.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 43);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(612, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSendClient
            // 
            this.btnSendClient.Location = new System.Drawing.Point(435, 7);
            this.btnSendClient.Name = "btnSendClient";
            this.btnSendClient.Size = new System.Drawing.Size(75, 23);
            this.btnSendClient.TabIndex = 2;
            this.btnSendClient.Text = "发送客户端";
            this.btnSendClient.UseVisualStyleBackColor = true;
            this.btnSendClient.Click += new System.EventHandler(this.btnSendClient_Click);
            // 
            // WcfServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WcfServer";
            this.Text = "WcfServer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WcfServer_FormClosed);
            this.Load += new System.EventHandler(this.WcfServer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnWCFService;
        private System.Windows.Forms.ToolStripMenuItem btnWCFStart;
        private System.Windows.Forms.ToolStripMenuItem btnWCFClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.Button btnSendClient;
    }
}
namespace TimeCopyIconWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextToolStripMenuItem1UnixTime = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem2YMDColon = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem3YMD = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem4ForExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxFromUnixtime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxISO8601Example = new System.Windows.Forms.TextBox();
            this.textBoxToUnixMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxISO8601ToUnixtime = new System.Windows.Forms.TextBox();
            this.textBoxFromISO8601 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem1UnixTime = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem2YMDColon = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem3YMD = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem4ForExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextToolStripMenuItem1UnixTime,
            this.contextToolStripMenuItem2YMDColon,
            this.contextToolStripMenuItem3YMD,
            this.contextToolStripMenuItem4ForExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 100);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // contextToolStripMenuItem1UnixTime
            // 
            this.contextToolStripMenuItem1UnixTime.Name = "contextToolStripMenuItem1UnixTime";
            this.contextToolStripMenuItem1UnixTime.Size = new System.Drawing.Size(197, 24);
            this.contextToolStripMenuItem1UnixTime.Text = "UnixTime値をコピー";
            this.contextToolStripMenuItem1UnixTime.Click += new System.EventHandler(this.Action1CopyUnixtime_Click);
            // 
            // contextToolStripMenuItem2YMDColon
            // 
            this.contextToolStripMenuItem2YMDColon.Name = "contextToolStripMenuItem2YMDColon";
            this.contextToolStripMenuItem2YMDColon.Size = new System.Drawing.Size(197, 24);
            this.contextToolStripMenuItem2YMDColon.Text = "Y/m/d H:i:sをコピー";
            this.contextToolStripMenuItem2YMDColon.Click += new System.EventHandler(this.Action2CopyYmd1_Click);
            // 
            // contextToolStripMenuItem3YMD
            // 
            this.contextToolStripMenuItem3YMD.Name = "contextToolStripMenuItem3YMD";
            this.contextToolStripMenuItem3YMD.Size = new System.Drawing.Size(197, 24);
            this.contextToolStripMenuItem3YMD.Text = "YmdHisをコピー";
            this.contextToolStripMenuItem3YMD.Click += new System.EventHandler(this.Action3CopyYmd2_Click);
            // 
            // contextToolStripMenuItem4ForExit
            // 
            this.contextToolStripMenuItem4ForExit.Name = "contextToolStripMenuItem4ForExit";
            this.contextToolStripMenuItem4ForExit.Size = new System.Drawing.Size(197, 24);
            this.contextToolStripMenuItem4ForExit.Text = "終了(&C)";
            this.contextToolStripMenuItem4ForExit.Click += new System.EventHandler(this.Action4ToolStripMenuItemForExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBoxFromUnixtime);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(326, 146);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "unixtimeを普通にする";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "↓ LocalDateTime";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "unixtime";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(12, 108);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(308, 27);
            this.textBox2.TabIndex = 2;
            // 
            // textBoxFromUnixtime
            // 
            this.textBoxFromUnixtime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFromUnixtime.Location = new System.Drawing.Point(12, 52);
            this.textBoxFromUnixtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFromUnixtime.Name = "textBoxFromUnixtime";
            this.textBoxFromUnixtime.Size = new System.Drawing.Size(308, 27);
            this.textBoxFromUnixtime.TabIndex = 1;
            this.textBoxFromUnixtime.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxFromUnixtime.Leave += new System.EventHandler(this.textBoxFromUnixtime_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxISO8601Example);
            this.groupBox2.Controls.Add(this.textBoxToUnixMessage);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxISO8601ToUnixtime);
            this.groupBox2.Controls.Add(this.textBoxFromISO8601);
            this.groupBox2.Location = new System.Drawing.Point(7, 191);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(326, 267);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日付け文字列をunixtime";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBoxISO8601Example
            // 
            this.textBoxISO8601Example.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxISO8601Example.Location = new System.Drawing.Point(146, 25);
            this.textBoxISO8601Example.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxISO8601Example.Name = "textBoxISO8601Example";
            this.textBoxISO8601Example.Size = new System.Drawing.Size(174, 27);
            this.textBoxISO8601Example.TabIndex = 3;
            this.textBoxISO8601Example.Enter += new System.EventHandler(this.textBoxISO8601Example_Enter);
            // 
            // textBoxToUnixMessage
            // 
            this.textBoxToUnixMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxToUnixMessage.Location = new System.Drawing.Point(12, 169);
            this.textBoxToUnixMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxToUnixMessage.Multiline = true;
            this.textBoxToUnixMessage.Name = "textBoxToUnixMessage";
            this.textBoxToUnixMessage.ReadOnly = true;
            this.textBoxToUnixMessage.Size = new System.Drawing.Size(308, 89);
            this.textBoxToUnixMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "↓";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "ISO 8601形式対応";
            // 
            // textBoxISO8601ToUnixtime
            // 
            this.textBoxISO8601ToUnixtime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxISO8601ToUnixtime.Location = new System.Drawing.Point(12, 135);
            this.textBoxISO8601ToUnixtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxISO8601ToUnixtime.Name = "textBoxISO8601ToUnixtime";
            this.textBoxISO8601ToUnixtime.Size = new System.Drawing.Size(308, 27);
            this.textBoxISO8601ToUnixtime.TabIndex = 5;
            // 
            // textBoxFromISO8601
            // 
            this.textBoxFromISO8601.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFromISO8601.Location = new System.Drawing.Point(12, 69);
            this.textBoxFromISO8601.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFromISO8601.Name = "textBoxFromISO8601";
            this.textBoxFromISO8601.Size = new System.Drawing.Size(308, 27);
            this.textBoxFromISO8601.TabIndex = 4;
            this.textBoxFromISO8601.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(346, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem1UnixTime,
            this.actionToolStripMenuItem2YMDColon,
            this.actionToolStripMenuItem3YMD,
            this.actionToolStripMenuItem4ForExit});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // actionToolStripMenuItem1UnixTime
            // 
            this.actionToolStripMenuItem1UnixTime.Name = "actionToolStripMenuItem1UnixTime";
            this.actionToolStripMenuItem1UnixTime.Size = new System.Drawing.Size(224, 26);
            this.actionToolStripMenuItem1UnixTime.Text = "UnixTime値をコピー";
            this.actionToolStripMenuItem1UnixTime.Click += new System.EventHandler(this.Action1CopyUnixtime_Click);
            // 
            // actionToolStripMenuItem2YMDColon
            // 
            this.actionToolStripMenuItem2YMDColon.Name = "actionToolStripMenuItem2YMDColon";
            this.actionToolStripMenuItem2YMDColon.Size = new System.Drawing.Size(224, 26);
            this.actionToolStripMenuItem2YMDColon.Text = "Y/m/d H:i:sをコピー";
            this.actionToolStripMenuItem2YMDColon.Click += new System.EventHandler(this.Action2CopyYmd1_Click);
            // 
            // actionToolStripMenuItem3YMD
            // 
            this.actionToolStripMenuItem3YMD.Name = "actionToolStripMenuItem3YMD";
            this.actionToolStripMenuItem3YMD.Size = new System.Drawing.Size(224, 26);
            this.actionToolStripMenuItem3YMD.Text = "YmdHisをコピー";
            this.actionToolStripMenuItem3YMD.Click += new System.EventHandler(this.Action3CopyYmd2_Click);
            // 
            // actionToolStripMenuItem4ForExit
            // 
            this.actionToolStripMenuItem4ForExit.Name = "actionToolStripMenuItem4ForExit";
            this.actionToolStripMenuItem4ForExit.Size = new System.Drawing.Size(224, 26);
            this.actionToolStripMenuItem4ForExit.Text = "終了(&C)";
            this.actionToolStripMenuItem4ForExit.Click += new System.EventHandler(this.Action4ToolStripMenuItemForExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 459);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem1UnixTime;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem2YMDColon;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem3YMD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxFromUnixtime;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem4ForExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxISO8601ToUnixtime;
        private System.Windows.Forms.TextBox textBoxFromISO8601;
        private System.Windows.Forms.TextBox textBoxToUnixMessage;
        private System.Windows.Forms.TextBox textBoxISO8601Example;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem1UnixTime;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem2YMDColon;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem3YMD;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem4ForExit;
    }
}
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextToolStripMenuItem1UnixTime = new ToolStripMenuItem();
            contextToolStripMenuItem2YMDColon = new ToolStripMenuItem();
            contextToolStripMenuItem3YMD = new ToolStripMenuItem();
            contextToolStripMenuItem4ForExit = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBoxFromUnixtime = new TextBox();
            groupBox2 = new GroupBox();
            textBoxISO8601Example = new TextBox();
            textBoxToUnixMessage = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxISO8601ToUnixtime = new TextBox();
            textBoxFromISO8601 = new TextBox();
            menuStrip1 = new MenuStrip();
            actionToolStripMenuItem = new ToolStripMenuItem();
            actionToolStripMenuItem1UnixTime = new ToolStripMenuItem();
            actionToolStripMenuItem2YMDColon = new ToolStripMenuItem();
            actionToolStripMenuItem3YMD = new ToolStripMenuItem();
            actionToolStripMenuItem4ForExit = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { contextToolStripMenuItem1UnixTime, contextToolStripMenuItem2YMDColon, contextToolStripMenuItem3YMD, contextToolStripMenuItem4ForExit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(170, 92);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // contextToolStripMenuItem1UnixTime
            // 
            contextToolStripMenuItem1UnixTime.Name = "contextToolStripMenuItem1UnixTime";
            contextToolStripMenuItem1UnixTime.Size = new Size(169, 22);
            contextToolStripMenuItem1UnixTime.Text = "UnixTime値をコピー";
            contextToolStripMenuItem1UnixTime.Click += Action1CopyUnixtime_Click;
            // 
            // contextToolStripMenuItem2YMDColon
            // 
            contextToolStripMenuItem2YMDColon.Name = "contextToolStripMenuItem2YMDColon";
            contextToolStripMenuItem2YMDColon.Size = new Size(169, 22);
            contextToolStripMenuItem2YMDColon.Text = "Y/m/d H:i:sをコピー";
            contextToolStripMenuItem2YMDColon.Click += Action2CopyYmd1_Click;
            // 
            // contextToolStripMenuItem3YMD
            // 
            contextToolStripMenuItem3YMD.Name = "contextToolStripMenuItem3YMD";
            contextToolStripMenuItem3YMD.Size = new Size(169, 22);
            contextToolStripMenuItem3YMD.Text = "YmdHisをコピー";
            contextToolStripMenuItem3YMD.Click += Action3CopyYmd2_Click;
            // 
            // contextToolStripMenuItem4ForExit
            // 
            contextToolStripMenuItem4ForExit.Name = "contextToolStripMenuItem4ForExit";
            contextToolStripMenuItem4ForExit.Size = new Size(169, 22);
            contextToolStripMenuItem4ForExit.Text = "終了(&C)";
            contextToolStripMenuItem4ForExit.Click += Action4ToolStripMenuItemForExit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBoxFromUnixtime);
            groupBox1.Location = new Point(6, 26);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(285, 110);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "unixtimeを普通にする";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(10, 61);
            label2.Name = "label2";
            label2.Size = new Size(270, 18);
            label2.TabIndex = 6;
            label2.Text = "↓ LocalDateTime";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 5;
            label1.Text = "unixtime";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(10, 81);
            textBox2.Margin = new Padding(4, 4, 4, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(270, 23);
            textBox2.TabIndex = 2;
            // 
            // textBoxFromUnixtime
            // 
            textBoxFromUnixtime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFromUnixtime.Location = new Point(10, 39);
            textBoxFromUnixtime.Margin = new Padding(4, 4, 4, 4);
            textBoxFromUnixtime.Name = "textBoxFromUnixtime";
            textBoxFromUnixtime.Size = new Size(270, 23);
            textBoxFromUnixtime.TabIndex = 1;
            textBoxFromUnixtime.Leave += textBoxFromUnixtime_Leave;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBoxISO8601Example);
            groupBox2.Controls.Add(textBoxToUnixMessage);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxISO8601ToUnixtime);
            groupBox2.Controls.Add(textBoxFromISO8601);
            groupBox2.Location = new Point(6, 143);
            groupBox2.Margin = new Padding(4, 4, 4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 4, 4, 4);
            groupBox2.Size = new Size(285, 200);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "日付け文字列をunixtime";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // textBoxISO8601Example
            // 
            textBoxISO8601Example.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxISO8601Example.Location = new Point(128, 19);
            textBoxISO8601Example.Name = "textBoxISO8601Example";
            textBoxISO8601Example.Size = new Size(153, 23);
            textBoxISO8601Example.TabIndex = 3;
            textBoxISO8601Example.Enter += textBoxISO8601Example_Enter;
            // 
            // textBoxToUnixMessage
            // 
            textBoxToUnixMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxToUnixMessage.Location = new Point(10, 127);
            textBoxToUnixMessage.Multiline = true;
            textBoxToUnixMessage.Name = "textBoxToUnixMessage";
            textBoxToUnixMessage.ReadOnly = true;
            textBoxToUnixMessage.Size = new Size(270, 68);
            textBoxToUnixMessage.TabIndex = 7;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Location = new Point(10, 80);
            label3.Name = "label3";
            label3.Size = new Size(270, 17);
            label3.TabIndex = 6;
            label3.Text = "↓";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 31);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 5;
            label4.Text = "ISO 8601形式対応";
            // 
            // textBoxISO8601ToUnixtime
            // 
            textBoxISO8601ToUnixtime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxISO8601ToUnixtime.Location = new Point(10, 101);
            textBoxISO8601ToUnixtime.Margin = new Padding(4, 4, 4, 4);
            textBoxISO8601ToUnixtime.Name = "textBoxISO8601ToUnixtime";
            textBoxISO8601ToUnixtime.Size = new Size(270, 23);
            textBoxISO8601ToUnixtime.TabIndex = 5;
            // 
            // textBoxFromISO8601
            // 
            textBoxFromISO8601.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFromISO8601.Location = new Point(10, 52);
            textBoxFromISO8601.Margin = new Padding(4, 4, 4, 4);
            textBoxFromISO8601.Name = "textBoxFromISO8601";
            textBoxFromISO8601.Size = new Size(270, 23);
            textBoxFromISO8601.TabIndex = 4;
            textBoxFromISO8601.Leave += textBox4_Leave;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { actionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(303, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            actionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionToolStripMenuItem1UnixTime, actionToolStripMenuItem2YMDColon, actionToolStripMenuItem3YMD, actionToolStripMenuItem4ForExit });
            actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            actionToolStripMenuItem.Size = new Size(54, 20);
            actionToolStripMenuItem.Text = "Action";
            // 
            // actionToolStripMenuItem1UnixTime
            // 
            actionToolStripMenuItem1UnixTime.Name = "actionToolStripMenuItem1UnixTime";
            actionToolStripMenuItem1UnixTime.Size = new Size(169, 22);
            actionToolStripMenuItem1UnixTime.Text = "UnixTime値をコピー";
            actionToolStripMenuItem1UnixTime.Click += Action1CopyUnixtime_Click;
            // 
            // actionToolStripMenuItem2YMDColon
            // 
            actionToolStripMenuItem2YMDColon.Name = "actionToolStripMenuItem2YMDColon";
            actionToolStripMenuItem2YMDColon.Size = new Size(169, 22);
            actionToolStripMenuItem2YMDColon.Text = "Y/m/d H:i:sをコピー";
            actionToolStripMenuItem2YMDColon.Click += Action2CopyYmd1_Click;
            // 
            // actionToolStripMenuItem3YMD
            // 
            actionToolStripMenuItem3YMD.Name = "actionToolStripMenuItem3YMD";
            actionToolStripMenuItem3YMD.Size = new Size(169, 22);
            actionToolStripMenuItem3YMD.Text = "YmdHisをコピー";
            actionToolStripMenuItem3YMD.Click += Action3CopyYmd2_Click;
            // 
            // actionToolStripMenuItem4ForExit
            // 
            actionToolStripMenuItem4ForExit.Name = "actionToolStripMenuItem4ForExit";
            actionToolStripMenuItem4ForExit.Size = new Size(169, 22);
            actionToolStripMenuItem4ForExit.Text = "終了(&C)";
            actionToolStripMenuItem4ForExit.Click += Action4ToolStripMenuItemForExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 344);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(menuStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
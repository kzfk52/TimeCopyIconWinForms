using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeCopyIconWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Text = Application.ProductName;
            var now = DateTimeOffset.Now;
            textBoxISO8601Example.Text = now.ToString("yyyy-MM-ddTHH:mm:ss") + now.ToString("zzz").Replace(":", "");
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // Action1と同じ
            var data = Helper.getUnixTimeStr(DateTimeOffset.Now);
            Clipboard.SetText(data);
            Notify(@"現在時刻 unixtime", $"{data} をコピーしました");
        }
        private void Action1CopyUnixtime_Click(object sender, EventArgs e)
        {
            var data = Helper.getUnixTimeStr(DateTimeOffset.Now);
            Clipboard.SetText(data);
            Notify("現在時刻 unixtime", $"{data} をコピーしました");
        }
        private void Action2CopyYmd1_Click(object sender, EventArgs e)
        {
            var data = Helper.getYmd1Str(DateTimeOffset.Now);
            Clipboard.SetText(data);
            Notify("現在時刻 Y/m/d H:i:s", $"{data} をコピーしました");
        }
        private void Action3CopyYmd2_Click(object sender, EventArgs e)
        {
            var data = Helper.getYmd2Str(DateTimeOffset.Now);
            Clipboard.SetText(data);
            Notify("現在時刻 YmdHis", $"{data} をコピーしました");
        }
        private void Action4ToolStripMenuItemForExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;

        }

        private void Notify(string title, string message)
        {
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;

            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(3000);
        }


        

        private void textBoxFromUnixtime_Leave(object sender, EventArgs e)
        {
            long unixT = 0;
            TextBox chk = (TextBox)sender;
            var txt = chk.Text.Trim();

            if (long.TryParse(txt, out unixT))
            {
                if(txt.Length == 13)
                {
                    // ローカルタイム
                    textBox2.Text = UnixMicroTimeToLocalDateString(unixT);

                }
                else
                {
                    // ローカルタイム 10
                    textBox2.Text = UnixTimeToLocalDateString(unixT);

                }
            }
            else
            {
                textBox2.Text = "";

            }
        }

        private string UnixTimeToLocalDateString(long unixTime)
        {
            // 1740633224
            // 1613440233000
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }
        private string UnixMicroTimeToLocalDateString(long unixTime)
        {
            // 1740633224
            // 1613440233000
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTime).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }


        private void textBox4_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave");


            DateTimeOffset dto;
            if (DateTimeOffset.TryParse(textBoxFromISO8601.Text, out dto))
            {
                textBoxToUnixMessage.Text = "";
                textBoxISO8601ToUnixtime.Text = "";

                var unixTimeSeconds = dto.ToUnixTimeSeconds();
                textBoxISO8601ToUnixtime.Text = unixTimeSeconds.ToString();
                //textBoxFromUnixtime.Text = unixTimeSeconds.ToString();
                //textBoxFromUnixtime_Leave(textBoxFromUnixtime, null);
                var dateStr = UnixTimeToLocalDateString(unixTimeSeconds);
                // ReSharper disable once LocalizableElement
                textBoxToUnixMessage.Text = @"変換しました。日付けは" + "\r\n" + dateStr;

            }
            else
            {
                textBoxToUnixMessage.Text = @"変換出来ませんでした";

                textBoxISO8601ToUnixtime.Text = "";
            }

        }

        private void textBoxISO8601Example_Enter(object sender, EventArgs e)
        {
            TextBox chk = (TextBox)sender;

            Clipboard.SetText(chk.Text);
            Notify("ISO8601", @"サンプル日付けをコピーしました。");
            textBoxToUnixMessage.Text = @"サンプル日付けをコピーしました。";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
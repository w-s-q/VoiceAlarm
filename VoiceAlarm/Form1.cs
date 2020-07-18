using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceAlarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Image img = System.Drawing.Image.FromFile(@"E:\生产预警系统\VoiceAlarm\VoiceAlarm\Resource\sg2.PNG");
            //Bitmap ptmap = new Bitmap(img);
            //ptmap.MakeTransparent(Color.White);
            pictureBox1.Image = KnockOutGzf(@"E:\生产预警系统\VoiceAlarm\VoiceAlarm\Resource\sg2.PNG");
            this.FormBorderStyle = FormBorderStyle.None;
            //this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            txtwd.Text = wdj.Value.ToString();
            Color[] myclolr = new Color[] {Color.Red,Color.Green,Color.Yellow };
            //L1.LampColor = myclolr;
            //L1.TwinkleSpeed = 1000;
            List<string[]> List = new List<string[]>();
            string[] event1 = new string[2];
            event1[0] = DateTime.Now.ToShortDateString();
            event1[1] = "电极1开启";
            List.Add(event1);
            string[] event2 = new string[2];
            event2[0] = DateTime.Now .ToShortDateString();
            event2[1] = "电极2开启";
            List.Add(event2);
            string[] event3 = new string[2];
            event3[0] = DateTime.Now.ToShortDateString();
            event3[1] = "电极2开启";
            List.Add(event3);
            string[] event4 = new string[2];
            event4[0] = DateTime.Now.ToShortDateString();
            event4[1] = "电极2开启";
            List.Add(event4);
            string[] event5 = new string[2];
            event5[0] = DateTime.Now.ToShortDateString();
            event5[1] = "电极2开启";
            List.Add(event5);
            string[] event6 = new string[2];
            event6[0] = DateTime.Now.ToShortDateString();
            event6[1] = "电极2开启";
            List.Add(event6);
            string[] event7 = new string[2];
            event7[0] = DateTime.Now.ToShortDateString();
            event7[1] = "电极2开启";
            List.Add(event7);
            string[] event8 = new string[2];
            event8[0] = DateTime.Now.ToShortDateString();
            event8[1] = "电极2开启";
            List.Add(event8);
            HZH_Controls.Controls.TimeLineItem[] t=new HZH_Controls.Controls.TimeLineItem[List.Count] ;
            for(int i=0;i<List.Count;i++)
            {
                t[i] = new HZH_Controls.Controls.TimeLineItem() { Title= List[i][0] ,Details=List[i][1]};
            }
            string filename = DateTime.Now.ToShortDateString() + ".txt";
            string path = Path.GetDirectoryName(Application.ExecutablePath)+"\\LogFile\\";
            path = path + filename;
            for(int i=0;i<t.GetLength(0);i++)
            {
                WriteText(t[i].Title.ToString()+t[i].Details.ToString(), path);
            }
            //t[0] = new HZH_Controls.Controls.TimeLineItem() { Title = DateTime.Now.ToString(), Details = "打开电极1" };
            ucTimeLine1.Items = t;
            ucTimeLine1.VerticalScroll.Value = ucTimeLine1.ClientSize.Height;
        }
        public System.Drawing.Bitmap KnockOutGzf(String path)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            System.Drawing.Bitmap bitmapProxy = new System.Drawing.Bitmap(image);
            image.Dispose();
            for (int i = 0; i < bitmapProxy.Width; i++)
            {
                for (int j = 0; j < bitmapProxy.Height; j++)
                {
                    System.Drawing.Color c = bitmapProxy.GetPixel(i, j);
                    if (!(c.R < 240 || c.G < 240 || c.B < 240))
                    {
                        bitmapProxy.SetPixel(i, j, System.Drawing.Color.Transparent);
                    }
                }
            }
            return bitmapProxy;
        }
        public static void WriteText(string text, string FilePath)
        {
            byte[] myByte = System.Text.Encoding.Default.GetBytes(text+"\r\n");
            using (FileStream fsWrite = new FileStream(@FilePath, FileMode.Append, FileAccess.Write))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
                fsWrite.Close();
            };
        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        //private void textBox21_TextChanged(object sender, EventArgs e)
        //{

        //}
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZDB.WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("User32")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);


        private void button1_Click(object sender, EventArgs e)
        {
            //FlashChatWindow(this);
            IntPtr intptr = GetForegroundWindow();//取得最顶层窗口的句柄
            Rect rect = new Rect();
            GetWindowRect(intptr, out rect);//取得窗口的矩形参数
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            var count = 1;
            for (int i = 0; i < 20; i++)
            {
                MoveWindow(intptr, 10, 10, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
                MoveWindow(intptr, 20, 20, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
            }
            //while (count <= ScreenArea.Height)
            //{
            //    MoveWindow(intptr, count, 0, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
            //    count++;
            //}
            //while (count >= 0)
            //{
            //    MoveWindow(intptr, count, 0, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
            //    count--;
            //}
        }

        public static void FlashChatWindow(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized || !form.Focused)
            {
                FlashWindow(form.Handle, true);
            }
        }
    }
}

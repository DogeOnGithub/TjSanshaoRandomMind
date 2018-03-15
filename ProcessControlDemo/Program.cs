using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessControlDemo
{
    class Program
    {
        private const int WM_SYSKEYDOWN = 0X104;
        private const int WM_SYSKEYUP = 0X105;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int VK_RETURN = 0x0D;
        private const int VK_CONTROL = 0x11;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("TIM");
            if (processes.Length > 0)
            {
                Console.WriteLine(processes[0].Id);
                IntPtr mainHandle = processes[0].MainWindowHandle;
                SetForegroundWindow(mainHandle);

                Thread.Sleep(1000);

                InputString(mainHandle, "唐毫峰");

                //用SendMessage无法模拟组合键
                //SendMessage(mainHandle, WM_SYSKEYDOWN, VK_CONTROL, 0);
                //SendMessage(mainHandle, WM_KEYDOWN, VK_RETURN, 0);
                //SendMessage(mainHandle, WM_KEYUP, VK_RETURN, 0);
                //SendMessage(mainHandle, WM_SYSKEYDOWN, VK_CONTROL, 0);

                //keybd_event是全局的事件，只作用于活动窗口
                keybd_event(VK_CONTROL, 0, 0, 0);
                keybd_event(VK_RETURN, 0, 0, 0);
                keybd_event(VK_RETURN, 0, 2, 0);
                keybd_event(VK_CONTROL, 0, 2, 0);
            }
            Console.ReadKey();
        }

        private static void InputString(IntPtr intPtr, string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            foreach (var ch in buffer)
            {
                SendMessage(intPtr, 0x102, ch, 0);
            }
        }
    }
}

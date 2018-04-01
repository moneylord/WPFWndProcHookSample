using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWndProcHookSample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private const int WM_POWERBROADCAST = 0x218;
        private const int PBT_APMQUERYSUSPEND = 0x0;
        private const int PBT_APMRESUMESUSPEND = 0x7;
        private const int PBT_APMSUSPEND = 0x4;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }

        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_POWERBROADCAST)
            {
                switch (wParam.ToInt32())
                {
                    case PBT_APMQUERYSUSPEND:
                    case PBT_APMSUSPEND:
                        {
                            Console.WriteLine("SUSPEND...");
                        }
                        break;
                    case PBT_APMRESUMESUSPEND:
                        {
                            Console.WriteLine("RESUME...");
                        }
                        break;
                }

                handled = true;
            }
            return IntPtr.Zero;
        }
    }
}

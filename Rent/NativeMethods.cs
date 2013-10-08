using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Rent
{
    internal sealed class NativeMethods
    {
        private NativeMethods() { }

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetWindow(IntPtr hwnd, int cmd);

        internal const Int32 WM_SETICON = 0x80;
        internal const Int32 WM_SETTEXT = 0x000c;
        internal const Int32 GW_OWNER = 4;
        internal const Int32 ICON_SMALL = 0;
        internal const Int32 ICON_BIG = 1;

        internal static IntPtr GetTopLevelOwner(IntPtr hWnd)
        {
            IntPtr hwndOwner = hWnd;
            IntPtr hwndCurrent = hWnd;
            while (hwndCurrent != (IntPtr)0)
            {
                hwndCurrent = GetWindow(hwndCurrent, GW_OWNER);
                if (hwndCurrent != (IntPtr)0)
                {
                    hwndOwner = hwndCurrent;
                }
            }

            return hwndOwner;
        }
    }
}

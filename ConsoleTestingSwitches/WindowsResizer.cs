using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

static class NativeMethods
{
    [DllImport("user32.dll", SetLastError = true)]

    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool SetWindowText(IntPtr hwnd, String lpString);


    // Define the FindWindow API function.
    [DllImport("user32.dll", EntryPoint = "FindWindow",
        SetLastError = true)]
    public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly,
        string lpWindowName);

    // Define the SetWindowPos API function.
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd,
        IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
        SetWindowPosFlags uFlags);

    // Define the SetWindowPosFlags enumeration.
    [Flags()]
    public enum SetWindowPosFlags : uint
    {
        SynchronousWindowPosition = 0x4000,
        DeferErase = 0x2000,
        DrawFrame = 0x0020,
        FrameChanged = 0x0020,
        HideWindow = 0x0080,
        DoNotActivate = 0x0010,
        DoNotCopyBits = 0x0100,
        IgnoreMove = 0x0002,
        DoNotChangeOwnerZOrder = 0x0200,
        DoNotRedraw = 0x0008,
        DoNotReposition = 0x0200,
        DoNotSendChangingEvent = 0x0400,
        IgnoreResize = 0x0001,
        IgnoreZOrder = 0x0004,
        ShowWindow = 0x0040,
    }
}

namespace windows_layout_save
{
    class WindowsResizer
    {

        public void resize(int x, int y, int width, int height, string procname)
        {
            // Get the target window's handle.
            IntPtr target_hwnd =
                NativeMethods.FindWindowByCaption(IntPtr.Zero, procname);
            if (target_hwnd == IntPtr.Zero)
            {
                Console.Error.WriteLine(
                    "Could not find a window with the title \"" +
                    procname + "\"");
                return;
            }

            NativeMethods.SetWindowPos(target_hwnd, IntPtr.Zero,
                x, y, width, height, 0);
        }
    }
}

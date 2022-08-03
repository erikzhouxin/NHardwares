using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
/*


#if defined _WIN32 || defined _WIN64
_API_EXPORT void CALLTYPE DEV_EnableEventMessage( HWND hWnd, UINT MsgID );	
_API_EXPORT BOOL CALLTYPE DEV_EnableEventMessageEx( HANDLE h, HWND hWnd, UINT MsgID );
#else
// linux user need callback mechanism to handle event
_API_EXPORT BOOL   CALLTYPE DEV_SetEventHandle( HANDLE h, DEVEventCallBack pCallBack );
#endif


_API_EXPORT HANDLE CALLTYPE DEV_Open( const char *strIP );
_API_EXPORT BOOL   CALLTYPE DEV_Close( HANDLE h );
_API_EXPORT BOOL   CALLTYPE DEV_ALB_Ctrl( HANDLE h, BOOL bOpen );
_API_EXPORT BOOL   CALLTYPE DEV_GetStatus( HANDLE h, DWORD *dwStatus );

// 消息编号
#define EVID_BALUSTRADE	1
#define EVID_FCOIL		2
#define EVID_BCOIL		3
#define EVID_ACCEPT		96
#define EVID_REFUSE		97
#define EVID_ONLINE		98
#define EVID_OFFLINE	99
 */
namespace ALBDLLTester
{
    class ALBDLL
    {
        //       [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_Open", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr DEV_Open(string strIP);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_Close", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_Close(IntPtr h);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_ALB_Ctrl", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_ALB_Ctrl(IntPtr h, Boolean bOpen);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_GetStatus", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_GetStatus(IntPtr h, Int32 dwStatus);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_EnableEventMessageEx", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);

        public delegate void DEVEventCallBack(IntPtr h, Int32 nEventId, Int32 nParam);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_SetEventHandle", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback);

        [DllImport("ALBCtrlDll.dll", EntryPoint = "DEV_Queue", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Boolean DEV_Queue(IntPtr h, Boolean bOpen);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, Int32 wMsg, IntPtr wParam, int lParam);


    }
}

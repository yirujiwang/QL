using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper
{
#if UNITY_WEBGL
    //WebGl平台设置全屏/窗口切换
    [System.Runtime.InteropServices.DllImport("__Internal")]
    public static extern void SetFullScreen(int code);
#endif

#if UNITY_STANDALONE_WIN
    public static void SetFullScreen(int code)
    {
        Screen.fullScreen = code == 1;
    }
#endif
}

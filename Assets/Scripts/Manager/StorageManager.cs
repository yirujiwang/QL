using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class StorageManager : Singleton<StorageManager>
{
    [DllImport("__Internal")]
    public static extern void SetFullScreen(int code);

    private const string KEY_FULLSCREEN = "_FULLSCREEN_";
    private const string KEY_MUSIC = "_MUSIC_";
    private const string KEY_VOLUME = "_VOLUME_";

    public int FullScreen
    {
        get
        {
            return PlayerPrefs.GetInt(KEY_FULLSCREEN, 0);
        }
        set
        {
            PlayerPrefs.SetInt(KEY_FULLSCREEN, value);
            SetFullScreen(value);
        }
    }

    public int Music
    {
        get
        {
            return PlayerPrefs.GetInt(KEY_MUSIC, 1);
        }
        set
        {
            PlayerPrefs.SetInt(KEY_MUSIC, value);
        }
    }

    public float Volume
    {
        get
        {
            return PlayerPrefs.GetFloat(KEY_VOLUME, 1f);
        }
        set
        {
            PlayerPrefs.SetFloat(KEY_VOLUME, value);
        }
    }
}

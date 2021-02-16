using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerConfig
{
    //是否为调试模式
    public bool debugModel { get; private set; }
}

public class ConfigModule : Singleton<ConfigModule>
{
    private UnityWebRequest m_request = null;
    private ServerConfig m_sconfig = null;

    public IEnumerator LoadDebugInfo()
    {
        m_sconfig = new ServerConfig();

        m_request = UnityWebRequest.Get("http://127.0.0.1/debugInfo.txt");
        yield return m_request.SendWebRequest();

        if(m_request.isHttpError || m_request.isNetworkError)
        {
            Debug.Log(m_request.error);
        }
        else
        {
            string content = m_request.downloadHandler.text;
            string[] subStrs = content.Split('\n');
            foreach (var subStr in subStrs)
            {
                ParseSubStr(subStr, ref m_sconfig);
            }
        }
    }

    private void ParseSubStr(string subStr, ref ServerConfig m_sconfig)
    {
    }
}

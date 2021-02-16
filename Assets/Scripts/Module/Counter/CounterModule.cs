using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;


//打点模块
public partial class CounterModule : Singleton<CounterModule>
{
    private void GetData(string url)
    {
        string query = string.Empty;
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(query));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application-www-form-urlencoded");

    }
}

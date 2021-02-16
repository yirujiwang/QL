using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;


//预设信息
public class PrefabInfo
{
    public string name; //预设名称
    public string fullPath; //预设绝对路径
    public string assetPath; //预设相对路径
}

//预设内自动标记格式
/*
** name@type|isPrefab
*/
public class VariableInfo
{
    public string name; //变量名前缀
    public string type; //变量类型
    public string extension; //变量类型后缀
    public bool isPrefab; //是否为预设（被标记为预设的控件下的子控件不再导出变量）
    public bool isMarked; //是否被标记为自动导出的变量

    public VariableInfo(string data)
    {
        string[] info = data.Split('@');
        name = info[0];

        isMarked = info.Length > 1;
        if (isMarked)
        {
            string[] marks = info[1].Split('|');
            type = marks[0];
            extension = Type2Extension(type);
            isPrefab = marks.Length > 1 ? bool.Parse(marks[1]) : default;
        }
    }

    //生成的变量名
    public string Name => $"{name}{extension}";

    public string GetVariableStr()
    {
        if (isMarked)
        {
            return $"[SerializeField] private {type} m_{Name};";
        }
        return default;
    }

    //类型转成变量后缀
    private string Type2Extension(string type)
    {
        if (type == "Button") return "Btn"; //按钮
        else if (type == "Text") return "Txt";
        else if (type == "Image") return "Img";
        else if (type == "Slider") return "Sld";
        else if (type == "ScrollRect") return "Scr";
        else if (type == "GameObject") return "Go";
        else if (type == "Transform") return "Trans";
        else return "";
    }
}

public class AutoUIPrefabTool : ToolBase
{
    public override string m_title { get => "UI预设自动化处理"; }

    //ui预设根目录
    private static string uiPrefabRootPath = "Resources/Prefabs/UI";

    //ui预设生成脚本目录
    private static string uiPrefabScriptRootPath = "Scripts/AutoCode/Prefabs";

    //预设列表
    private List<PrefabInfo> m_prefabList;

    public override void OnInit()
    {
        m_prefabList = new List<PrefabInfo>();

        OnRefreshPrefabsClick();
    }

    public override void OnDraw()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("预设列表:", GUILayout.Width(60));
        if (GUILayout.Button("更新列表", GUILayout.Width(100))) OnRefreshPrefabsClick();
        EditorGUILayout.EndHorizontal();

        for (int i = 0; i < m_prefabList.Count; i++) DrawPrefabInfo(m_prefabList[i]);
    }

    //绘制预设信息
    private void DrawPrefabInfo(PrefabInfo info)
    {
        EditorGUILayout.BeginHorizontal(GUILayout.Width(500));
        EditorGUILayout.LabelField(info.name, GUILayout.Width(100));
        string scriptAssetPath = $"{uiPrefabScriptRootPath}/{info.name}.cs";
        EditorGUILayout.LabelField(scriptAssetPath, GUILayout.Width(300));
        string scriptFullPath = Path.Combine(Application.dataPath, scriptAssetPath);
        if (File.Exists(scriptFullPath)) { if (GUILayout.Button("更新脚本", GUILayout.Width(100))) OnCreatePrefabScript(scriptFullPath, info); }
        else { if (GUILayout.Button("创建脚本", GUILayout.Width(100))) OnCreatePrefabScript(scriptFullPath, info); }
        EditorGUILayout.EndHorizontal();
    }

    //创建预设脚本
    private void OnCreatePrefabScript(string path, PrefabInfo info)
    {
        if (File.Exists(path)) File.Delete(path);

        using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            List<string> variables = new List<string>();
            GameObject go = null;
            try
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/{info.assetPath}");
                go = GameObject.Instantiate(prefab);
                GetVariableInPrefab(go.transform, ref variables);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
            finally
            {
                if (go != null) GameObject.DestroyImmediate(go);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"//此代码为自动生成，请勿手动修改——by QuasiLee");
            sb.AppendLine(@"");
            sb.AppendLine(@"using UnityEngine;");
            sb.AppendLine(@"using UnityEngine.UI;");
            sb.AppendLine(@"");
            //定义变量
            sb.AppendLine($"public partial class {info.name}");
            sb.AppendLine(@"{");
            foreach (var variable in variables)
            {
                sb.AppendLine($"    {variable}");
            }

            sb.AppendLine(@"}");


            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            file.Write(bytes, 0, bytes.Length);

        }
        AssetDatabase.Refresh();
    }

    //获取预设中被标记的变量
    private void GetVariableInPrefab(Transform trans, ref List<string> variables)
    {
        VariableInfo info = new VariableInfo(trans.name);
        if (info.isMarked)
        {
            variables.Add(info.GetVariableStr());
        }

        if (!info.isPrefab)
        {
            for (int i = 0; i < trans.childCount; i++)
            {
                Transform child = trans.GetChild(i);
                GetVariableInPrefab(child, ref variables);
            }
        }
    }

    //获取控件简写
    private object GetShorthand(string typeName)
    {
        if (typeName == "Button") return "Btn";
        else if (typeName == "Text") return "Txt";
        else if (typeName == "Image") return "Img";
        else if (typeName == "Slider") return "Sld";
        else return "Go";
    }

    //点击更新列表按钮
    private void OnRefreshPrefabsClick()
    {
        m_prefabList.Clear();
        string path = Path.Combine(Application.dataPath, uiPrefabRootPath);
        FindAllUIPrefab(path, ref m_prefabList);
    }

    //查找目录下所有的预设文件
    private void FindAllUIPrefab(string folderPath, ref List<PrefabInfo> output)
    {
        string[] pathes = Directory.GetFileSystemEntries(folderPath);
        foreach (var path in pathes)
        {
            if (Directory.Exists(path)) FindAllUIPrefab(path, ref output);
            else
            {
                if (Path.GetExtension(path) == ".prefab")
                {
                    PrefabInfo prefabInfo = new PrefabInfo();
                    prefabInfo.name = Path.GetFileNameWithoutExtension(path);
                    prefabInfo.fullPath = Path.GetFullPath(path);
                    prefabInfo.assetPath = prefabInfo.fullPath.Substring(Application.dataPath.Length + 1);
                    output.Add(prefabInfo);
                }
            }
        }
    }

}
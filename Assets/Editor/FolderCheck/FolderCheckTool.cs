using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FolderCheckTool : ToolBase
{
    public override string m_title { get => "项目目录"; }

    //文件夹路径字典<根目录-子目录>
    private static Dictionary<string, List<string>> FolderPathDict = new Dictionary<string, List<string>>()
    {
        //构建目录
        {"../Build", new List<string>
        {
            "Windows",
            "Android",
            "WebGL"
        }
        },

        //配置目录
        {"../Excel", new List<string>
        {
            "Constant",
            "Enum",
            "Data"
        }
        },

        //脚本目录
        {"Scripts", new List<string>
        {
            "AutoCode",
            "AutoCode/Prefabs",
        }
        },
    };

    public override void OnDraw()
    {
        EditorGUILayout.BeginVertical();
        foreach (var dict in FolderPathDict)
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical();
            string rootPath = Path.Combine(Application.dataPath, dict.Key);
            if (Directory.Exists(rootPath))
            {
                //根目录显示
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(dict.Key, GUILayout.Width(100));
                if (GUILayout.Button("清空目录", GUILayout.Width(100))) ResetDirectory(rootPath, true);
                if (GUILayout.Button("删除目录", GUILayout.Width(120))) ResetDirectory(rootPath, false);
                EditorGUILayout.EndHorizontal();

                //子目录显示
                for (int i = 0; i < dict.Value.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(dict.Value[i], GUILayout.Width(100));
                    string childPath = Path.Combine(rootPath, dict.Value[i]);
                    if (Directory.Exists(childPath))
                    {
                        EditorGUILayout.LabelField("目录已创建", GUILayout.Width(100));
                        if (GUILayout.Button("清空目录", GUILayout.Width(60))) ResetDirectory(childPath, true);
                        if (GUILayout.Button("删除目录", GUILayout.Width(60))) ResetDirectory(childPath);
                    }
                    else
                    {
                        if (GUILayout.Button("创建目录", GUILayout.Width(230))) ResetDirectory(childPath, true);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            else
            {
                //根目录显示
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(dict.Key, GUILayout.Width(100));
                if (GUILayout.Button("创建目录", GUILayout.Width(220))) ResetDirectory(rootPath, true);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndVertical();
    }

    //重置目录
    private void ResetDirectory(string path, bool bCreate = false)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        if (bCreate)
        {
            Directory.CreateDirectory(path);
        }
    }
}
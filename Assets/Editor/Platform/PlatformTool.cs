using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PlatformTool : ToolBase
{
    public override string m_title { get => "构建平台"; }

    private BuildTarget m_currentTarget;

    private static string[] m_scenes = new string[]
    {
        Path.Combine(Application.dataPath,"Scenes/StartScene.unity"),
    };

    public override void OnDraw()
    {
        m_currentTarget = EditorUserBuildSettings.activeBuildTarget;

        EditorGUILayout.LabelField($"当前平台：{EditorUserBuildSettings.activeBuildTarget}");

        EditorGUILayout.BeginHorizontal();

        if (m_currentTarget != BuildTarget.StandaloneWindows
            && m_currentTarget != BuildTarget.StandaloneWindows64
            && GUILayout.Button("切换到Windows平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
        }

        if (m_currentTarget != BuildTarget.StandaloneOSX
            && GUILayout.Button("切换到Mac平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
        }

        if (m_currentTarget != BuildTarget.Android
            && GUILayout.Button("切换到Android平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        }

        if (m_currentTarget != BuildTarget.WebGL
            && GUILayout.Button("切换到WebGL平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        }

        EditorGUILayout.EndHorizontal();

        AppInfo();
    }

    private void AppInfo()
    {

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("公司名称：", GUILayout.Width(60));
                PlayerSettings.companyName = EditorGUILayout.TextField(PlayerSettings.companyName, GUILayout.Width(100));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("产品名称：", GUILayout.Width(60));
                PlayerSettings.productName = EditorGUILayout.TextField(PlayerSettings.productName, GUILayout.Width(100));
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndHorizontal();

        WebGLInfo();
    }

    #region WebGL平台信息
    private string WebGLPath { get; set; } = Path.Combine(Application.dataPath, "../Build/WebGL");

    private void WebGLInfo()
    {
        if (m_currentTarget != BuildTarget.WebGL)
        {
            return;
        }

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("输出路径：", GUILayout.Width(60));
            WebGLPath = EditorGUILayout.TextField($"{Path.GetFullPath(WebGLPath)}", GUILayout.Width(348));
            if (!Directory.Exists(WebGLPath) && GUILayout.Button("创建输出路径", GUILayout.Width(100)))
            {
                Directory.CreateDirectory(WebGLPath);
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("窗口宽度：", GUILayout.Width(60));
                string defaultWebScreenWidth = PlayerSettings.defaultWebScreenWidth.ToString();
                PlayerSettings.defaultWebScreenWidth = int.Parse(EditorGUILayout.TextField(defaultWebScreenWidth, GUILayout.Width(100)));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("窗口高度：", GUILayout.Width(60));
                string defaultWebScreenHeight = PlayerSettings.defaultWebScreenHeight.ToString();
                PlayerSettings.defaultWebScreenHeight = int.Parse(EditorGUILayout.TextField(defaultWebScreenHeight, GUILayout.Width(100)));
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("开始构建！"))
        {
            BuildPipeline.BuildPlayer(
                m_scenes,
                WebGLPath,
                BuildTarget.WebGL,
                BuildOptions.None
                );
        }
    }
    #endregion

}
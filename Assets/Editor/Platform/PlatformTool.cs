using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PlatformTool : ToolBase
{
    private static string[] m_scenes = new string[]
    {
        Path.Combine(Application.dataPath,"Scenes/StartScene.unity"),
    };

    //Resource
    private static string ResourceRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "Resources"));
    //
    private static string ProjectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "../"));
    //
    private static string BuildRoot = Path.GetFullPath(Path.Combine(ProjectRoot, "Build"));

    private static string BuildWindowsPath = "Windows/QL.exe";
    private static string BuildWebGLPath = "WebGL/QL";

    private static BuildPlayerOptions BuildPlayer = new BuildPlayerOptions
    {
        scenes = m_scenes,        
        options = BuildOptions.None,
    };

    public override string m_title { get => "构建平台"; }

    private BuildTarget m_currentTarget;

    public override void OnDraw()
    {
        m_currentTarget = EditorUserBuildSettings.activeBuildTarget;

        EditorGUILayout.LabelField($"当前平台：{EditorUserBuildSettings.activeBuildTarget}");

        CheckFolder();

        EditorGUILayout.BeginHorizontal();

        if (m_currentTarget != BuildTarget.StandaloneWindows
            && m_currentTarget != BuildTarget.StandaloneWindows64
            && GUILayout.Button("切换到Windows平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
        }

        if (m_currentTarget != BuildTarget.WebGL
            && GUILayout.Button("切换到WebGL平台", GUILayout.Width(150)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
            BuildPlayer.targetGroup = BuildTargetGroup.WebGL;
            BuildPlayer.target = BuildTarget.WebGL;
            BuildPlayer.locationPathName = BuildWebGLPath;
        }

        EditorGUILayout.EndHorizontal();

        AppInfo();
    }

    private void CheckFolder()
    {
        if(!Directory.Exists(ResourceRoot)) Directory.CreateDirectory(ResourceRoot);
        if(!Directory.Exists(ProjectRoot)) Directory.CreateDirectory(ProjectRoot);
        if(!Directory.Exists(BuildRoot)) Directory.CreateDirectory(BuildRoot);
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

        WindowsPlatform();
        WebGLPlatform();
    }

    #region WebGL平台信息

    private void WebGLPlatform()
    {
        if(m_currentTarget != BuildTarget.WebGL)
        {
            return;
        }

        if (GUILayout.Button("开始构建！"))
        {
            BuildPlayer.targetGroup = BuildTargetGroup.WebGL;
            BuildPlayer.target = BuildTarget.WebGL;
            BuildPlayer.locationPathName = Path.Combine(BuildRoot, BuildWebGLPath);
            BuildPipeline.BuildPlayer(BuildPlayer);
        }
    }
    #endregion

    #region Windows平台信息
    private void WindowsPlatform()
    {
        if (m_currentTarget != BuildTarget.StandaloneWindows
            && m_currentTarget != BuildTarget.StandaloneWindows64)
        {
            return;
        }

        if (GUILayout.Button("开始构建！"))
        {
            BuildPlayer.targetGroup = BuildTargetGroup.Standalone;
            BuildPlayer.target = BuildTarget.StandaloneWindows;
            BuildPlayer.locationPathName = Path.Combine(BuildRoot, BuildWindowsPath);
            BuildPipeline.BuildPlayer(BuildPlayer);
        }
    }
    #endregion

}
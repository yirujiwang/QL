using UnityEditor;
using UnityEngine;

public class ToolWindow : EditorWindow
{
    //发布平台
    private static PlatformTool platformTool;
    //项目目录
    private static FolderCheckTool folderTool;
    //UI预设自动化处理
    private static AutoUIPrefabTool autoUIPrefabTool;

    //窗口大小
    private static Vector2 windowSize = new Vector2(500, 300);

    [MenuItem("工具箱/综合面板", false, 1)]
    private static void Init()
    {
        ToolWindow window = GetWindow<ToolWindow>();
        window.minSize = windowSize;
        window.maxSize = windowSize;
        window.Show();
    }

    private void OnGUI()
    {
        if (platformTool == null) platformTool = new PlatformTool();
        platformTool.Draw();

        if (folderTool == null) folderTool = new FolderCheckTool();
        folderTool.Draw();

        if (autoUIPrefabTool == null) autoUIPrefabTool = new AutoUIPrefabTool();
        autoUIPrefabTool.Draw();
    }
}

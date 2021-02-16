using UnityEditor;
using UnityEngine;

public abstract class ToolBase : ITool
{
    //是否展开
    public bool m_expand { get; set; } = false;

    //标题
    public virtual string m_title { get; set; } = "无";

    //是否初始化
    protected bool m_init = false;

    //滚动区域位置
    protected Vector2 m_scrollPos;

    public void Draw()
    {
        if (!m_init)
        {
            OnInit();
            m_init = true;
            m_scrollPos = Vector2.zero;
        }

        if (m_init)
        {
            m_expand = EditorGUILayout.BeginFoldoutHeaderGroup(m_expand, m_title);
            if (m_expand)
            {
                m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.Width(500), GUILayout.Height(300));
                OnDraw();
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }

    public virtual void OnInit() { }

    public abstract void OnDraw();
}
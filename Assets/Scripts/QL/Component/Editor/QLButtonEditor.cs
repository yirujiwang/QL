using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QLButton)), CanEditMultipleObjects]
public class QLButtonEditor : Editor
{
    [MenuItem("GameObject/UI/QL/Button")]
    private static void CreateButton()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                RectTransform rt;

                GameObject go = new GameObject("QLButton", typeof(QLImage));
                go.layer = LayerMask.NameToLayer("UI");
                QLButton button = go.AddComponent<QLButton>();

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;

                QLImage image = go.GetComponent<QLImage>();
                image.raycastTarget = false;

                go = new GameObject("RaycastBox", typeof(QLRaycastBox));
                QLRaycastBox raycastBox = go.GetComponent<QLRaycastBox>();
                go.layer = LayerMask.NameToLayer("UI");
                button.targetGraphic = raycastBox;

                raycastBox.transform.SetParent(trans, false);
                rt = raycastBox.transform as RectTransform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.localPosition = Vector3.zero;
                rt.sizeDelta = Vector2.zero;
                rt.localScale = Vector3.one;
            }
        }
    }

    public static SerializedProperty m_buttonSizeField;
    public static SerializedProperty m_needTxtField;
    public static SerializedProperty m_fontSizeField;
    public static SerializedProperty m_contentField;

    private QLButton button;

    private void OnEnable()
    {
        button = target as QLButton;
        m_buttonSizeField = serializedObject.FindProperty("m_buttonSize");
        m_needTxtField = serializedObject.FindProperty("m_needTxt");
        m_fontSizeField = serializedObject.FindProperty("m_fontSize");
        m_contentField = serializedObject.FindProperty("m_content");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //按钮尺寸
        EditorGUILayout.PropertyField(m_buttonSizeField);
        (button.transform as RectTransform).sizeDelta = m_buttonSizeField.vector2Value;

        //是否需要文本
        EditorGUILayout.PropertyField(m_needTxtField);
        if (m_needTxtField.boolValue)
        {
            if (button.Text == null)
            {
                RectTransform rt;

                GameObject go = new GameObject("Text", typeof(QLText));
                QLText text = go.GetComponent<QLText>();
                text.raycastTarget = false;
                text.color = Color.black;
                text.alignment = TextAnchor.MiddleCenter;
                text.transform.SetParent(button.transform, false);

                rt = text.transform as RectTransform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.localPosition = Vector3.zero;
                rt.sizeDelta = Vector2.zero;
                rt.localScale = Vector3.one;
                go.layer = LayerMask.NameToLayer("UI");
                button.Text = text;
            }

            //文本内容
            EditorGUILayout.PropertyField(m_contentField);
            button.Text.text = m_contentField.stringValue;

            //文本字号
            EditorGUILayout.PropertyField(m_fontSizeField);
            button.Text.fontSize = m_fontSizeField.intValue;

        }
        else
        {
            if (button.Text != null)
            {
                DestroyImmediate(button.Text.gameObject);
                button.Text = null;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


//按钮
public class QLButton : Button
{
    #region 序列化字段
    //按钮尺寸
    public Vector2 m_buttonSize = new Vector2(120f, 50f);
    //是否需要文本
    public bool m_needTxt = true;
    //按钮文本字号
    public int m_fontSize = 24;
    //按钮文本内容
    public string m_content = string.Empty;
    #endregion

    //是否可点击
    private bool m_canClick;
    //点击响应间隔
    private float m_time = 0;
    //点击碰撞盒
    private QLRaycastBox m_raycastBox = null;
    //按钮文本
    private QLText m_text = null;
    public QLText Text { get => m_text; set => m_text = value; }

    protected override void Awake()
    {
        onClick.AddListener(OnClick);
        Transform raycastBox = transform.Find("RaycastBox");
        if (raycastBox != null)
        {
            m_raycastBox = raycastBox.GetComponent<QLRaycastBox>();
            this.targetGraphic = m_raycastBox;
        }
        m_canClick = true;
    }

    //点击事件
    private void OnClick()
    {
        SetClick(false);
        Debug.Log("点击按钮");
    }

    private void SetClick(bool value)
    {
        m_raycastBox.raycastTarget = value;
        m_canClick = value;
    }

    private void Update()
    {
        if (!m_canClick)
        {
            Debug.Log("点击太快了，休息一下吧");
            m_time += Time.deltaTime;
            if (m_time > 1f)
            {
                m_time = 0;
                SetClick(true);
            }
        }
    }

    [MenuItem("GameObject/UI/QL/Button")]
    private static void CreateButton()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
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
            }
        }
    }
}

[CustomEditor(typeof(QLButton)), CanEditMultipleObjects]
public class QLButtonEditor : Editor
{
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
                GameObject go = new GameObject("Text", typeof(QLText));
                QLText text = go.GetComponent<QLText>();
                text.raycastTarget = false;
                text.color = Color.black;
                text.alignment = TextAnchor.MiddleCenter;
                text.transform.SetParent(button.transform, false);
                text.transform.localPosition = Vector3.zero;
                text.transform.localScale = Vector3.one;
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
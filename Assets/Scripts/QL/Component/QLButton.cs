using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public partial class QLButton : Button
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
        if(m_canClick)
        {
            SetClick(false);
        }
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
            m_time += Time.deltaTime;
            if (m_time > 1f)
            {
                m_time = 0;
                SetClick(true);
            }
        }
    }
}

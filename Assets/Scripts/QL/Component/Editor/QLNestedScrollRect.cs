using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//滚动方向
public enum ScrollDirection
{
    Horizontal, //水平方向
    Vertical, //垂直方向
}

//可嵌套的滚动视图
public class QLNestedScrollRect : ScrollRect
{
    //父级滚动视图
    private QLNestedScrollRect m_parent;

    //滚动方向
    private ScrollDirection m_direction = ScrollDirection.Horizontal;
    //起始拖拽方向
    private ScrollDirection m_beginDragDirection = ScrollDirection.Horizontal;

    protected override void Awake()
    {
        base.Awake();
        Transform parent = transform.parent;
        if (parent != null)
        {
            m_parent = parent.GetComponentInParent<QLNestedScrollRect>();
        }
        m_direction = this.horizontal ? ScrollDirection.Horizontal : ScrollDirection.Vertical;
    }

    //开始拖拽
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (m_parent != null)
        {
            m_beginDragDirection = Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y) ? ScrollDirection.Horizontal : ScrollDirection.Vertical;
            if (m_beginDragDirection != m_direction)
            {
                ExecuteEvents.Execute(m_parent.gameObject, eventData, ExecuteEvents.beginDragHandler);
                return;
            }
        }
        base.OnBeginDrag(eventData);
    }

    //结束拖拽
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (m_parent != null)
        {
            if (m_beginDragDirection != m_direction)
            {
                ExecuteEvents.Execute(m_parent.gameObject, eventData, ExecuteEvents.endDragHandler);
                return;
            }
        }
        base.OnEndDrag(eventData);
    }

    //滚动
    public override void OnScroll(PointerEventData data)
    {
        if (m_parent != null)
        {
            if (m_beginDragDirection != m_direction)
            {
                ExecuteEvents.Execute(m_parent.gameObject, data, ExecuteEvents.scrollHandler);
                return;
            }
        }
        base.OnScroll(data);
    }
}

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLButtonExtension
{
    [MenuItem("GameObject/UI/QL/Button")]
    private static void CreateButton()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                RectTransform rt;

                GameObject go = new GameObject("Button", typeof(Image));
                go.layer = LayerMask.NameToLayer("UI");
                Button button = go.AddComponent<Button>();

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;

                Image image = go.GetComponent<Image>();
                image.raycastTarget = false;

                AttachComponent<QLRaycastBox>(trans, (c) => { button.targetGraphic = c; });
                AttachComponent<Text>(trans).raycastTarget = false;
            }
        }
    }

    private static T AttachComponent<T>(Transform parent, Action<T> onEnd = null) where T : Component
    {
        GameObject go = new GameObject(typeof(T).Name, typeof(T));
        T t = go.GetComponent<T>();
        go.layer = LayerMask.NameToLayer("UI");

        t.transform.SetParent(parent, false);
        RectTransform rt = t.transform as RectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.localPosition = Vector3.zero;
        rt.sizeDelta = Vector2.zero;
        rt.localScale = Vector3.one;

        onEnd?.Invoke(t as T);
        return t;
    }
}

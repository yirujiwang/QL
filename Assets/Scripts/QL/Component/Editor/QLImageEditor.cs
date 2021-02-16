using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QLImage)), CanEditMultipleObjects]
public class QLImageEditor : Editor
{
    [MenuItem("GameObject/UI/QL/Image")]
    private static void CreateImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("QLImage", typeof(QLImage));
                go.layer = LayerMask.NameToLayer("UI");
                QLImage image = go.GetComponent<QLImage>();
                if (image == null)
                {
                    image = go.AddComponent<QLImage>();
                }
                image.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }

    [MenuItem("GameObject/UI/QL/Panel")]
    private static void CreatePanel()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("QLPanel", typeof(QLImage));
                go.layer = LayerMask.NameToLayer("UI");
                QLImage image = go.GetComponent<QLImage>();
                image.raycastTarget = false;

                image.color = new Color(0f, 0f, 0f, 0.7f);

                RectTransform rectTrans = go.transform as RectTransform;
                rectTrans.SetParent(Selection.activeTransform);
                rectTrans.anchorMin = Vector2.zero;
                rectTrans.anchorMax = Vector2.one;
                rectTrans.sizeDelta = Vector2.zero;
                rectTrans.localPosition = Vector3.zero;
                rectTrans.localScale = Vector3.one;
            }
        }
    }
}

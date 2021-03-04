using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLImageEditor : Editor
{
    [MenuItem("GameObject/UI/Image", false, 2)]
    private static void CreateImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("Image", typeof(Image));
                go.layer = LayerMask.NameToLayer("UI");
                Image image = go.GetComponent<Image>();

                image.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }

    [MenuItem("GameObject/UI/Panel", false, 4)]
    private static void CreatePanel()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("Panel", typeof(Image));
                go.layer = LayerMask.NameToLayer("UI");
                Image image = go.GetComponent<Image>();

                image.raycastTarget = true;

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

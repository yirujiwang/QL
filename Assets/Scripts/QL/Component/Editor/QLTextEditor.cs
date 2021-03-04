using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLTextEditor : Editor
{
    [MenuItem("GameObject/UI/Text", false, 1)]
    private static void CreateText()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("Text", typeof(Text));
                go.layer = LayerMask.NameToLayer("UI");
                Text text = go.GetComponent<Text>();

                text.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
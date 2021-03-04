using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLRawImageExtension
{
    [MenuItem("GameObject/UI/QL/Raw Image")]
    private static void CreateRawImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("RawImage", typeof(RawImage));
                go.layer = LayerMask.NameToLayer("UI");
                RawImage rawImage = go.GetComponent<RawImage>();

                rawImage.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
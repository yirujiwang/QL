using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(QLRawImage)), CanEditMultipleObjects]
public class QLRawImageEditor : Editor
{
    [MenuItem("GameObject/UI/QL/Raw Image")]
    private static void CreateRawImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("QLRawImage", typeof(QLRawImage));
                go.layer = LayerMask.NameToLayer("UI");
                QLRawImage rawImage = go.GetComponent<QLRawImage>();
                rawImage.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
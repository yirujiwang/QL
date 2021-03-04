using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLRaycastBoxExtension
{
    [MenuItem("GameObject/UI/QL/RaycastBox")]
    private static void CreateRaycastBox()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("RaycastBox", typeof(QLRaycastBox));
                go.layer = LayerMask.NameToLayer("UI");
                QLRaycastBox rb = go.GetComponent<QLRaycastBox>();

                rb.raycastTarget = true;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
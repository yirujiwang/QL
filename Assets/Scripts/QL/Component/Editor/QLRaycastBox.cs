using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLRaycastBox : Image
{
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        toFill.Clear();
    }

    [MenuItem("GameObject/UI/QL/RaycastBox")]
    private static void CreateRaycastBox()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("QLRaycastBox", typeof(Image));
                go.layer = LayerMask.NameToLayer("UI");
                Image image = go.GetComponent<Image>();
                image.raycastTarget = true;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}

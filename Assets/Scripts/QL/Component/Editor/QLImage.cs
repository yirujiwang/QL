﻿using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class QLImage : Image
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
                image.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
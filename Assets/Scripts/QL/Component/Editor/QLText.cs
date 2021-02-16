﻿using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QLText : Text
{
    [MenuItem("GameObject/UI/QL/Text")]
    private static void CreateText()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("QLText", typeof(QLText));
                go.layer = LayerMask.NameToLayer("UI");
                QLText text = go.GetComponent<QLText>();
                text.raycastTarget = false;

                Transform trans = go.transform;
                trans.SetParent(Selection.activeTransform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
            }
        }
    }
}
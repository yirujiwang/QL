using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentHelper
{
    public static void SetActive(this Component component, bool active)
    {
        component.gameObject.SetActive(active);
    }

    public static void SetActive(this GameObject go, bool active)
    {
        go.SetActive(active);
    }
}

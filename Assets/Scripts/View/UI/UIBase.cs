using System;
using UnityEngine;


public abstract class UIBase : MonoBehaviour
{
    private void Start()
    {
        OnInit();
    }

    protected abstract void OnInit();

    public abstract void OnShow();

    public virtual void OnHide() { }
}
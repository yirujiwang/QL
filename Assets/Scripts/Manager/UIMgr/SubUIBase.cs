using UnityEngine;

public abstract class SubUIBase : MonoBehaviour
{
    public virtual void OnInit() { }

    public virtual void OnShow()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }
}
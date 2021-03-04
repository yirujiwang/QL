using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private Canvas normalCanvas;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Transform NormalRoot
    {
        get
        {
            return normalCanvas.transform;
        }
    }
}
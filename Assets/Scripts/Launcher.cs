using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        App app = new App(this);
        StartCoroutine(app.Init());
    }

    private void Update()
    {
        if (App.Instance != null)
        {
            App.Instance.Update();
        }
    }
}
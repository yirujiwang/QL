using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager
{
    //当前场景
    private SceneBase m_currentScene;

    //场景是否加载完成
    private bool m_isLoading = false;

    //切换状态
    public void ShowScene(SceneBase newScene, string sceneName)
    {
        m_isLoading = false;

        if(m_currentScene != null)
        {
            //先退出当前场景，再切换场景
            m_currentScene.OnExit();
        }

        //切换场景
        LoadScene(sceneName);

        m_currentScene = newScene;
    }

    //加载场景
    private void LoadScene(string sceneName)
    {
        if(m_isLoading)
        {
            return;
        }

        if(string.IsNullOrEmpty(sceneName))
        {
            return;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void UpdateScene()
    {
        if(m_currentScene == null)
        {
            return;
        }

        if(!m_isLoading)
        {
            m_isLoading = true;
            m_currentScene.OnEnter();
        }

        if(m_currentScene != null)
        {
            m_currentScene.OnUpdate();
        }
    }
}

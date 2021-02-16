using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //UI根节点
    private UIRoot m_root = null;

    //ui列表
    private List<UIBase> m_uiList = new List<UIBase>();

    public void InitRoot()
    {
        if (m_root == null)
        {
            string prefabName = "UIRoot";
            GameObject asset = App.Ins.ResMgr.LoadAsset<GameObject>(AssetType.Prefab, prefabName);
            GameObject go = GameObject.Instantiate(asset);
            m_root = go.GetComponent<UIRoot>();
            go.name = prefabName;
        }
    }

    public void ShowUI<T>() where T : UIBase
    {
        var a = typeof(T);
        string uiName = a.Name;
        FindUI(out T uiBase);

        if (uiBase == null)
        {
            GameObject asset = App.Ins.ResMgr.LoadAsset<GameObject>(AssetType.UI, uiName);
            GameObject go = GameObject.Instantiate(asset, m_root.NormalRoot);
            uiBase = go.GetComponent<T>();
            go.name = uiName;

            m_uiList.Add(uiBase);
        }

        uiBase.gameObject.SetActive(true);
        uiBase.OnShow();
    }

    private void FindUI<T>(out T uiBase) where T : UIBase
    {
        uiBase = null;

        for (int i = 0; i < m_uiList.Count; i++)
        {
            if (m_uiList[i] is T)
            {
                uiBase = m_uiList[i] as T;
                break;
            }
        }
    }

    public void HideUI<T>() where T : UIBase
    {
        FindUI(out T uiBase);

        if (uiBase != null)
        {
            uiBase.OnHide();
            uiBase.gameObject.SetActive(false);
        }
    }

    public void HideUI(UIBase uiBase)
    {
        uiBase.OnHide();
        uiBase.gameObject.SetActive(false);
    }
}
using UnityEngine;

public enum AssetType
{
    Prefab, //普通预设文件
    Sound, //音效文件
    Music, //音乐文件
    UI, //UI预设文件
}

public class ResourceManager
{
    public T LoadAsset<T>(AssetType type, string assetName) where T : Object
    {
        string assetPath = string.Empty;
        switch (type)
        {
            case AssetType.Prefab: assetPath = $"Prefabs/{assetName}"; break;
            case AssetType.Sound: assetPath = $"Prefabs/Sound/{assetName}"; break;
            case AssetType.Music: assetPath = $"Prefabs/Music/{assetName}"; break;
            case AssetType.UI: assetPath = $"Prefabs/UI/{assetName}"; break;
            default: assetPath = $"{assetName}"; break;
        }
        Debug.Log(assetPath);
        return Resources.Load<T>(assetPath);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpritesLoader : MonoBehaviour
{
    [SerializeField] private string _url;
    
    private int _version = 0;

    public event UnityAction<List<Sprite>> DataLoaded;

    private void Start()
    {
        LoadBundles();
    }

    private void LoadBundles() => StartCoroutine(DownloadAndCache());

    private IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;

        var www = WWW.LoadFromCacheOrDownload(_url, _version);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }

        Object[] spritesRequest = www.assetBundle.LoadAllAssetsAsync().allAssets;

        yield return spritesRequest;

        List<Sprite> sprites = new List<Sprite>();
        foreach (var requestObject in spritesRequest)
        {
            if (requestObject is Sprite)
            {
                sprites.Add(requestObject as Sprite);
            }
        }

        DataLoaded?.Invoke(sprites);
    }
}

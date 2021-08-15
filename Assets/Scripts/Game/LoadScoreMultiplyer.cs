using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadScoreMultiplyer : MonoBehaviour
{
    [SerializeField] private string _url;

    private float _scoreMultiplyer;

    public float ScoreMultiplyer => _scoreMultiplyer;

    private void Start()
    {
        GetData();
    }

    private void GetData() => StartCoroutine(GetDataCoroutine());

    private IEnumerator GetDataCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(_url);
        request.SetRequestHeader("x-requested-with", "XMLHttpRequest");

        yield return request.SendWebRequest();

        Response response = JsonUtility.FromJson<Response>(request.downloadHandler.text);
        _scoreMultiplyer = response.data[0].rate_per_unit;
    }
}

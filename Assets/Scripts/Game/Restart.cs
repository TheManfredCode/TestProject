using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Score))]
public class Restart : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private Score _score;

    private void Start()
    {
        _score = GetComponent<Score>();
    }

    public void OnRestart()
    {
        _spawner.RestartEnmies();
        _score.Restart();
    }
}

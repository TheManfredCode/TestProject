using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDispersion;
    [SerializeField] private float _spawnRate;
    [SerializeField] private Score _score;
    [SerializeField] private EnemySpritesLoader _spritesLoader;

    private float _elapsedTime = 0;

    public event UnityAction<List<Sprite>> Initialized;

    private void OnEnable()
    {
        _spritesLoader.DataLoaded += OnDataLoaded;
    }

    private void OnDisable()
    {
        _spritesLoader.DataLoaded -= OnDataLoaded;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnRate)
        {
            if (TryGetObject(out GameObject poolObject))
            {
                _elapsedTime = 0;

                poolObject.SetActive(true);
                Vector3 objectSpawnPoint = _spawnPoint.position;

                poolObject.transform.position = _spawnPoint.position + new Vector3(Random.Range(-_spawnDispersion, _spawnDispersion), 0, 0);
            }
        }
    }

    public void RestartEnmies()
    {
        foreach (var poolObject in Pool)
        {
            if (poolObject.TryGetComponent(out EnemyMover enemyMover))
                enemyMover.Restart();

            poolObject.SetActive(false);
        }
    }

    private void OnDataLoaded(List<Sprite> sprites)
    {
        Initialize();
        InitializeEnemies();
        Initialized?.Invoke(sprites);
    }

    private void InitializeEnemies()
    {
        foreach (GameObject poolObject in Pool)
        {
            if (poolObject.TryGetComponent(out Enemy enemy))
                enemy.Initialize(_score);

            if (poolObject.TryGetComponent(out EnemyMover enemyMover))
                enemyMover.Initialize(_score);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteChanger : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private List<SpriteRenderer> _enemySpriteRenderers = new List<SpriteRenderer>();

    private void OnEnable()
    {
        _spawner.Initialized += OnInitialized;
    }

    private void OnDisable()
    {
        _spawner.Initialized -= OnInitialized;
    }

    public void OnInitialized(List<Sprite> sprites)
    {
        foreach (GameObject enemy in _spawner.Pool)
            if (enemy.TryGetComponent(out SpriteRenderer enemyRenderer))
                _enemySpriteRenderers.Add(enemyRenderer);

        if (sprites[0] != null)
            ChangeEnemySprite(sprites[0]);
    }

    public void ChangeEnemySprite(Sprite sprite)
    {
        foreach (SpriteRenderer renderer in _enemySpriteRenderers)
            renderer.sprite = sprite;
    }
}

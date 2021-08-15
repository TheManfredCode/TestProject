using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private float _deathAnimationDuration;
    [SerializeField] private ParticleSystem _particleSystem;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Clicked += OnClicked;
        transform.localScale = Vector3.one;
    }

    private void OnDisable()
    {
        _enemy.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        _particleSystem.Play();

        Tween animationTween = transform.DOScale(0, _deathAnimationDuration);

        yield return animationTween.WaitForCompletion();
        
        _enemy.Die();
    }
}

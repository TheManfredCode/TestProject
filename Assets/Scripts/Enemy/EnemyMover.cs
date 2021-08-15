using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hardmodeSpeed;

    private float _currentSpeed;

    private Score _playerScore;

    private void Start()
    {
        _currentSpeed = _speed;
    }

    private void OnDestroy()
    {
        _playerScore.HardmodeScoreReached -= OnHardmodeScoreReached;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _currentSpeed * Time.deltaTime);
    }

    public void Initialize(Score score)
    {
        _playerScore = score;
        _playerScore.HardmodeScoreReached += OnHardmodeScoreReached;
    }

    public void Restart()
    {
        _currentSpeed = _speed;
    }

    private void OnHardmodeScoreReached()
    {
        _currentSpeed = _hardmodeSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LoadScoreMultiplyer))]
public class Score : MonoBehaviour
{
    [SerializeField] private int _hardmodeScore;

    private LoadScoreMultiplyer _multiplyerLoader;
    private int _value;

    public int Value => _value;
    public float MultiplyedScore => _value * _multiplyerLoader.ScoreMultiplyer;

    public event UnityAction<float> ScoreChanged;
    public event UnityAction HardmodeScoreReached;

    private void Start()
    {
        _multiplyerLoader = GetComponent<LoadScoreMultiplyer>();
    }

    public void IncreaseScore()
    {
        _value++;
        ScoreChanged?.Invoke(MultiplyedScore);

        if (_value >= _hardmodeScore)
            HardmodeScoreReached?.Invoke();
    }

    public void Restart()
    {
        _value = 0;
        ScoreChanged?.Invoke(_value);
    }
}

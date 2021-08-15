using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Score))]
public class TopScore : MonoBehaviour
{
    [SerializeField] private GameOverArea _gameOverArea;

    private const string c_topScoreKey = "topScore";

    private Score _score;

    private void Start()
    {
        _score = GetComponent<Score>();
    }

    private void OnEnable()
    {
        _gameOverArea.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _gameOverArea.GameOver -= OnGameOver;
    }

    public void Save(float value)
    {
        PlayerPrefs.SetFloat(c_topScoreKey, value);
        PlayerPrefs.Save();
    }

    public float GetTopScore()
    {
        float result = 0;

        if (PlayerPrefs.HasKey(c_topScoreKey))
        {
            result = PlayerPrefs.GetFloat(c_topScoreKey);
        }

        return result;
    }

    private void OnGameOver()
    {
        if (_score.MultiplyedScore > GetTopScore())
            Save(_score.MultiplyedScore);
    }
}

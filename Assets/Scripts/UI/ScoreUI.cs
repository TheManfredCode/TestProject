using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _label;

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(float value)
    {
        _label.text = value.ToString();
    }
}

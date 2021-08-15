using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopScoreUI : MonoBehaviour
{
    [SerializeField] private TopScore _topScore;
    [SerializeField] private TMP_Text _label;

    private void OnEnable()
    {
        _label.text = _topScore.GetTopScore().ToString();
    }
}

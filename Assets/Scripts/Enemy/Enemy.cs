using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Score _playerScore;
    private bool IsClickable = false;

    private void OnMouseDown()
    {
        if (IsClickable)
        {
            _playerScore?.IncreaseScore();
            IsClickable = false;
            gameObject.SetActive(false);
        }
    }

    public void Initialize(Score score)
    {
        _playerScore = score;
    }

    public void EnableClickable()
    {
        IsClickable = true;
    }
}

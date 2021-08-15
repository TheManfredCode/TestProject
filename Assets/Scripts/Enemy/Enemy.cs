using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Score _playerScore;
    private bool IsClickable = false;

    public event UnityAction Clicked;

    private void OnMouseDown()
    {
        if (IsClickable)
        {
            _playerScore?.IncreaseScore();
            IsClickable = false;
            Clicked?.Invoke();
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

    public void Die()
    {
        gameObject.SetActive(false);
    }
}

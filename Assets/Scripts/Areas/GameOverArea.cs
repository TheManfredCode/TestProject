using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverArea : MonoBehaviour
{
    [SerializeField] private GameObject _restartPanel;

    public event UnityAction GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            GameOver?.Invoke();
            _restartPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

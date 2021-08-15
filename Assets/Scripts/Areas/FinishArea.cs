using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    [SerializeField] private GameObject _restartPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _restartPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

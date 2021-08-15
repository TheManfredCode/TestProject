using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    private void Start()
    {
        _menuPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

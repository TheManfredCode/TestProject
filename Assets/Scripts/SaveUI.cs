using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private TestSaving _savingSystem;

    private void Start()
    {
        _saveButton.onClick.AddListener(OnSaveButtonClicked);
        _loadButton.onClick.AddListener(OnLoadButtonClicked);
    }

    private void OnSaveButtonClicked()
    {
        SaveData saveData = new SaveData();
        saveData.TopScore = Convert.ToInt32(_InputField.text);

        _savingSystem.Save(saveData);
    }

    private void OnLoadButtonClicked()
    {
        _scoreLabel.text = _savingSystem.Load().TopScore.ToString();
    }
}

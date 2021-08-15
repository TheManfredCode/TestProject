using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private EnemySpritesLoader _spritesLoader;
    [SerializeField] private EnemySpriteChanger _spriteChanger;
    [SerializeField] private Button _nextSpriteButton;
    [SerializeField] private Button _applyChangeButton;
    [SerializeField] private Image _image;

    private List<Sprite> _sprites;
    private int _currentSpriteIndex = 0;
    private Sprite _currentSprite;

    private void OnEnable()
    {
        _nextSpriteButton.onClick.AddListener(SwitchSprite);
        _applyChangeButton.onClick.AddListener(ApplySettings);

        _spritesLoader.DataLoaded += OnDataLoaded;

        if (_currentSprite != null)
            _image.sprite = _currentSprite;
    }

    private void OnDisable()
    {
        _nextSpriteButton.onClick.RemoveListener(SwitchSprite);
        _applyChangeButton.onClick.RemoveListener(ApplySettings);

        _spritesLoader.DataLoaded -= OnDataLoaded;
    }

    public void OpenSettingsPanel()
    {
        _image.sprite = _currentSprite;
    }

    private void OnDataLoaded(List<Sprite> sprites)
    {
        _sprites = sprites;
        
        if(_sprites[_currentSpriteIndex] != null)
        {
            _image.sprite = _sprites[_currentSpriteIndex];
            _currentSprite = _sprites[_currentSpriteIndex];

            _spriteChanger.ChangeEnemySprite(_currentSprite);
        }
    }

    private void SwitchSprite()
    {
        _currentSpriteIndex++;

        if (_currentSpriteIndex >= _sprites?.Count)
            _currentSpriteIndex = 0;

        _image.sprite = _sprites[_currentSpriteIndex];
    }

    private void ApplySettings()
    {
        _currentSprite = _image.sprite;
        _spriteChanger.ChangeEnemySprite(_currentSprite);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Text _titleText;

    [Header("Buttons")]
    
    [SerializeField] private Transform _buttonsHolder;

    [SerializeField] private ButtonView _buttonViewPrefab;
    
    public void Setup(string title)
    {
        _titleText.text = title;
    }

    public void AddButton(string buttonText, Action buttonCallback)
    {
        var buttonView = Instantiate(_buttonViewPrefab, _buttonsHolder);
        buttonView.Setup(buttonText, buttonCallback);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    private Action _onClickCallback;

    public void Setup(string buttonText, Action buttonCallback)
    {
        _buttonText.text = buttonText;
        _onClickCallback = buttonCallback;
    }

    public void OnClick()
    {
        _onClickCallback?.Invoke();
    }
}

using System;
using UnityEngine;

public class RecordsMenuView : View
{
    [SerializeField] private ButtonView _backButtonView;
    
    public void Setup(string backButtonText, Action backButtonCallback)
    {
        _backButtonView.Setup(backButtonText, backButtonCallback);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private Image _resourceImage;
    [SerializeField] private TMP_Text _resourceValueText;

    private ReactiveVariable<uint> _reactiveVariable;

    public void Init(Sprite icon, ReactiveVariable<uint> reactiveVariable)
    {
        _reactiveVariable = reactiveVariable;
        _reactiveVariable.Changed += UpdateValue;

        _resourceImage.sprite = icon;
        _resourceValueText.text = _reactiveVariable.Value.ToString();
    }

    private void OnDestroy()
    {
        _reactiveVariable.Changed -= UpdateValue;
    }

    public void UpdateValue(uint oldValue, uint newValue)
    {
        _resourceValueText.text = newValue.ToString();
    }
}

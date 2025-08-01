using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private Image _resourceImage;
    [SerializeField] private TMP_Text _resourceValueText;

    public ResourceType Type { get; private set; }

    public void Init(ResourceType type, Sprite icon, uint value)
    {
        Type = type;

        _resourceImage.sprite = icon;
        _resourceValueText.text = value.ToString();
    }

    public void UpdateValue(uint value)
    {
        _resourceValueText.text = value.ToString();
    }
}

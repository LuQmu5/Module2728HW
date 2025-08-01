using System;
using UnityEngine;
using UnityEngine.UI;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup _container;
    [SerializeField] private ResourceDisplay _resourceDisplayPrefab;
    [SerializeField] private ResourceDisplayData[] _resourceDisplayData;
    [SerializeField] private CanvasGroup _canvasGroup;

    private WalletService _walletService;

    public void Init(WalletService walletService)
    {
        _walletService = walletService;
        _walletService.ResourceValueChanged += OnResourceValueChanged;

        DrawItems();
    }

    private void OnDestroy()
    {
        _walletService.ResourceValueChanged -= OnResourceValueChanged;
    }

    public void Show() => _canvasGroup.alpha = 1;

    public void Hide() => _canvasGroup.alpha = 0;

    private void OnResourceValueChanged(ResourceType type)
    {
        ResourceDisplay[] items = _container.GetComponentsInChildren<ResourceDisplay>();
        ResourceDisplay resourceDisplay = Array.Find(items, i => i.Type == type);

        if (resourceDisplay == null)
        {
            Debug.LogWarning($"ResourceDisplay for {type} not found.");
            return;
        }

        resourceDisplay.UpdateValue(_walletService.ResourcesMap[type]);
    }


    private void DrawItems()
    {
        foreach (var item in _walletService.ResourcesMap)
        {
            ResourceDisplayData displayData = Array.Find(_resourceDisplayData, data => data.Type == item.Key);

            if (displayData == null)
                throw new ArgumentException($"Icon for resource type {item.Key} not found in display data.");

            ResourceDisplay resourceDisplay = Instantiate(_resourceDisplayPrefab, _container.transform);
            resourceDisplay.Init(item.Key, displayData.Icon, item.Value);
        }
    }
}

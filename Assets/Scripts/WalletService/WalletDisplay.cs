using System;
using System.Linq;
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
        DrawItems();
    }

    public void Show() => _canvasGroup.alpha = 1;

    public void Hide() => _canvasGroup.alpha = 0;

    private void DrawItems()
    {
        foreach (var item in _walletService.ResourcesMap)
        {
            ResourceDisplay resourceDisplay = Instantiate(_resourceDisplayPrefab, _container.transform);
            Sprite icon = _resourceDisplayData.FirstOrDefault(i => i.Type == item.Key).Icon;
            resourceDisplay.Init(icon, item.Value);
        }
    }
}

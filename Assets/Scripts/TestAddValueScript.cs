using UnityEngine;

public class TestAddValueScript : MonoBehaviour
{
    private WalletService _walletService;

    public void Init(WalletService walletService)
    {
        _walletService = walletService;
    }

    private void Update()
    {
        AddResources();
        RemoveResources();
    }

    private void AddResources()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _walletService.AddResource(ResourceType.CopperCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _walletService.AddResource(ResourceType.SilverCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _walletService.AddResource(ResourceType.GoldCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _walletService.AddResource(ResourceType.TriumphEmblem, 100);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _walletService.AddResource(ResourceType.IceEmblem, 100);
        }
    }

    private void RemoveResources()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _walletService.TryRemoveResource(ResourceType.CopperCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            _walletService.TryRemoveResource(ResourceType.SilverCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            _walletService.TryRemoveResource(ResourceType.GoldCoins, 100);
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            _walletService.TryRemoveResource(ResourceType.TriumphEmblem, 100);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            _walletService.TryRemoveResource(ResourceType.IceEmblem, 100);
        }
    }
}

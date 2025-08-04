using System;
using System.Collections.Generic;

public enum ResourceType
{
    CopperCoins,
    SilverCoins,
    GoldCoins,
    TriumphEmblem,
    IceEmblem
}

public class WalletService
{
    private Dictionary<ResourceType, ReactiveVariable<uint>> _resourcesMap;

    public IReadOnlyDictionary<ResourceType, ReactiveVariable<uint>> ResourcesMap => _resourcesMap;

    public WalletService()
    {
        CreateEmptyWallet();
    }

    private void CreateEmptyWallet()
    {
        _resourcesMap = new Dictionary<ResourceType, ReactiveVariable<uint>>();

        foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType)))
        {
            _resourcesMap.Add(resourceType, new ReactiveVariable<uint>(0));
        }
    }

    public void AddResource(ResourceType resourceType, uint value)
    {
        if (value == 0)
            throw new ArgumentOutOfRangeException(nameof(value) + "can't be equals zero");

        _resourcesMap[resourceType].Value += value;
    }

    public bool TryRemoveResource(ResourceType resourceType, uint value)
    {
        if (value == 0)
            throw new ArgumentOutOfRangeException(nameof(value) + "can't be equals zero");

        if (_resourcesMap[resourceType].Value < value)
            return false;

        _resourcesMap[resourceType].Value -= value;

        return true;
    }
}

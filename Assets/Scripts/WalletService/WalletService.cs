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
    private Dictionary<ResourceType, uint> _resourcesMap;

    public IReadOnlyDictionary<ResourceType, uint> ResourcesMap => _resourcesMap;

    public event Action<ResourceType> ResourceValueChanged;

    public WalletService()
    {
        CreateEmptyWallet();
    }

    private void CreateEmptyWallet()
    {
        _resourcesMap = new Dictionary<ResourceType, uint>();

        foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType)))
        {
            _resourcesMap.Add(resourceType, 0);
        }
    }

    public void AddResource(ResourceType resourceType, uint value)
    {
        if (value == 0)
            throw new ArgumentOutOfRangeException(nameof(value) + "can't be equals zero");

        _resourcesMap[resourceType] += value;
        ResourceValueChanged?.Invoke(resourceType);
    }

    public bool TryRemoveResource(ResourceType resourceType, uint value)
    {
        if (value == 0)
            throw new ArgumentOutOfRangeException(nameof(value) + "can't be equals zero");

        if (_resourcesMap[resourceType] < value)
            return false;

        _resourcesMap[resourceType] -= value;
        ResourceValueChanged?.Invoke(resourceType);

        return true;
    }
}

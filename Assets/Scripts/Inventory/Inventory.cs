using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private Dictionary<Item, uint> _itemsMap = new();
    private uint _maxItems;

    public uint CurrentWeight => GetCurrentWeight();

    public Inventory(uint maxItems)
    {
        _maxItems = maxItems;
    }

    public void ShowItems()
    {
        Debug.Log("Inventory items:");

        foreach (var item in _itemsMap)
        {
            Debug.Log($"{item.Key.Name}, count: {item.Value}");
        }
    }

    public bool TryAddItem(Item item, uint count = 1)
    {
        if (CurrentWeight == _maxItems)
            return false;

        if (CurrentWeight + count > _maxItems)
            return false;

        if (_itemsMap.ContainsKey(item))
        {
            _itemsMap[item] += count;
        }
        else
        {
            _itemsMap.Add(item, count);
        }

        return true;
    }

    public bool TryRemoveItemById(int id, uint count = 1)
    {
        Item item = _itemsMap.Keys.FirstOrDefault(i => i.ID == id);

        if (item == null)
        {
            Debug.LogWarning($"No item with {id} id in inventory");
            return false;
        }

        if (_itemsMap[item] < count)
        {
            Debug.LogWarning($"Not enough item with {id} to delete {count} items");
            return false;
        }

        _itemsMap[item] -= count;

        return true;
    }

    private uint GetCurrentWeight()
    {
        uint result = 0;

        foreach (var weight in _itemsMap.Values)
        {
            result += weight;
        }

        return result;
    }
}

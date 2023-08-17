using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    
    public InventorySO Inventory
    {
        get => _inventorySO;
    }

    public void AddItem(ItemBaseSO item, int amount)
    {
        _inventorySO.AddItem(item, amount);
    }

    public void RemoveItem(ItemBaseSO item, int amount)
    {
        _inventorySO.RemoveItem(item, amount);
    }

    public bool Contains(ItemBaseSO item)
    {
        foreach (InventorySlot slot in _inventorySO.InventorySlots)
        {
            if (item == slot.item) { return true; }
        }

        return false;
    }
}

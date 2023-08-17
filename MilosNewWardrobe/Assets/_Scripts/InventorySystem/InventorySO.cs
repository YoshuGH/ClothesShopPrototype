using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryObject", menuName = "Inventory System/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField] List<InventorySlot> _inventorySlots = new List<InventorySlot>();
    public List<InventorySlot> InventorySlots => _inventorySlots;

    public void AddItem(ItemBaseSO item, int amount)
    {
        bool hasItem = false;
        // Add amount of items in case it already exists within the inventory
        foreach (InventorySlot slot in _inventorySlots)
        {
            if(slot.item == item)
            {
                slot.IncreaseAmount(amount);
                hasItem = true;
                break;
            }
        }

        // Add the new item to the inventory in case it does not exist already
        if (!hasItem)
            _inventorySlots.Add(new InventorySlot(item, amount));
    }

    public void RemoveItem(ItemBaseSO _item, int _amount)
    {
        foreach (InventorySlot slot in _inventorySlots)
        {
            if (slot.item == _item)
            {
                if(slot.amount-_amount <= 0)
                {
                    _inventorySlots.Remove(slot);
                    return;
                }
                slot.DecreaseAmount(_amount);
                break;
            }
        }
        return;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemBaseSO item;
    public int amount;

    public InventorySlot(ItemBaseSO _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void IncreaseAmount(int value)
    {
        amount += value;
    }

    public void DecreaseAmount(int value)
    {
        amount -= value;
    }
}

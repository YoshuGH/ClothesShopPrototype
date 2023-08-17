using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events for the shop that requires the inventory and stats manager.
/// Example: When any stat change.
/// </summary>

[CreateAssetMenu(menuName = "Events/Shop Event Channel")]
public class ShopEventChannelSO : EventChannelBaseSO
{
    public UnityAction<InventoryManager, StatsManager> OnEventRaised;

    public void RaiseEvent(InventoryManager inventory, StatsManager stats)
    {
        OnEventRaised?.Invoke(inventory, stats);
    }
}

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one InventorySO argument
/// </summary>

[CreateAssetMenu(menuName = "Events/Inventory Event Channel")]
public class InventoryEventChannelSO : EventChannelBaseSO
{
	public UnityAction<InventorySO> OnEventRaised;

	public void RaiseEvent(InventorySO inventory)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(inventory);
	}
}

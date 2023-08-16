using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments
/// </summary>

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : EventChannelBaseSO
{
	public UnityAction OnEventRaised;

	public void RaiseEvent()
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke();
	}
}

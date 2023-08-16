using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one float argument.
/// Example: Damage recived value or stats values
/// </summary>
/// 
[CreateAssetMenu(menuName = "Events/Float Event Channel")]
public class FloatEventChannelSO : EventChannelBaseSO
{
	public UnityAction<float> OnEventRaised;

	public void RaiseEvent(float value)
	{
		OnEventRaised?.Invoke(value);
	}
}

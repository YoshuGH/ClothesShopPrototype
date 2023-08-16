using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have a stats argument.
/// Example: When any stat change.
/// </summary>

[CreateAssetMenu(menuName = "Events/Stats Event Channel")]
public class StatsEventChannelSO : EventChannelBaseSO
{
    public UnityAction<StatType, float> OnEventRaised;

    public void RaiseEvent(StatType statType, float valueChanged)
    {
        OnEventRaised?.Invoke(statType, valueChanged);
    }
}

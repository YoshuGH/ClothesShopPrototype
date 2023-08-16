using RotaryHeart.Lib.SerializableDictionary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StatsSO", menuName = "Stats System/Base Stats")]
public class StatsSO : ScriptableObject
{
    [SerializeField] public Stats stats;
    [SerializeField] public Stats instanceStats;

    public float GetStat(StatType stat)
    {
        if(stats.TryGetValue(stat, out float _value))
        {
            return _value;
        }
        else if(instanceStats.TryGetValue(stat, out float _instValue))
        {
            return _instValue;
        }


        Debug.LogError($"No stat value found for {stat} on {this.name}");
        return 0;
    }

    public bool SetStat(StatType stat, float newValue)
    {
        if(stats.ContainsKey(stat))
        {
            stats[stat] = newValue;
            return true;
        }
        else if(instanceStats.ContainsKey(stat))
        {
            instanceStats[stat] = newValue;
            return true;
        }

        Debug.LogError($"No stat value found for {stat} on {this.name}");
        return false;
    }
}

[System.Serializable]
public class Stats : SerializableDictionaryBase<StatType, float> { } // Use a serializable dictionary from a plugin

public enum StatType
{
    Gold
}
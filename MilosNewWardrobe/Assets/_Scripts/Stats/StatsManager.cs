using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private StatsSO statsSO;
    private Dictionary<StatType, float> localStats;

    [Space(2)]
    public UnityEvent<StatType, float> OnStatsChanged;

    [Header("Broadcasting On")]
    [SerializeField] StatsEventChannelSO _onStatsChanged;

    void Awake()
    {
        localStats = new Dictionary<StatType, float>(statsSO.instanceStats);
        localStats[StatType.Health] = statsSO.GetStat(StatType.MaxHealth) * ((statsSO.GetStat(StatType.Defense) != 0) ? statsSO.GetStat(StatType.Defense) : 1);
    }

    public float GetStat(StatType stat)
    {
        if (localStats.ContainsKey(stat))
        {
            return localStats[stat];
        }
        else
        {
            return statsSO.GetStat(stat);
        }
    }

    public bool SetStat(StatType stat, float newValue)
    {
        if (localStats.ContainsKey(stat))
        {
            localStats[stat] = newValue;
            OnStatsChanged?.Invoke(stat, localStats[stat]);
            _onStatsChanged.RaiseEvent(stat, localStats[stat]);
            return true;
        }
        else if(statsSO.SetStat(stat, newValue))
        {
            OnStatsChanged?.Invoke(stat, statsSO.GetStat(stat));
            _onStatsChanged.RaiseEvent(stat, statsSO.GetStat(stat));
            return true;
        }

        return false;
    }
}

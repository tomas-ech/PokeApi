using System.Collections.Generic;
using UnityEngine;

public class StatsView : MonoBehaviour
{
    private StatPreview[] statPreviews;

    private void Awake()
    {
        statPreviews = GetComponentsInChildren<StatPreview>();
    }

    public void SetStatsBar(List<Stat> statList)
    {
        for (int i = 0; i < statList.Count; i++)
        {
            statPreviews[i].SetStatData(statList[i]);
        }
    }
}

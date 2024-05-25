using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPreview : MonoBehaviour
{
    private const float maxStatValue = 255;

    private TextMeshProUGUI statName;
    private Image statBar;

    private void Awake()
    {
        statName = GetComponentInChildren<TextMeshProUGUI>();
        statBar = GetComponentInChildren<Image>();
    }

    public void SetStatData(Stat pokemonStats)
    {
        statName.text = pokemonStats.stat.name;
        statBar.fillAmount = (pokemonStats.base_stat / maxStatValue);
    }
}

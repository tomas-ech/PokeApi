using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPokemonView : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private TextMeshProUGUI currentNumber;
    [SerializeField] private TextMeshProUGUI currentName;
    [SerializeField] private TextMeshProUGUI[] currentType;

    public void SetCurrenPokemonData(PokemonData pokemonData)
    {
        currentNumber.text = pokemonData.id.ToString();
        currentName.text = pokemonData.name;

        for (int i = 0; i < pokemonData.types.Count; i++)
        {
            currentType[i].gameObject.SetActive(true);
            currentType[i].text = pokemonData.types[i].type.ToString();
        }
    }
    
}

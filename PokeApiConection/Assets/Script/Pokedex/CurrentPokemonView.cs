using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CurrentPokemonView : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private TextMeshProUGUI currentNumber;
    [SerializeField] private TextMeshProUGUI currentName;
    [SerializeField] private TextMeshProUGUI[] currentType;  

    public void SetCurrenPokemonData(PokemonData pokemonData)
    {
        currentNumber.text = $"N° {pokemonData.id}";
        currentName.text = pokemonData.name;

        DeactivateTypes();
        for (int i = 0; i < pokemonData.types.Count; i++)
        {
            currentType[i].gameObject.SetActive(true);
            currentType[i].text = pokemonData.types[i].type.name;
        }

        PokeApiManager.DownloadImageByURL(pokemonData.sprites.front_default, OnCompleteSprite);
    }

    private void DeactivateTypes()
    {
        foreach (var type in currentType)
        {
            type.gameObject.SetActive(false);
        }
    }

    private void OnCompleteSprite(Sprite loadedSprite)
    {
        currentImage.sprite = loadedSprite;
    }
}
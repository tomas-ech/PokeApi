using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class PokemonPreview : MonoBehaviour
{
    public string pokemonUrl;
    public int pokemonId;

    [SerializeField] private Image pokemonImage;

    private TextMeshProUGUI[] pokemonStrings;
    private Button pokemonButton;

    public void Initialize(Action<string> onClickPokemon, PokemonAlbumData pokemonAlbumData)
    {
        pokemonStrings = GetComponentsInChildren<TextMeshProUGUI>();
        pokemonButton = GetComponent<Button>();

        pokemonButton.onClick.AddListener(() => onClickPokemon(pokemonUrl));

        SetPokemonData(pokemonAlbumData.url);
    }

    private void SetPokemonData(string pokemonUrl)
    {
        PokeApiManager.GetEndpointData<PokemonData>(pokemonUrl, OnCompleteData);
    }

    private void OnCompleteData(PokemonData pokemonData)
    {
        PokeApiManager.DownloadImageByURL(pokemonData.sprites.front_default, (sprite) => {
            pokemonImage.sprite = sprite;
            pokemonImage.color = Color.white;
        });
        
        pokemonStrings[0].text = $"N° {pokemonId}";
        pokemonStrings[1].text = pokemonData.name;
    }
}

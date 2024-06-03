using System.Collections.Generic;
using UnityEngine;
using System;

public class ContentView : MonoBehaviour
{
    [SerializeField] private PokemonPreview pokemonPreview;

    /// <summary>
    /// Spawn all the pokemon cards
    /// </summary>
    /// <param name="results">List with all the pokemon data</param>
    /// <param name="onClickPokemon">Function when clicking the pokemon card</param>
    public void SetPokemonAlbum(List<PokemonAlbumData> results, Action<string> onClickPokemon)
    {
        for (int i = 0; i < results.Count; i++)
        {
            PokemonPreview preview = Instantiate(pokemonPreview);
            preview.transform.SetParent(pokemonPreview.transform.parent, false);
            preview.gameObject.SetActive(true);
            preview.pokemonId = i+1;
            preview.pokemonUrl = results[i].url;
            preview.Initialize(onClickPokemon, results[i]);
        }
    }
}

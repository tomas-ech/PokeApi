using System.Collections.Generic;
using UnityEngine;
using System;

public class ContentView : MonoBehaviour
{
    [SerializeField] private PokemonPreview pokemonPreview;

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

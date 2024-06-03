using GraphQlClient.Core;
using System.Collections.Generic;
using UnityEngine;

public class PokedexController : BaseController
{
    public int amountOfPokemon = 20;
    public int pokemonToShow;

    [Header("Views")]
    [SerializeField] private StatsView statsView;
    [SerializeField] private ContentView contentView;
    [SerializeField] private CurrentPokemonView currentPokemonView;

    [Header("Data Models")]
    [SerializeField] private GraphApi pokemonGraph;
    [SerializeField] PokemonDataModel currentPokemonData;        

    public override void InitializeController()
    {
        base.InitializeController();
    }

    private void Awake()
    {
        //TODO: pasar al initialize cuando se tenga sistema de pantalla de carga
        //PokeApiManager.GetEndpointData<PokemonByPage>($"https://pokeapi.co/api/v2/pokemon/?limit={amountOfPokemon}", OnInitilize);
        PokeApiManager.CallGraphQLPokeApi<PokemonByGraphQLRoot>(pokemonGraph, "AllPokemon", OnInitilize2);
    }

    private void OnInitilize2(PokemonByGraphQLRoot pokemonList)
    {
        Debug.Log(pokemonList.data.pokemon_v2_pokemon[0].name);
        currentPokemonData.requestedPokemonData = pokemonList.data;
    }

    private void OnInitilize(PokemonByPage pokemonList)
    {
        contentView.SetPokemonAlbum(pokemonList.results, SetCurrentPokemon);
        SetCurrentPokemon(pokemonList.results[pokemonToShow-1].url);
    }

    private void SetCurrentPokemon(string url)
    {
        PokeApiManager.GetEndpointData<PokemonData>(url, OnCompleteData);
    }

    private void OnCompleteData(PokemonData pokemonData)
    {
        currentPokemonView.SetCurrenPokemonData(pokemonData);
        statsView.SetStatsBar(pokemonData.stats);
    }

    #region Manually Change Pokemon
    [ContextMenu("SetPokemon")]
    private void SetInitialPokemon()
    {
        SetCurrentPokemon($"https://pokeapi.co/api/v2/pokemon/{pokemonToShow}");
    }
    #endregion
}
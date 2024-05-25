using UnityEngine;

public class PokedexController : MonoBehaviour
{
    public int amountOfPokemon = 20;
    public int pokemonToShow;
    [SerializeField] private StatsView statsView;
    [SerializeField] private ContentView contentView;
    [SerializeField] private CurrentPokemonView currentPokemonView;
    [SerializeField] PokemonDataModel currentPokemonData;    

    private void Start()
    {
        Initialize();
    }

    [ContextMenu("SetPokemon")]
    private void SetInitialPokemon()
    {
        SetCurrentPokemon($"https://pokeapi.co/api/v2/pokemon/{pokemonToShow}");
    }

    private void Initialize()
    {
        PokeApiManager.GetEndpointData<PokemonByPage>($"https://pokeapi.co/api/v2/pokemon/?limit={amountOfPokemon}", OnInitilize);
    }

    private void OnInitilize(PokemonByPage pokemonList)
    {
        contentView.SetPokemonAlbum(pokemonList.results, SetCurrentPokemon);
        SetCurrentPokemon(pokemonList.results[pokemonToShow].url);
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
}
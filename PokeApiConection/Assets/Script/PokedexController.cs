using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class PokedexController : MonoBehaviour
{
    public int pokemonToShow;
    [SerializeField] private StatsView statsView;
    [SerializeField] private ContentView contentView;
    [SerializeField] private CurrentPokemonView currentPokemonView;
    [SerializeField] PokemonDataModel currentPokemonData;    

    private void Start()
    {
        SetInitialPokemon();
    }

    [ContextMenu("SetPokemon")]
    private void SetInitialPokemon()
    {
        PokeApiManager.GetEndpointData<PokemonData>($"https://pokeapi.co/api/v2/pokemon/{pokemonToShow}/", OnCompleteData);
    }

    private void OnCompleteData(PokemonData pokemonData)
    {
        currentPokemonView.SetCurrenPokemonData(pokemonData);
    }

    
}
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class PokedexController : MonoBehaviour
{
    [SerializeField] private StatsView statsView;
    [SerializeField] private ContentView contentView;
    [SerializeField] private CurrentPokemonView currentPokemonView;
    [SerializeField] PokemonDataModel currentPokemonData;

    private void Start()
    {
        GetEndpointData($"https://pokeapi.co/api/v2/pokemon/9/");
    }

    [ContextMenu("Call Pokedex Data")]
    public async void GetEndpointData(string endpointURL)
    {
        UnityWebRequest currentWebRequest = UnityWebRequest.Get(endpointURL);

        currentWebRequest.SetRequestHeader("Content-Type", "application/json");

        var response = currentWebRequest.SendWebRequest();

        while (!response.isDone)
        {
            await Task.Yield();
        }

        if (currentWebRequest.result == UnityWebRequest.Result.Success)
        {
            PokemonData deserializedResponse;
            deserializedResponse = JsonConvert.DeserializeObject<PokemonData>(currentWebRequest.downloadHandler.text);
            Debug.Log(deserializedResponse.name);
            currentPokemonView.SetCurrenPokemonData(deserializedResponse);
        }
        else
        {
            Debug.Log($"Failed: {currentWebRequest.error}");
        }

    }
}

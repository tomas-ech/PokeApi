using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PokedexController : MonoBehaviour
{
    [SerializeField] private StatsView statsView;
    [SerializeField] private ContentView contentView;
    [SerializeField] private CurrentPokemonView currentPokemonView;

    private void Start()
    {
        GetEndpointData($"https://pokeapi.co/api/v2/pokemon?/limit=20/");
    }

    [ContextMenu("Call Pokedex Data")]
    public async void GetEndpointData(string endpointURL)
    {
        using var WWW = UnityWebRequest.Get(endpointURL);

        WWW.SetRequestHeader("Content-Type", "application/json");

        var response = WWW.SendWebRequest();

        while (!response.isDone)
        {
            await Task.Yield();
        }

        if (WWW.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Succes!: {WWW.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {WWW.error}");
        }

    }
}

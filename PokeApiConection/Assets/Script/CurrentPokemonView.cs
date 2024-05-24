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
        currentNumber.text = pokemonData.id.ToString();
        currentName.text = pokemonData.name;

        for (int i = 0; i < pokemonData.types.Count; i++)
        {
            currentType[i].gameObject.SetActive(true);
            currentType[i].text = pokemonData.types[i].type.name;
        }

        SetCurrentPokemonImage(pokemonData.sprites.front_default);
    }

    private async void SetCurrentPokemonImage(string url)
    {
        UnityWebRequest spriteLoader = UnityWebRequestTexture.GetTexture(url);

        spriteLoader.SendWebRequest();

        while (!spriteLoader.isDone)
        {
            await Task.Yield();
        }

        Texture2D texture = ((DownloadHandlerTexture) spriteLoader.downloadHandler).texture;

        if (spriteLoader.result == UnityWebRequest.Result.Success)
        {
            currentImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
        }

    }
    
}

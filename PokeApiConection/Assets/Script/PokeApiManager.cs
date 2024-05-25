using System.Threading.Tasks;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public static class PokeApiManager
{

    public static async void GetEndpointData<T>(string endpointURL, Action<T> OnSucces)
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
            T deserializedResponse;
            deserializedResponse = JsonConvert.DeserializeObject<T>(currentWebRequest.downloadHandler.text);
            OnSucces?.Invoke(deserializedResponse);
        }
        else
        {
            Debug.Log($"Failed: {currentWebRequest.error}");
        }
    }

    public static async void DownloadImageByURL(string url, Action<Sprite> OnSucces)
    {
        UnityWebRequest spriteLoader = UnityWebRequestTexture.GetTexture(url);

        spriteLoader.SendWebRequest();

        while (!spriteLoader.isDone)
        {
            await Task.Yield();
        }

        Texture2D texture = ((DownloadHandlerTexture)spriteLoader.downloadHandler).texture;

        if (spriteLoader.result == UnityWebRequest.Result.Success)
        {
            Sprite spriteToSend;
            spriteToSend = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
            OnSucces?.Invoke(spriteToSend);
        }
    }
}

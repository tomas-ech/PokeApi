using UnityEngine;
using UnityEngine.UI;

public class InitialScreenView : BaseView
{
    private const string documentationUrl = "https://github.com/tomas-ech/PokeApi";

    [SerializeField] private Button exitButton;
    [SerializeField] private Button pokedexButton;
    [SerializeField] private Button documentationButton;


    public override void Initialize()
    {
        base.Initialize();

        pokedexButton.onClick.AddListener(() => HandleScreenChange(UiViews.PokedexPage));

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("Saliendo");
        });

        documentationButton.onClick.AddListener(() =>
        {
            Application.OpenURL(documentationUrl);
        });
    }
}

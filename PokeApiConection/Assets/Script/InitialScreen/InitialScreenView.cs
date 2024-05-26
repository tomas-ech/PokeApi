using UnityEngine;
using UnityEngine.UI;

public class InitialScreenView : BaseView
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button pokedexButton;


    public override void Initialize()
    {
        base.Initialize();

        pokedexButton.onClick.AddListener(() => HandleScreenChange(UiViews.PokedexPage));

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("Saliendo");
        }
        );
    }
}

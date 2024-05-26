
using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private UiViews initialView;
    [SerializeField] private BaseController[] controllers;

    private Action<UiViews> onChangeScreen;
    private BaseController currentController;

    private void Awake()
    {
        foreach (var item in controllers)
        {
            item.HideController();
        }

        SetActiveView(initialView);
    }

    private void SetActiveView(UiViews currentView)
    {
        switch (currentView)
        {
            case UiViews.InitialPage:
                SwitchViews(controllers[0]);
                break;

            case UiViews.PokedexPage:
                SwitchViews(controllers[1]);
                break;
        }
    }

    private void SwitchViews(BaseController newCurrentScreen)
    {
        currentController?.HideController();
        currentController?.SwitchScreen(null);

        currentController = newCurrentScreen;

        currentController.InitializeController();
        currentController.SwitchScreen(SetActiveView);
    }

    public void ChangeToPokedex()
    {
        SetActiveView(UiViews.PokedexPage);
    }
}

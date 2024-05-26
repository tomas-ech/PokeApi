using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private const float transitionsTime = 0.5f;

    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected BaseView mainView;

    public virtual void InitializeController()
    {
        SetCanvasGroupAlpha(0, 1, transitionsTime);
        mainView.Initialize();
    }

    public virtual void HideController()
    {
        SetCanvasGroupAlpha(1, 0, 0);
    }

    public void SwitchScreen(Action<UiViews> OnChangeScreen)
    {
        mainView.SetSwitchScreenAction(OnChangeScreen);
    }

    private void SetCanvasGroupAlpha(float initial, float final, float time)
    {
        LeanTween.value(canvasGroup.gameObject, (value) => canvasGroup.alpha = value, initial, final, time);
        canvasGroup.blocksRaycasts = final > 0;
    }
}

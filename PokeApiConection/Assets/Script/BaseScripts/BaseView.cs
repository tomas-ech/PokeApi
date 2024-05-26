using System;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    private Action<UiViews> actionToSetScreen;

    public virtual void Initialize()
    {

    }

    public void SetSwitchScreenAction(Action<UiViews> onChangeScreen)
    {
        actionToSetScreen = onChangeScreen;
    }

    protected void HandleScreenChange(UiViews screenToSet)
    {
        actionToSetScreen?.Invoke(screenToSet);
    }
}

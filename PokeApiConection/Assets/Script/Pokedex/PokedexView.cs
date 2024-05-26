using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexView : BaseView
{
    [SerializeField] private Button backBtn;


    public override void Initialize()
    {
        base.Initialize();
        backBtn.onClick.AddListener(() => HandleScreenChange(UiViews.InitialPage));
    }
}

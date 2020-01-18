using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EMenuType
{
    TEST1,
    TEST2,
    Mine,
    TEST3,
    TEST4
}

public class MenuManager : MonoBehaviour
{
    
    private static MenuManager inst;

    public static MenuManager Inst { get => inst; }
    public MenuManager() { inst = this; }

    public MenuModel model;
    public MenuView view;

    // Start is called before the first frame update
    void Start()
    {
        model.Init();
        view.Init(model);
        view.onMenuButtonClicked += View_onMenuButtonClicked;
    }

    private void View_onMenuButtonClicked(object sender, System.EventArgs e)
    {
        MenuButton mb = (MenuButton)sender;

        switch (mb.menuType)
        {
            case EMenuType.TEST1:
                break;
            case EMenuType.TEST2:
                break;
            case EMenuType.Mine:
                MineManager.Inst.ShowMine();
                break;
            case EMenuType.TEST3:
                break;
            case EMenuType.TEST4:
                break;
            default:
                break;
        }
    }
}

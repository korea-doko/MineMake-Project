using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public event EventHandler onButtonClicked;
    public EMenuType menuType;
    public Button button;
    

    public void Init(EMenuType menuType)
    {
        this.menuType = menuType;
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        onButtonClicked(this, EventArgs.Empty);
    }
}

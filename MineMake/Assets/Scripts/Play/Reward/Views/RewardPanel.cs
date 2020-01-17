using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour
{
    public event EventHandler onButtonClicked;

    public RectTransform rect;
    public Button confirmButton;

    public void Init()
    {
        rect = this.GetComponent<RectTransform>();
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;

        confirmButton.onClick.AddListener(OnButtonClicked);

        Hide();
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show(RewardModel model)
    {

        this.gameObject.SetActive(true);
    }

    private void OnButtonClicked()
    {
        onButtonClicked(this, EventArgs.Empty);
    }
}

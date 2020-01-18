using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public event EventHandler onBGClicked;

    private static InputManager inst;
    public static InputManager Inst { get => inst; }
    public InputManager() { inst = this; }

    public InputModel model;
    public InputView view;


    private void Awake()
    {
        model.Init();
        view.Init(model);
    }
    private void Update()
    {
        
        if( Input.GetMouseButtonDown(0))
        {
            Vector3 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hits = Physics2D.RaycastAll
                (
                clickedPos,
                Vector2.zero
                );

            foreach( RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    // 맞았음
                    if (hit.collider.CompareTag("Mineral"))
                    {
                        Mineral m = hit.collider.GetComponent<Mineral>();

                        m.MineralHit();
                                              
                    }
                    else
                    {
                        ShowDroppingDirtAt(clickedPos);   

                        onBGClicked(this, EventArgs.Empty);
                    }
                }
                else
                {
                    // 아무것도 맞지 않음
                }
            }          
        }
    }

    private void ShowDroppingDirtAt(Vector3 _pos)
    {
        DroppingDirt dd = view.GetDroppingDirt();

        dd.Show(_pos);
    }
}

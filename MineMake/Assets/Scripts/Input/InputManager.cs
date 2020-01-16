using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager inst;
    public static InputManager Inst { get => inst; }
    public InputManager() { inst = this; }

    private void Awake()
    {
        
    }
    private void Update()
    {
        
        if( Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll
                (
                Camera.main.ScreenToWorldPoint( Input.mousePosition ), 
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

                    }
                }
                else
                {
                    // 아무것도 맞지 않음
                }
            }
            
           
        }

    }
}

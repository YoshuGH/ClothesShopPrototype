using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    public Canvas shopCanvas;
    bool toggle = false;
    public void Interact()
    {
        
        if(toggle)
        {
            shopCanvas.gameObject.SetActive(false);
            toggle = false;
        }
        else
        {
            shopCanvas.gameObject.SetActive(true);
            toggle = true;
        }
    }
}

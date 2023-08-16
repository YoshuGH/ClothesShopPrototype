using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    public string test = "";
    public void Interact()
    {
        Debug.Log(test);
    }
}

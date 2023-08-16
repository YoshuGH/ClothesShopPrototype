using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Item : MonoBehaviour
{
    [SerializeField] ItemBaseSO _itemReference;
    public ItemBaseSO ItemReference
    {
        get => _itemReference;
        set => _itemReference = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Item : MonoBehaviour
{
    [SerializeField] ItemSO _itemReference;
    public ItemSO ItemReference
    {
        get => _itemReference;
        set => _itemReference = value;
    }
}

using UnityEngine;

public enum ItemType
{
    Hat,
    Shirt,
    Pants
}

public class ItemBaseSO : ScriptableObject
{
    public Sprite itemSprite;
    public ItemType itemType;
    public string itemName;
    public float price;
    [TextArea(5, 10)]
    public string itemDescription;
}

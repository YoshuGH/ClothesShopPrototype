using UnityEngine;

public enum ItemType
{
    Removable,
    Material,
    PlayerPowerUp,
    Consumable,
    CauldronSpell
}

public class ItemSO : ScriptableObject
{
    public Sprite itemSprite;
    public ItemType itemType;
    public string itemName;
    [TextArea(5, 10)]
    public string itemDescription;
    public GameObject InstanceSpell; //
}

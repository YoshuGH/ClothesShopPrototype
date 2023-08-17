using UnityEngine;

[CreateAssetMenu(fileName = "New Pants Object", menuName = "Items/Pants")]
public class PantsSO : ItemBaseSO
{
    public void Awake()
    {
        itemType = ItemType.Pants;
    }
}

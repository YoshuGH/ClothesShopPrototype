using UnityEngine;

[CreateAssetMenu(fileName = "New Shirt Object", menuName = "Items/Shirt")]
public class ShirtSO : ItemBaseSO
{
    public void Awake()
    {
        itemType = ItemType.Shirt;
    }
}

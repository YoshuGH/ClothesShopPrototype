using UnityEngine;

[CreateAssetMenu(fileName = "New Hat Object", menuName = "Items/Hat")]
public class HatSO : ItemBaseSO
{
    public void Awake()
    {
        itemType = ItemType.Hat;
    }
}

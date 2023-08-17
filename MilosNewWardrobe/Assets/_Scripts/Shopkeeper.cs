using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopEventChannelSO _onOpenShop;

    public void Interact()
    {
        Collider2D nearObj = Physics2D.OverlapCircle(transform.position, 1.5f);
        if (nearObj != null && nearObj.CompareTag("Player"))
        {
            if(nearObj.gameObject.GetComponent<StatsManager>() && nearObj.gameObject.GetComponent<InventoryManager>())
                _onOpenShop?.RaiseEvent(nearObj.gameObject.GetComponent<InventoryManager>(), nearObj.gameObject.GetComponent<StatsManager>());
        }
    }
}

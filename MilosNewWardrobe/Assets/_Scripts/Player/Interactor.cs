using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactor : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;
    [SerializeField] float _interactionRadius;

    LayerMask _interactableLayer = 1 << 6;
    Collider2D _collider;

    private void OnEnable()
    {
        _inputReader.InteractEvent += HandleInteract;
    }

    private void OnDisable()
    {
        _inputReader.InteractEvent -= HandleInteract;
    }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IUIInteractable>() != null)
        {
            
        }
    }

    // When the interact key is pressed
    void HandleInteract()
    {
        GameObject nearestInteractableObj = GetNearestInteractable();
        if (nearestInteractableObj == null) return;
        nearestInteractableObj.GetComponent<IInteractable>().Interact();
    }

    private GameObject GetNearestInteractable()
    {
        Collider2D nearObj = Physics2D.OverlapCircle(transform.position, _interactionRadius, _interactableLayer);
        if (nearObj != null && nearObj.gameObject.GetComponent<IInteractable>() != null) return nearObj.gameObject;
        return null;
    }
}

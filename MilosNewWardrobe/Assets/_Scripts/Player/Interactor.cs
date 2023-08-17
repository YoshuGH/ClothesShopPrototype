using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactor : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;
    [SerializeField] float _interactionRadius;

    LayerMask _interactableLayer = 1 << 6;
    CircleCollider2D _collider;

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
        _collider = GetComponent<CircleCollider2D>();
        _collider.radius = _interactionRadius;
    }

    #region Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            collision.gameObject.GetComponent<IPoppableUI>().PopUpUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            collision.gameObject.GetComponent<IPoppableUI>().PopOutUI();
        }
    }
    #endregion

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

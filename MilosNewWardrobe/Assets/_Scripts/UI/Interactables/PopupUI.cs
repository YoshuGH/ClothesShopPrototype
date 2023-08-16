using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PopupUI : MonoBehaviour, IUIInteractable
{
    [SerializeField] private GameObject _popupUI;
    [SerializeField] private Vector3 _offset;

    GameObject _popedUIRef;

    public void PopOutUI()
    {
        if(_popedUIRef != null)
        {
            Destroy(_popedUIRef);
            _popedUIRef = null;
        }
    }

    public void PopUpUI()
    {
        if(_popedUIRef == null)
        {
            _popedUIRef = Instantiate(_popupUI, transform.position + _offset, Quaternion.identity, transform);
        }
    }
}

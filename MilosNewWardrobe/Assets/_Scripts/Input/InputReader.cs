using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions
{
    private GameInput _gameInput;

    #region Events
    //Gameplay
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };

    //UI
    public event UnityAction<Vector2> UIMouseMoveEvent = delegate { };
    public event UnityAction UICloseEvent = delegate { };
    public event UnityAction UIClickButtonEvent = delegate { };
    public event UnityAction<Vector2> UIMoveSelectionEvent = delegate { };
    public event UnityAction UIPauseEvent = delegate { };
    public event UnityAction UIUnpauseEvent = delegate { };
    public event UnityAction OpenInventoryEvent = delegate { };
    public event UnityAction CloseInventoryEvent = delegate { };
    public event UnityAction<float> TabSwitched = delegate { };

    #endregion

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.UI.SetCallbacks(this);

            SetGameplayInput();
        }
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    #region Input Functions

    #region Gameplay
    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            InteractEvent?.Invoke();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            UIPauseEvent?.Invoke();
    }
    #endregion

    #region UI
    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        UIMoveSelectionEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            UIClickButtonEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            UICloseEvent?.Invoke();
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        UIMouseMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnUnpause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            UIUnpauseEvent?.Invoke();
    }

    public void OnChangeTab(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            TabSwitched.Invoke(context.ReadValue<float>());
    }

    public void OnInventoryActionButton(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSaveActionButton(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnResetActionButton(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCloseInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            CloseInventoryEvent?.Invoke();
    }
    #endregion

    #endregion

    #region Helper Funtions
    /// <summary>
    /// Returns the current mouse coordinates in window space.
    /// </summary>
    /// <returns> Vector2 </returns>
    public Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }

    /// <summary>
    /// Returns if the left button of the current mouse was pressed down.
    /// </summary>
    /// <returns> Bool </returns>
    public bool LeftMouseDown() => Mouse.current.leftButton.isPressed;
    #endregion

    public void SetGameplayInput()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.UI.Disable();
    }

    public void SetMenusInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.UI.Enable();
    }

    public void DisableAllInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.UI.Disable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private PlayerState _currentPlayerState;

    public UnityEvent<PlayerState> OnPlayerStateChanged;

    public void UpdatePlayerState(PlayerState newPlayerState)
    {
        _currentPlayerState = newPlayerState;
        OnPlayerStateChanged?.Invoke(_currentPlayerState);
    }
}


public enum PlayerState
{
    Gameplay,
    Interacting
}
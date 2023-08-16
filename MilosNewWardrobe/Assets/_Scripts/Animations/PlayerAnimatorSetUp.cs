using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorSetUp : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    Animator anim;

    private void OnEnable()
    {
        _inputReader.MoveEvent += HandleMove;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= HandleMove;
    }

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void HandleMove(Vector2 _dir)
    {
        anim.SetFloat("velocityX", _dir.x);
        anim.SetFloat("velocityZ", _dir.y);
    }
}

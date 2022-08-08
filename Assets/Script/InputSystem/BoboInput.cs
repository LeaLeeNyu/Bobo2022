using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboInput : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener = default;

    //Parameter that used by state machine
    [HideInInspector] public bool jumpInput;
    [HideInInspector] public Vector2 moveVectorInput;

    private void OnEnable()
    {
        _inputListener.JumpE += OnJump;
        _inputListener.JumpCancelE += OnJumpCancel;
        _inputListener.MoveE += OnMove;
    }

    private void OnDisable()
    {
        _inputListener.JumpE -= OnJump;
        _inputListener.JumpCancelE -= OnJumpCancel;
        _inputListener.MoveE -= OnMove;
    }

    //Event Listener
    private void OnJump()
    {
        jumpInput = true;
    }

    private void OnJumpCancel()
    {
        jumpInput = false;
    }

    private void OnMove(Vector2 moveVector)
    {
        moveVectorInput = moveVector;
        Debug.Log("Move Invoke");
    }

}

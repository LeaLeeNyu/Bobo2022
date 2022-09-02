using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BoboInput : MonoBehaviour
{
    //Create instance of input asset
    [SerializeField] public InputListener inputListener = default;

    //Parameter that used by state machine
    [HideInInspector] public bool jumpInput;
    [HideInInspector] public Vector2 moveVectorInput;
    [HideInInspector] public bool stealthInput = false;
    [HideInInspector] public Vector2 stealthMoveVectorInput;
    [HideInInspector] public bool stealthQuitInput = false;

    //const value used by state machine
    public const float WALK_SPEED = 3.0f;
    public const float TURN_SMOOTH_TIME = 0.05f;
    public const float TURN_SMOOTH_VELOCITY = default;
    public const float STEALTH_SPEED = 2.0f;


    private void OnEnable()
    {
        inputListener.JumpE += OnJump;
        inputListener.JumpCancelE += OnJumpCancel;
        inputListener.MoveE += OnMove;
        inputListener.StealthE += OnStealth;
        inputListener.StealthCancel += OnStealthCancel;

        //Stealth Action Map
        inputListener.StealthMove += OnStealthMove;
        inputListener.QuitStealthE += OnStealthQuit;
        inputListener.QuitStealthCancel += OnStealthQuitCancel;
    }

    private void OnDisable()
    {
        inputListener.JumpE -= OnJump;
        inputListener.JumpCancelE -= OnJumpCancel;
        inputListener.MoveE -= OnMove;
        inputListener.StealthE -= OnStealth;
        inputListener.StealthCancel -= OnStealthCancel;

        inputListener.StealthMove -= OnStealthMove;
        inputListener.QuitStealthE -= OnStealthQuit;
        inputListener.QuitStealthCancel -= OnStealthQuitCancel;
    }

    //Event Listener
    //Basic Gameplay
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
    }

    private void OnStealth()
    {
        stealthInput = true;
    }

    private void OnStealthCancel()
    {
        stealthInput = false;
    }

    //Stealth Action Map
    private void OnStealthMove(Vector2 stealthMove)
    {
        stealthMoveVectorInput = stealthMove;
    }

    private void OnStealthQuit()
    {
        stealthQuitInput = true;
    }

    private void OnStealthQuitCancel()
    {
        stealthQuitInput = false;
    }

}

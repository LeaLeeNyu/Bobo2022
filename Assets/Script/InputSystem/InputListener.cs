using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="InputListener",menuName ="Input System/Input Listener")]
public class InputListener : ScriptableObject, GameInput.IBasicActions,GameInput.IStealthActions
{
    private GameInput _gameInput;

    public event UnityAction JumpE = delegate { };
    public event UnityAction JumpCancelE = delegate { };
    public event UnityAction<Vector2> MoveE = delegate { };
    public event UnityAction StealthE = delegate { };
    public event UnityAction StealthCancel = delegate { };  

    public event UnityAction<Vector2> StealthMove = delegate { };
    public event UnityAction QuitStealthE = delegate { };
    public event UnityAction QuitStealthCancel = delegate { };

    public void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Basic.SetCallbacks(this);
            _gameInput.Stealth.SetCallbacks(this);
        }

        //Start with Basic Action Map
        EnableBasic();
    }

    public void OnDisable()
    {
        DisableAll();
    }

    public void EnableStealth()
    {
        _gameInput.Basic.Disable();
        _gameInput.Stealth.Enable();
        Debug.Log("Enable Stealth"); 
    }

    public void EnableBasic()
    {
        _gameInput.Basic.Enable();
        _gameInput.Stealth.Disable();
        Debug.Log("Enable Basic");
    }

    private void DisableAll()
    {
        _gameInput.Basic.Disable();
        _gameInput.Stealth.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpE.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            JumpCancelE.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveE.Invoke(context.ReadValue<Vector2>());       
    }

    public void OnStealth(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            StealthE.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            StealthCancel.Invoke();
        }       
    }

    //Stealth Action Map
    public void OnStealthMove(InputAction.CallbackContext context)
    {
       StealthMove.Invoke(context.ReadValue<Vector2>());
    }

    public void OnQuitStealth(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            QuitStealthE.Invoke();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            QuitStealthCancel.Invoke();
        }
    }
}

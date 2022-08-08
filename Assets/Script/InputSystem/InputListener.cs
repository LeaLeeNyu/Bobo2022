using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="InputListener",menuName ="Input System/Input Listener")]
public class InputListener : ScriptableObject, GameInput.IGamePlayActions
{
    private GameInput _gameInput;

    public event UnityAction JumpE = delegate { };
    public event UnityAction JumpCancelE = delegate { };
    public event UnityAction<Vector2> MoveE = delegate { };
    public event UnityAction InteractE = delegate { };

    public void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.GamePlay.SetCallbacks(this);
            //Debug.Log("enable inputListener");
        }
        _gameInput.GamePlay.Enable();
    }

    public void OnDisable()
    {
        DisableAll();
    }

    private void DisableAll()
    {
        _gameInput.GamePlay.Disable();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            InteractE.Invoke();
        }
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
}

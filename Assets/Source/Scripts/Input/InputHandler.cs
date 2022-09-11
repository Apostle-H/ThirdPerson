using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputHandler : MonoBehaviour
{
    public  MainAction.PlayerMovementActions PlayerMovement { get{return _mainInputActions.playerMovement;} }
    public  MainAction.PlayerCombatActions PlayerCombat { get{return _mainInputActions.playerCombat;} }

    private MainAction _mainInputActions;

    private void Awake()
    {
        _mainInputActions = new MainAction();
        _mainInputActions.Enable();

        _mainInputActions.inputControl.OnOffInput.performed += OffPlayerInput;
    }

    private void OffPlayerInput(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() > 0 && !_mainInputActions.playerMovement.enabled)
        {
            _mainInputActions.playerMovement.Enable();
        }
        else if (ctx.ReadValue<float>() < 0 && _mainInputActions.playerMovement.enabled)
        {
            _mainInputActions.playerMovement.Disable();
        }
        
        Debug.Log($"input {_mainInputActions.playerMovement.enabled}");
    }
}

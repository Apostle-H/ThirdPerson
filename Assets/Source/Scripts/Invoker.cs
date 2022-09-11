using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombat playerCombat;
    
    private void OnEnable()
    {
        EnableMovement();
        EnableCombat();
    }

    private void OnDisable()
    {
        DisableMovement();
        DisableCombat();
    }
    
    private void EnableMovement()
    {
        inputHandler.PlayerMovement.movement.started += playerMovement.PerformMove;
        inputHandler.PlayerMovement.movement.performed += playerMovement.PerformMove;
        inputHandler.PlayerMovement.movement.canceled += playerMovement.PerformMove;
        
        inputHandler.PlayerMovement.jump.performed += playerMovement.PerformJump;
    }

    private void DisableMovement()
    {
        inputHandler.PlayerMovement.movement.started -= playerMovement.PerformMove;
        inputHandler.PlayerMovement.movement.performed -= playerMovement.PerformMove;
        inputHandler.PlayerMovement.movement.canceled -= playerMovement.PerformMove;
        
        inputHandler.PlayerMovement.jump.performed -= playerMovement.PerformJump;
    }
    
    private void EnableCombat()
    {
        inputHandler.PlayerCombat.fire.performed += playerCombat.PerformShoot;
    }

    private void DisableCombat()
    {
        inputHandler.PlayerCombat.fire.performed -= playerCombat.PerformShoot;
    }

}

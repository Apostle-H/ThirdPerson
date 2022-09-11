using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    [SerializeField] private PlayerMovementSettingsSO playerMovementSettingsSO;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform feet;

    private Vector2 _playerMovementInput;
    private Vector2 _rbCurrentAcceleration;

    private void FixedUpdate()
    {
        Move();
    }

    public void PerformMove(InputAction.CallbackContext ctx)
    {
        _playerMovementInput = ctx.ReadValue<Vector2>();
    }

    public void PerformJump(InputAction.CallbackContext ctx)
    {
        if (Physics.OverlapSphere(feet.position, playerMovementSettingsSO.GroundCheckRadius, 
                playerMovementSettingsSO.GroundCheckLayerMask).Length <= 0)
        {
            return;
        }
        
        Jump();
    }

    private void Move()
    {
        float targetMoveSpeed = _playerMovementInput.y * playerMovementSettingsSO.CharMoveSpeed;
        Vector2 currentVelocity = new Vector2(rb.velocity.x, rb.velocity.z);
        Vector2 targetVelocity = new Vector2(transform.forward.x * targetMoveSpeed, transform.forward.z * targetMoveSpeed);
        
        Vector2 resultVelocity = Vector2.SmoothDamp(currentVelocity, targetVelocity, ref _rbCurrentAcceleration, 
            playerMovementSettingsSO.CharMoveSmoothTime);

        rb.velocity = new Vector3(resultVelocity.x, rb.velocity.y, resultVelocity.y);
        rb.angularVelocity = Vector3.zero;
        transform.Rotate(Vector3.up, _playerMovementInput.x * playerMovementSettingsSO.CharRotationSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * playerMovementSettingsSO.CharJumpForce, ForceMode.Impulse);
    }
}

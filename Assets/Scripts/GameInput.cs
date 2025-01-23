using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public event EventHandler OnInteractAction;   
    public event EventHandler OnInteractAlternateAction;   

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 InputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

        InputVector = InputVector.normalized;

        return InputVector; 
    }
}

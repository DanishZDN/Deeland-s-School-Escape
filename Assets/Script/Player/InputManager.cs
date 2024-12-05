using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private Animator animator;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        animator = GetComponent<Animator>();

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
    }

    void FixedUpdate()
    {
        Vector2 movement = onFoot.Movement.ReadValue<Vector2>();
        motor.ProcessMove(movement);

        bool Isrunning = onFoot.Sprint.ReadValue<float>() > 0;
        bool Iswalking = movement.magnitude > 0 && !Isrunning;
        bool Isjumping = !motor.IsGrounded; // Assuming motor has a property to check if the player is grounded

        if (animator != null)
        {
            animator.SetBool("Isrunning", Isrunning);
            animator.SetBool("Iswalking", Iswalking);
            animator.SetBool("Isjumping", Isjumping);
        }
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
